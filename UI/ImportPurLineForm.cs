using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Willowsoft.WillowLib.Data.Entity;
using Willowsoft.WillowLib.Data.Misc;
using Willowsoft.WillowLib.Data.Sql;
using Willowsoft.WillowLib.WinForm;
using Willowsoft.Ordering.Core.Entities;
using Willowsoft.Ordering.Core.Repositories;
using Willowsoft.Ordering.UI.Helpers;
using Willowsoft.Ordering.UI.Reports;
using Willowsoft.Ordering.UI.SetupForms;

namespace Willowsoft.Ordering.UI
{
    /// <summary>
    /// Read tab separated lines from the clipboard and use them to add or update PurLine
    /// rows. Lines must contain a subset of the columns exported to clipboard from the
    /// PurLineForm form. Any additional columns are ignored. Columns are identified
    /// in export and import by column header names, which are the same in both places.
    /// Column order does not matter - they are identified by header name.
    /// Import lines must find a matching vendor product code, either in an existing
    /// PurLine or VendorProduct row. If found in PurLine then updates order quantities
    /// in that line, otherwise it creates a new PurLine linked to that VendorProduct
    /// and copies all necessary columns from that VendorProduct and Product row.
    /// </summary>

    public partial class ImportPurLineForm : Form
    {
        private VendorId mVendorId;
        private PurOrderId mOrderId;
        private PersistedBindingList<JoinPlToVpToProd> mPurLines;
        private List<ProductSubCategory> mSubCats;
        private List<ProductBrand> mBrands;

        private int mColQtyOnHand;
        private int mColSubCategory;
        private int mColBrand;
        private int mColProductName;
        private int mColSize;
        private int mColModel;
        private int mColVendorCode;
        private int mColQtyOrdered;
        private int mColOrderEaches;
        private int mColEachCost;
        private int mColCaseCost;
        private int mColCaseSize;

        private List<ImportedPurLine> mImportedLines;

        public ImportPurLineForm()
        {
            InitializeComponent();
        }

        public void Show(VendorId vendorId, PurOrderId purOrderId, PersistedBindingList<JoinPlToVpToProd> purLines)
        {
            mVendorId = vendorId;
            mOrderId = purOrderId;
            mPurLines = purLines;
            this.ShowDialog();
        }

        private void ImportPurLineForm_Load(object sender, EventArgs e)
        {
            using (Ambient.DbSession.Activate())
            {
                mSubCats = OrderingRepositories.ProductSubCategory.GetAll();
                mBrands = OrderingRepositories.ProductBrand.GetAll();
            }
            colSubCategory.Text = PurLineForm.ColNameSubCategory;
            colBrand.Text = PurLineForm.ColNameBrand;
            colProductName.Text = PurLineForm.ColNameProduct;
            colSize.Text = PurLineForm.ColNameSize;
            colModel.Text = PurLineForm.ColNameModel;
            colOnHand.Text = PurLineForm.ColNameOnHand;
            colOrdered.Text = PurLineForm.ColNameOrdered;
            colOrderEaches.Text = PurLineForm.ColNameOrderEaches;
            colVendorCode.Text = PurLineForm.ColNameVendorCode;
            colEachCost.Text = PurLineForm.ColNameEachCost;
            colCaseCost.Text = PurLineForm.ColNameCaseCost;
            colCaseSize.Text = PurLineForm.ColNameCaseSize;
        }

        private void btnReadClipboard_Click(object sender, EventArgs e)
        {
            using (StringReader input = new StringReader(System.Windows.Forms.Clipboard.GetText()))
            {
                int lineNumber = 0;
                string headerLine = input.ReadLine();
                if (string.IsNullOrEmpty(headerLine))
                {
                    MessageBox.Show("First line of clipboard is empty, instead of containing column names.");
                    return;
                }
                lineNumber++;
                string[] colNames = headerLine.Split('\t');
                if (!TryFindRequiredColumnName(PurLineForm.ColNameOnHand, colNames, out mColQtyOnHand)) return;
                if (!TryFindRequiredColumnName(PurLineForm.ColNameSubCategory, colNames, out mColSubCategory)) return;
                if (!TryFindRequiredColumnName(PurLineForm.ColNameBrand, colNames, out mColBrand)) return;
                if (!TryFindRequiredColumnName(PurLineForm.ColNameProduct, colNames, out mColProductName)) return;
                if (!TryFindRequiredColumnName(PurLineForm.ColNameSize, colNames, out mColSize)) return;
                if (!TryFindRequiredColumnName(PurLineForm.ColNameModel, colNames, out mColModel)) return;
                if (!TryFindRequiredColumnName(PurLineForm.ColNameVendorCode, colNames, out mColVendorCode)) return;
                if (!TryFindRequiredColumnName(PurLineForm.ColNameOrdered, colNames, out mColQtyOrdered)) return;
                if (!TryFindRequiredColumnName(PurLineForm.ColNameOrderEaches, colNames, out mColOrderEaches)) return;
                if (!TryFindRequiredColumnName(PurLineForm.ColNameEachCost, colNames, out mColEachCost)) return;
                if (!TryFindRequiredColumnName(PurLineForm.ColNameCaseCost, colNames, out mColCaseCost)) return;
                if (!TryFindRequiredColumnName(PurLineForm.ColNameCaseSize, colNames, out mColCaseSize)) return;

                mImportedLines = new List<ImportedPurLine>();
                lvwImportLines.Items.Clear();

                for (; ; )
                {
                    string inputLine = input.ReadLine();
                    if (inputLine == null)
                        break;
                    lineNumber++;
                    string[] fields = inputLine.Split('\t');
                    ImportedPurLine importedLine = new ImportedPurLine();
                    importedLine.SubCategoryName = GetField(fields, mColSubCategory);
                    ProductSubCategory subCat = mSubCats.Find(s => s.SubCategoryName == importedLine.SubCategoryName);
                    if (subCat == null)
                    {
                        MessageBox.Show(string.Format("Unrecognized subcategory name\"{0}\" on line {1}", importedLine.SubCategoryName, lineNumber));
                        return;
                    }
                    importedLine.SubCategoryId = subCat.Id;
                    importedLine.BrandName = GetField(fields, mColBrand);
                    ProductBrand brand = mBrands.Find(b => b.BrandName == importedLine.BrandName);
                    if (brand == null)
                    {
                        MessageBox.Show(string.Format("Unrecognized brand name\"{0}\" on line {1}", importedLine.BrandName, lineNumber));
                        return;
                    }
                    importedLine.ProductName = GetField(fields, mColProductName);
                    importedLine.Size = GetField(fields, mColSize);
                    importedLine.Model = GetField(fields, mColModel);
                    importedLine.VendorCode = GetField(fields, mColVendorCode);
                    if (!TryGetInt(fields, mColQtyOnHand, out importedLine.OnHand, string.Format("Invalid amount on hand in line {0}", lineNumber)))
                        return;
                    if (!TryGetInt(fields, mColQtyOrdered, out importedLine.QtyOrd, string.Format("Invalid amount ordered in line {0}", lineNumber)))
                        return;
                    if (!TryGetInt(fields, mColCaseSize, out importedLine.CaseSize, string.Format("Invalid case size in line {0}", lineNumber)))
                        return;
                    if (!TryGetDecimal(fields, mColEachCost, out importedLine.EachCost, string.Format("Invalid each cost in line {0}", lineNumber)))
                        return;
                    if (!TryGetDecimal(fields, mColCaseCost, out importedLine.CaseCost, string.Format("Invalid case cost in line {0}", lineNumber)))
                        return;
                    importedLine.OrderEaches = (GetField(fields, mColOrderEaches).ToUpper() != "Y");
                    mImportedLines.Add(importedLine);
                    ListViewItem lvwItem = new ListViewItem(
                        new string[]
                        {
                            importedLine.OnHand.ToString(),
                            importedLine.SubCategoryName,
                            importedLine.BrandName,
                            importedLine.ProductName,
                            importedLine.Size,
                            importedLine.Model,
                            importedLine.VendorCode,
                            importedLine.QtyOrd.ToString(),
                            (importedLine.OrderEaches ? "Y" : "N"),
                            importedLine.EachCost.ToString("C2"),
                            importedLine.CaseCost.ToString("C2"),
                            importedLine.CaseSize.ToString()
                        });
                    lvwImportLines.Items.Add(lvwItem);
                }
            }
        }

        private string GetField(string[] fields, int colIndex)
        {
            if (colIndex >= fields.Length || colIndex == MissingColumn)
                return string.Empty;
            else
                return fields[colIndex];
        }

        private bool TryGetInt(string[] fields, int colIndex, out int value, string failMessage)
        {
            if (colIndex == MissingColumn)
            {
                value = 0;
                return true;
            }
            string v = GetField(fields, colIndex);
            if (!int.TryParse(v, out value))
            {
                MessageBox.Show(failMessage);
                return false;
            }
            return true;
        }

        private bool TryGetDecimal(string[] fields, int colIndex, out decimal value, string failMessage)
        {
            if (colIndex == MissingColumn)
            {
                value = 0M;
                return true;
            }
            string v = GetField(fields, colIndex);
            if (!decimal.TryParse(v, out value))
            {
                MessageBox.Show(failMessage);
                return false;
            }
            return true;
        }

        private const int MissingColumn = -1;

        private void FindColumnName(string colName, string[] colNames, out int colIndex)
        {
            for(int index=0;index<colNames.Length;index++)
            {
                if (colNames[index] == colName)
                {
                    colIndex = index;
                    return;
                }
            }
            colIndex = MissingColumn;
        }

        private bool TryFindRequiredColumnName(string colName, string[] colNames, out int colIndex)
        {
            FindColumnName(colName, colNames, out colIndex);
            if (colIndex == MissingColumn)
            {
                MessageBox.Show(string.Format("Could not find column name \"{0}\" in first line on clipboard", colName));
                return false;
            }
            return true;
        }

        private void btnCreateOrderLines_Click(object sender, EventArgs e)
        {
            int importCount = 0;
            int productCount = 0;
            MessageBox.Show("Created " + importCount.ToString() +
                " order line items, of which " + productCount.ToString() + " are for new products. " +
                "Use \"Create Products\" to turn these order lines into products.");
            this.Close();
        }

        private class ImportedPurLine
        {
            public int QtyOrd;
            public bool OrderEaches;
            public int OnHand;
            public string SubCategoryName;
            public ProductSubCategoryId SubCategoryId;
            public string BrandName;
            public ProductBrandId BrandId;
            public string ProductName;
            public string Size;
            public string Model;
            public string VendorCode;
            public decimal EachCost;
            public decimal CaseCost;
            public int CaseSize;
        }
    }

}
