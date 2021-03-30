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
        private Dictionary<string, JoinPlToVpToProd> mPurLineDictionary;
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

        public void Show(VendorId vendorId, PurOrderId purOrderId,
            PersistedBindingList<JoinPlToVpToProd> purLines,
            List<ProductSubCategory> subCats,
            List<ProductBrand> brands)
        {
            mVendorId = vendorId;
            mOrderId = purOrderId;
            mPurLines = purLines;
            mPurLineDictionary = new Dictionary<string, JoinPlToVpToProd>();
            foreach(JoinPlToVpToProd purLine in mPurLines)
            {
                if (!string.IsNullOrEmpty(purLine.PurLine_VendorPartNum))
                    mPurLineDictionary.Add(purLine.PurLine_VendorPartNum, purLine);
            }
            mSubCats = subCats;
            mBrands = brands;
            this.ShowDialog();
        }

        private void ImportPurLineForm_Load(object sender, EventArgs e)
        {
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
                FindColumnName(PurLineForm.ColNameOnHand, colNames, out mColQtyOnHand);
                if (!TryFindRequiredColumnName(PurLineForm.ColNameSubCategory, colNames, out mColSubCategory)) return;
                if (!TryFindRequiredColumnName(PurLineForm.ColNameBrand, colNames, out mColBrand)) return;
                if (!TryFindRequiredColumnName(PurLineForm.ColNameProduct, colNames, out mColProductName)) return;
                if (!TryFindRequiredColumnName(PurLineForm.ColNameSize, colNames, out mColSize)) return;
                FindColumnName(PurLineForm.ColNameModel, colNames, out mColModel);
                if (!TryFindRequiredColumnName(PurLineForm.ColNameVendorCode, colNames, out mColVendorCode)) return;
                FindColumnName(PurLineForm.ColNameOrdered, colNames, out mColQtyOrdered);
                FindColumnName(PurLineForm.ColNameOrderEaches, colNames, out mColOrderEaches);
                FindColumnName(PurLineForm.ColNameEachCost, colNames, out mColEachCost);
                FindColumnName(PurLineForm.ColNameCaseCost, colNames, out mColCaseCost);
                FindColumnName(PurLineForm.ColNameCaseSize, colNames, out mColCaseSize);

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
                    importedLine.BrandId = brand.Id;
                    
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
            int linesAdded = 0;
            int invalidPartNumbers = 0;
            if (MessageBox.Show("Are you sure you want to create order lines?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) != DialogResult.OK)
                return;
            if (mColQtyOrdered == MissingColumn)
            {
                MessageBox.Show(string.Format("Cannot create order lines, because import data does not contain \"{0}\" column.", PurLineForm.ColNameOrdered));
                return;
            }
            if (mColOrderEaches == MissingColumn)
            {
                MessageBox.Show(string.Format("Cannot create order lines, because import data does not contain \"{0}\" column.", PurLineForm.ColNameOrderEaches));
                return;
            }
            using (Ambient.DbSession.Activate())
            {
                foreach (var importLine in mImportedLines)
                {
                    if (!mPurLineDictionary.TryGetValue(importLine.VendorCode, out var purJoinLine))
                    {
                        List<VendorProduct> vendorProducts = OrderingRepositories.VendorProduct.Get(mVendorId, importLine.VendorCode);
                        if (vendorProducts.Count == 1)
                        {
                            VendorProduct vendorProduct = vendorProducts[0];
                            Product product = OrderingRepositories.Product.Get(vendorProduct.ProductId);
                            PurLine purLine = new PurLine(
                                Id_: new PurLineId(), 
                                PurOrderId_: mOrderId, 
                                VendorProductId_: vendorProduct.Id, 
                                CaseCostOverride_: 0M, 
                                EachCostOverride_: 0M, 
                                OrderedEaches_: importLine.OrderEaches,
                                QtyOrdered_: importLine.QtyOrd, 
                                QtyReceived_: 0, 
                                QtyBackordered_: 0, 
                                QtyDamaged_: 0, 
                                QtyMissing_: 0, 
                                QtyOnHand_: importLine.OnHand, 
                                SpecialOrder_: false, 
                                Notes_: string.Empty,
                                ProductName_: product.ProductName, 
                                ProductSubCategoryId_: product.ProductSubCategoryId, 
                                Size_: product.Size, 
                                RetailPrice_: product.RetailPrice,
                                ProductBrandId_: product.ProductBrandId, 
                                ManufacturerBarcode_: product.ManufacturerBarcode, 
                                ManufacturerPartNum_: product.ManufacturerPartNum,
                                ShelfOrder_: vendorProduct.ShelfOrder,
                                RetailPriceOverride_: vendorProduct.RetailPriceOverride, 
                                VendorPartNum_: importLine.VendorCode, 
                                CaseCost_: importLine.CaseCost,
                                CountInCase_: importLine.CaseSize, 
                                EachCost_: importLine.EachCost,
                                PreferredSource_: vendorProduct.PreferredSource,
                                WholeCasesOnly_: vendorProduct.WholeCasesOnly, 
                                CreateDate_:DateTime.Now, 
                                ModifyDate_: DateTime.Now);
                            OrderingRepositories.PurLine.Insert(purLine);
                            linesAdded++;
                        }
                        else if (vendorProducts.Count == 0)
                        {
                            // What about incorrectly formatted vendor part numbers?
                            PurLine purLine = new PurLine(
                                Id_: new PurLineId(),
                                PurOrderId_: mOrderId,
                                VendorProductId_: new VendorProductId(),
                                CaseCostOverride_: 0M,
                                EachCostOverride_: 0M,
                                OrderedEaches_: importLine.OrderEaches,
                                QtyOrdered_: importLine.QtyOrd,
                                QtyReceived_: 0,
                                QtyBackordered_: 0,
                                QtyDamaged_: 0,
                                QtyMissing_: 0,
                                QtyOnHand_: importLine.OnHand,
                                SpecialOrder_: false,
                                Notes_: string.Empty,
                                ProductName_: importLine.ProductName,
                                ProductSubCategoryId_: importLine.SubCategoryId,
                                Size_: importLine.Size,
                                RetailPrice_: 0M,
                                ProductBrandId_: importLine.BrandId,
                                ManufacturerBarcode_: string.Empty,
                                ManufacturerPartNum_: importLine.Model,
                                ShelfOrder_: string.Empty,
                                RetailPriceOverride_: 0M,
                                VendorPartNum_: importLine.VendorCode,
                                CaseCost_: importLine.CaseCost,
                                CountInCase_: importLine.CaseSize,
                                EachCost_: importLine.EachCost,
                                PreferredSource_: false,
                                WholeCasesOnly_: false,
                                CreateDate_: DateTime.Now,
                                ModifyDate_: DateTime.Now);
                            OrderingRepositories.PurLine.Insert(purLine);
                            linesAdded++;
                        }
                        else
                        {
                            MessageBox.Show(string.Format("Multiple definitions for vendor product {0} {1}", importLine.VendorCode, importLine.ProductName));
                            invalidPartNumbers++;
                        }
                    }
                    else
                    {
                        MessageBox.Show(string.Format("Order already includes a line for {0} {1}", importLine.VendorCode, importLine.ProductName));
                    }
                }
            }
            MessageBox.Show(string.Format("Added {0} order lines, and skipped {1} lines.", linesAdded, invalidPartNumbers));
            this.Close();
        }

        private void btnUpdateQuantities_Click(object sender, EventArgs e)
        {
            int linesUpdated = 0;
            int linesSkipped = 0;
            if (MessageBox.Show("Are you sure you want to update order quantities?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) != DialogResult.OK)
                return;
            if (mColQtyOnHand == MissingColumn && mColQtyOrdered == MissingColumn)
            {
                MessageBox.Show(string.Format("Cannot update quantities, because the imported " +
                    "data does not contain either \"{0}\" or \"{1}\" columns to update from.",
                    PurLineForm.ColNameOrdered, PurLineForm.ColNameOnHand));
                return;
            }
            using (Ambient.DbSession.Activate())
            {
                foreach (var importLine in mImportedLines)
                {
                    if (mPurLineDictionary.TryGetValue(importLine.VendorCode, out var purJoinLine))
                    {
                        PurLine purLine = purJoinLine.InnerPurLine;
                        if (mColQtyOnHand != MissingColumn)
                            purLine.QtyOnHand = importLine.OnHand;
                        if (mColQtyOrdered != MissingColumn)
                            purLine.QtyOrdered = importLine.QtyOrd;
                        OrderingRepositories.PurLine.Update(purLine);
                        linesUpdated++;
                    }
                    else
                    {
                        MessageBox.Show(string.Format("Order does not contain a line for {0} {1}", importLine.VendorCode, importLine.ProductName));
                        linesSkipped++;
                    }
                }
            }
            MessageBox.Show(string.Format("Updated {0} lines, skipped {1} lines.", linesUpdated, linesSkipped));
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
