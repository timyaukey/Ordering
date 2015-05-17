using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Willowsoft.Ordering.UI.SetupForms
{
    public partial class ProductWebHarvestForm : Form
    {
        private static Form mSingleton;

        private List<HtmlDocument> mDocuments = new List<HtmlDocument>();
        private Stack<ElementSelect> mSelectedElements = new Stack<ElementSelect>();
        private Stack<ProductToSave> mProductsToSave = new Stack<ProductToSave>();

        private class ElementSelect
        {
            public HtmlElement Element { get; set; }
            public string OldStyle { get; set; }
            public NextFieldToSave OldNextField { get; set; }
        }

        private enum NextFieldToSave
        {
            VendorCode = 1,
            ProductName = 2,
            ProductSize = 3,
            BrandName = 4,
            Cost = 5,
            Done = 6
        }

        private class ProductToSave
        {
            public string VendorCode { get; set; }
            public string ProductName { get; set; }
            public string Size { get; set; }
            public string BrandName { get; set; }
            public string CasePrice { get; set; }
            public string CaseSize { get; set; }
            public string EachPrice { get; set; }
        }

        private NextFieldToSave mNextField = NextFieldToSave.VendorCode;

        public ProductWebHarvestForm()
        {
            InitializeComponent();
        }

        public static void Show(Form mdiParent)
        {
            if (mSingleton == null)
            {
                mSingleton = new ProductWebHarvestForm();
                mSingleton.MdiParent = mdiParent;
                mSingleton.Show();
            }
            else
            {
                mSingleton.Activate();
            }
        }

        private void InitNextProduct()
        {
            mNextField = NextFieldToSave.VendorCode;
            ShowNextField();
        }

        private void ShowNextField()
        {
            ShowNextFieldControl(txtVendorCode, NextFieldToSave.VendorCode, "Vendor Code");
            ShowNextFieldControl(txtProductName, NextFieldToSave.ProductName, "Product Name");
            ShowNextFieldControl(txtSize, NextFieldToSave.ProductSize, "Size");
            ShowNextFieldControl(txtBrandName, NextFieldToSave.BrandName, "Brand Name");
            ShowNextFieldControl(txtCasePrice, NextFieldToSave.Cost, "Case Price");
            ShowNextFieldControl(txtCaseSize, NextFieldToSave.Cost, "Case Size");
            ShowNextFieldControl(txtEachPrice, NextFieldToSave.Cost, "Each Price");
            btnSave.Enabled = (mNextField == NextFieldToSave.Done);
            lblProductCount.Text = ((mProductsToSave.Count == 0) ?
                "No" : mProductsToSave.Count.ToString()) + " products extracted";
        }

        private void ShowNextFieldControl(TextBox txtBox, NextFieldToSave nextField, string hintText)
        {
            if (mNextField == nextField)
                txtBox.BackColor = Color.Cyan;
            else
                txtBox.BackColor = SystemColors.ButtonFace;
            if (nextField >= mNextField)
                txtBox.Text = hintText;
        }

        private void ProductWebHarvestForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            mSingleton = null;
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtURL.Text))
                ctlBrowser.Navigate(txtURL.Text);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ctlBrowser.GoBack();
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            ctlBrowser.GoForward();
        }

        void Document_Click(object sender, HtmlElementEventArgs e)
        {
            e.BubbleEvent = false;
            HtmlElement elm = ((HtmlDocument)sender).GetElementFromPoint(e.ClientMousePosition);
            if (elm == null)
                return;
            string rawValue = elm.InnerText;
            if (string.IsNullOrEmpty(rawValue))
                return;
            rawValue = rawValue.Trim();
            bool extractedValue = false;
            NextFieldToSave oldNextField = mNextField;
            switch (mNextField)
            {
                case NextFieldToSave.VendorCode:
                    txtVendorCode.Text = rawValue;
                    mNextField = NextFieldToSave.ProductName;
                    extractedValue = true;
                    break;
                case NextFieldToSave.ProductName:
                    if (rawValue.StartsWith(txtVendorCode.Text))
                    {
                        rawValue = rawValue.Substring(txtVendorCode.Text.Length).Trim();
                    }
                    string extractedSize = string.Empty;
                    string numPre = "(^| )[0-9]{1,3}((\\.[0-9]{0,2})|(( |-)[0-9]{1,2}/[0-9]{1,2}))? ?";
                    string numPreOpt = "(" + numPre + ")?";
                    if (ReplaceRegex(ref rawValue, numPre + "((OZ\\.?)|(LBS?\\.?))", ref extractedSize)) { }
                    else if (ReplaceRegex(ref rawValue, numPre + "\"", ref extractedSize)) { }
                    else if (ReplaceRegex(ref rawValue, numPre + "#", ref extractedSize)) { }
                    else if (ReplaceRegex(ref rawValue, numPreOpt + "QT\\.? ", ref extractedSize)) { }
                    else if (ReplaceRegex(ref rawValue, numPreOpt + "PT\\.? ", ref extractedSize)) { }
                    else if (ReplaceRegex(ref rawValue, numPreOpt + "GAL?\\.? ", ref extractedSize)) { }
                    else if (ReplaceRegex(ref rawValue, numPre + "((IN\\.?)|(COUNT))", ref extractedSize)) { }
                    else if (ReplaceRegex(ref rawValue, numPre + "((SQ\\.FT\\.)|(SQ ?FT))", ref extractedSize)) { }
                    else if (ReplaceRegex(ref rawValue, "(^| )MED\\.? ", ref extractedSize)) { }
                    else if (ReplaceRegex(ref rawValue, "(^| )SM\\.? ", ref extractedSize)) { }
                    else if (ReplaceRegex(ref rawValue, "(^| )SMALL ", ref extractedSize)) { }
                    else if (ReplaceRegex(ref rawValue, "(^| )LR?G\\.? ", ref extractedSize)) { }
                    else if (ReplaceRegex(ref rawValue, "(^| )LARGE ", ref extractedSize)) { }
                    txtProductName.Text = rawValue;
                    if (chkExtractSize.Checked)
                        mNextField = NextFieldToSave.ProductSize;
                    else
                    {
                        txtSize.Text = extractedSize;
                        if (chkExtractBrand.Checked)
                        {
                            mNextField = NextFieldToSave.BrandName;
                        }
                        else
                        {
                            txtBrandName.Text = string.Empty;
                            mNextField = NextFieldToSave.Cost;
                        }
                    }
                    extractedValue = true;
                    break;
                case NextFieldToSave.ProductSize:
                    txtSize.Text = rawValue;
                    if (chkExtractBrand.Checked)
                        mNextField = NextFieldToSave.BrandName;
                    else
                        mNextField = NextFieldToSave.Cost;
                    extractedValue = true;
                    break;
                case NextFieldToSave.BrandName:
                    txtBrandName.Text = rawValue;
                    mNextField = NextFieldToSave.Cost;
                    extractedValue = true;
                    break;
                case NextFieldToSave.Cost:
                    if (rawValue.StartsWith("$"))
                    {
                        rawValue = rawValue.Substring(1);
                    }
                    rawValue = rawValue.ToUpper();
                    if (TryEachPrice(rawValue, "EA")) { }
                    else if (TryEachPrice(rawValue, "EACH")) { }
                    else if (TryCasePrice(rawValue, "CS")) { }
                    else if (TryCasePrice(rawValue, "CASE")) { }
                    else if (TryCasePrice(rawValue, "BX")) { }
                    else if (TryCasePrice(rawValue, "BOX")) { }
                    else if (TryCasePrice(rawValue, "PK")) { }
                    else if (TryCasePrice(rawValue, "PACK")) { }
                    else
                    {
                        txtEachPrice.Text = rawValue;
                        txtCasePrice.Text = string.Empty;
                        txtCaseSize.Text = string.Empty;
                    }
                    mNextField = NextFieldToSave.Done;
                    extractedValue = true;
                    break;
                default:
                    break;
            }
            ShowNextField();
            ElementSelect selectedElm = new ElementSelect();
            selectedElm.OldNextField = oldNextField;
            if (extractedValue)
            {
                selectedElm.OldStyle = elm.Style;
                selectedElm.Element = elm;
                elm.Style = "color:black;background-color:#FFB060;font-weight:bold;font-size:10pt;";
            }
            else
            {
                selectedElm.OldStyle = null;
                selectedElm.Element = null;
            }
            mSelectedElements.Push(selectedElm);
            btnUndoSelect.Enabled = true;
        }

        private bool ReplaceRegex(ref string rawValue, string pattern, ref string extracted)
        {
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            Match match = regex.Match(rawValue);
            if (match.Success)
            {
                extracted = match.Value;
                rawValue = rawValue.Replace(extracted, " ").Trim();
                rawValue = rawValue.Replace("  ", " ").Replace("  ", " ");
                return true;
            }
            return false;
        }

        private bool TryEachPrice(string rawValue, string ending)
        {
            if (!ending.StartsWith("/") && TryEachPrice(rawValue, "/" + ending))
                return true;
            if (rawValue.EndsWith(ending))
            {
                txtEachPrice.Text = rawValue.Replace(ending, string.Empty);
                txtCasePrice.Text = string.Empty;
                txtCaseSize.Text = string.Empty;
                return true;
            }
            return false;
        }

        private bool TryCasePrice(string rawValue, string ending)
        {
            if (!ending.StartsWith("/") && TryCasePrice(rawValue, "/" + ending))
                return true;
            if (rawValue.EndsWith(ending))
            {
                txtCasePrice.Text = rawValue.Replace(ending, string.Empty);
                txtCaseSize.Text = string.Empty;
                txtEachPrice.Text = string.Empty;
                return true;
            }
            return false;
        }

        private void ctlBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            if (chkExtractMode.Checked)
            {
                e.Cancel = true;
                return;
            }
        }

        private void chkExtractMode_CheckedChanged(object sender, EventArgs e)
        {
            if (chkExtractMode.Checked)
            {
                HookClickEvents();
            }
            else
            {
                ReleaseDocuments();
                ctlBrowser.Refresh(WebBrowserRefreshOption.Completely);
            }
            mProductsToSave.Clear();
            InitNextProduct();
        }

        private List<HtmlDocument> BuildDocumentList()
        {
            List<HtmlDocument> documents = new List<HtmlDocument>();
            AddToDocumentList(documents, ctlBrowser.Document.Window);
            return documents;
        }

        private void AddToDocumentList(List<HtmlDocument> documents, HtmlWindow window)
        {
            documents.Add(window.Document);
            foreach (HtmlWindow childWindow in window.Frames)
            {
                AddToDocumentList(documents, childWindow);
            }
        }

        private void ReleaseDocuments()
        {
            foreach (HtmlDocument doc in mDocuments)
            {
                doc.Click -= Document_Click;
            }
            mDocuments = new List<HtmlDocument>();
            btnUndoSelect.Enabled = false;
            mSelectedElements = new Stack<ElementSelect>();
        }

        private void HookClickEvents()
        {
            ReleaseDocuments();
            mDocuments = BuildDocumentList();
            foreach (HtmlDocument doc in mDocuments)
            {
                doc.Click += Document_Click;
            }
        }

        private void btnUndoSelect_Click(object sender, EventArgs e)
        {
            switch (mNextField)
            {
                case NextFieldToSave.VendorCode:
                    if (mProductsToSave.Count > 0)
                    {
                        ProductToSave toSave = mProductsToSave.Pop();
                        txtVendorCode.Text = toSave.VendorCode;
                        txtProductName.Text = toSave.ProductName;
                        txtSize.Text = toSave.Size;
                        txtBrandName.Text = toSave.BrandName;
                        txtCasePrice.Text = toSave.CasePrice;
                        txtCaseSize.Text = toSave.CaseSize;
                        txtEachPrice.Text = toSave.EachPrice;
                    }
                    break;
            }
            if (mSelectedElements.Count > 0)
            {
                ElementSelect sel = mSelectedElements.Pop();
                mNextField = sel.OldNextField;
                if (sel.Element != null)
                {
                    sel.Element.Style = sel.OldStyle;
                }
            }
            ShowNextField();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ProductToSave toSave = new ProductToSave();
            toSave.VendorCode = txtVendorCode.Text;
            toSave.ProductName = txtProductName.Text;
            toSave.Size = txtSize.Text;
            toSave.BrandName = txtBrandName.Text;
            toSave.CasePrice = txtCasePrice.Text;
            toSave.CaseSize = txtCaseSize.Text;
            toSave.EachPrice = txtEachPrice.Text;
            mProductsToSave.Push(toSave);
            SaveProductsToClipboard();
            
            ElementSelect selectedElm = new ElementSelect();
            selectedElm.OldNextField = NextFieldToSave.Done;
            selectedElm.OldStyle = null;
            selectedElm.Element = null;
            mSelectedElements.Push(selectedElm);

            InitNextProduct();
        }

        private void SaveProductsToClipboard()
        {
            Stack<ProductToSave> reversed = new Stack<ProductToSave>();
            foreach (ProductToSave toSave in mProductsToSave)
            {
                reversed.Push(toSave);
            }
            StringBuilder outBuf = new StringBuilder();
            while (reversed.Count > 0)
            {
                ProductToSave toSave = reversed.Pop();
                string line = toSave.ProductName + "\t" +
                    toSave.Size + "\t" + toSave.VendorCode + "\t" +
                    "0" + "\t" +
                    (string.IsNullOrEmpty(toSave.CasePrice) ? "0" : toSave.CasePrice) + "\t" +
                    (string.IsNullOrEmpty(toSave.CaseSize) ? "0" : toSave.CaseSize) + "\t" +
                    (string.IsNullOrEmpty(toSave.EachPrice) ? "0" : toSave.EachPrice) + "\t" +
                    toSave.BrandName + "\t" + "\t" + "Y";
                outBuf.AppendLine(line);
            }
            Clipboard.Clear();
            Clipboard.SetText(outBuf.ToString());
        }
    }
}
