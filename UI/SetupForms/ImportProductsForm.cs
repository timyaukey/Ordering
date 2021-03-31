using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Willowsoft.WillowLib.Data.Entity;
using Willowsoft.WillowLib.Data.Misc;
using Willowsoft.WillowLib.Data.Sql;
using Willowsoft.Ordering.Core.Entities;
using Willowsoft.Ordering.Core.Repositories;
using Willowsoft.Ordering.UI.Helpers;

namespace Willowsoft.Ordering.UI.SetupForms
{
    public partial class ImportProductsForm : Form
    {
        private Vendor mVendor;
        private List<ProductSubCategory> mAllowedSubcategories;
        private List<ProductBrand> mBrands;
        private List<NewProductData> mProductDataToSave;

        private int mColProductName;
        private int mColProductSize;
        private int mColVendorCode;
        private int mColRetail;
        private int mColCsCost;
        private int mColCsSize;
        private int mColEaCost;
        private int mColBrand;
        private int mColSubcategory;
        private int mColIsActive;
        private int mColBarcode;
        private int mColModel;

        public ImportProductsForm()
        {
            InitializeComponent();
        }

        public void Show(Vendor vendor, List<ProductSubCategory> allowedSubcategories)
        {
            mVendor = vendor;
            lblVendor.Text = "Vendor: " + vendor.VendorName;
            mAllowedSubcategories = allowedSubcategories;
            using (Ambient.DbSession.Activate())
            {
                mBrands = OrderingRepositories.ProductBrand.GetAll();
            }
            this.ShowDialog();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) != DialogResult.OK)
                return;
            foreach (NewProductData rec in mProductDataToSave)
            {
                using (Ambient.DbSession.Activate())
                {
                    if (!rec.Product.ProductBrandId.IsNull)
                    {
                        List<VendorProduct> partNumMatches = OrderingRepositories.VendorProduct.Get(
                            mVendor.Id, rec.VendorProduct.VendorPartNum);
                        if (partNumMatches.Count == 0)
                        {
                            List<Product> brandNameSizeMatches = OrderingRepositories.Product.Get(
                                rec.Product.ProductBrandId, rec.Product.ProductName, rec.Product.Size);
                            if (brandNameSizeMatches.Count > 0)
                            {
                                MessageBox.Show(string.Format(
                                    "Product name \"{0}\", brand \"{1}\" and size \"{2}\" already exists in database.",
                                    rec.Product.ProductName, rec.BrandName, rec.Product.Size));
                                return;
                            }
                        }
                    }
                }
                foreach (NewProductData otherRecord in mProductDataToSave)
                {
                    if (otherRecord != rec)
                    {
                        if (otherRecord.VendorProduct.VendorPartNum == rec.VendorProduct.VendorPartNum)
                        {
                            MessageBox.Show(string.Format("Vendor code {0} exists multiple times in input.",
                                rec.VendorProduct.VendorPartNum));
                            return;
                        }
                        if (otherRecord.Product.ProductName == rec.Product.ProductName)
                        {
                            if (otherRecord.BrandName == rec.BrandName)
                            {
                                if (otherRecord.Product.Size == rec.Product.Size)
                                {
                                    MessageBox.Show(string.Format(
                                        "Product name \"{0}\", brand \"{1}\" and size \"{2}\" exists multiple times in input.",
                                        rec.Product.ProductName, rec.BrandName, rec.Product.Size));
                                    return;
                                }
                            }
                        }
                    }
                }
            }
            foreach (ProductBrand brand in mBrands)
            {
                if (!brand.IsPersisted)
                {
                    using (Ambient.DbSession.Activate())
                    {
                        OrderingRepositories.ProductBrand.Insert(brand);
                    }
                }
            }
            int recordsCreated = 0;
            int recordsUpdated = 0;
            foreach (NewProductData objToSave in mProductDataToSave)
            {
                using (ITranScope tranScope = Ambient.DbSession.CreateTranScope())
                {
                    using (IDbSession session = Ambient.DbSession.Activate())
                    {
                        List<VendorProduct> partNumMatches = OrderingRepositories.VendorProduct.Get(
                            mVendor.Id, objToSave.VendorProduct.VendorPartNum);
                        if (partNumMatches.Count == 1)
                        {
                            VendorProduct venProdToUpdate = partNumMatches[0];
                            venProdToUpdate.EachCost = objToSave.VendorProduct.EachCost;
                            venProdToUpdate.CaseCost = objToSave.VendorProduct.CaseCost;
                            venProdToUpdate.CountInCase = objToSave.VendorProduct.CountInCase;
                            OrderingRepositories.VendorProduct.Update(venProdToUpdate);

                            Product prodToUpdate = OrderingRepositories.Product.Get(venProdToUpdate.ProductId);
                            prodToUpdate.ProductName = objToSave.Product.ProductName;
                            prodToUpdate.Size = objToSave.Product.Size;
                            prodToUpdate.RetailPrice = objToSave.Product.RetailPrice;
                            prodToUpdate.ProductBrandId = objToSave.Product.ProductBrandId;
                            prodToUpdate.ProductSubCategoryId = objToSave.Product.ProductSubCategoryId;
                            prodToUpdate.ManufacturerBarcode = objToSave.Product.ManufacturerBarcode;
                            prodToUpdate.ManufacturerPartNum = objToSave.Product.ManufacturerPartNum;
                            OrderingRepositories.Product.Update(prodToUpdate);

                            recordsUpdated++;
                        }
                        else if (partNumMatches.Count == 0)
                        {
                            OrderingRepositories.Product.Insert(objToSave.Product);
                            objToSave.VendorProduct.ProductId = objToSave.Product.Id;
                            OrderingRepositories.VendorProduct.Insert(objToSave.VendorProduct);
                            recordsCreated++;
                        }
                        else
                        {
                            MessageBox.Show("Multiple matches to vendor part number " + objToSave.VendorProduct.VendorPartNum);
                        }
                    }
                    tranScope.Complete();
                }
            }
            MessageBox.Show(string.Format("{0} products created, {1} updated.", recordsCreated, recordsUpdated));
            btnCreate.Enabled = false;
            btnEnter.Enabled = false;
            btnReadClipboard.Enabled = false;
        }

        private void btnReadClipboard_Click(object sender, EventArgs e)
        {
            lvwNewProducts.Items.Clear();
            StringReader reader = new StringReader(System.Windows.Forms.Clipboard.GetText());
            string headerLine = reader.ReadLine();
            string[] headerNames = headerLine.Split('\t');
            if (!TryFindColumn(headerNames, "Name", out mColProductName)) return;
            if (!TryFindColumn(headerNames, "Size", out mColProductSize)) return;
            if (!TryFindColumn(headerNames, "Vendor Code", out mColVendorCode)) return;
            if (!TryFindColumn(headerNames, "Retail", out mColRetail)) return;
            if (!TryFindColumn(headerNames, "Cs Cost", out mColCsCost)) return;
            if (!TryFindColumn(headerNames, "Cs Size", out mColCsSize)) return;
            if (!TryFindColumn(headerNames, "Ea Cost", out mColEaCost)) return;
            if (!TryFindColumn(headerNames, "Brand", out mColBrand)) return;
            if (!TryFindColumn(headerNames, "Subcategory", out mColSubcategory)) return;
            if (!TryFindColumn(headerNames, "Is Active", out mColIsActive)) return;
            if (!TryFindColumn(headerNames, "Barcode", out mColBarcode)) return;
            if (!TryFindColumn(headerNames, "Model", out mColModel)) return;
            mProductDataToSave = new List<NewProductData>();
            int lineNumber = 0;
            int errorCount = 0;
            const int maxErrors = 10;
            for (; ; )
            {
                string line = reader.ReadLine();
                if (string.IsNullOrEmpty(line))
                    break;
                lineNumber++;
                string[] fields = line.Split('\t');
                if (!TryProcessFields(fields, lineNumber))
                {
                    if (++errorCount > maxErrors)
                    {
                        MessageBox.Show("Stopping after " + maxErrors.ToString() + " errors", "Stopping",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }

        private bool TryFindColumn(string[] columnNames, string columnName, out int colIndex)
        {
            for (int testIdx=0;testIdx<columnNames.Length;testIdx++)
            {
                if (columnNames[testIdx] == columnName)
                {
                    colIndex = testIdx;
                    return true;
                }
            }
            colIndex = -1;
            MessageBox.Show("Cannot find input column header named \"" + columnName + "\"");
            return false;
        }

        private bool TryProcessFields(string[] fields, int lineNumber)
        {
            if (fields.Length < 10)
            {
                MessageBox.Show(string.Format("Not enough fields on line {0}", lineNumber));
                return false;
            }
            string productName = GetInputColumn(fields, mColProductName).Trim();
            if (ValidateString("Product name", productName, 4, 100, lineNumber))
                return false;
            string productSize = GetInputColumn(fields, mColProductSize).Trim();
            if (ValidateString("Product size", productSize, 0, 30, lineNumber))
                return false;
            string vendorCode = GetInputColumn(fields, mColVendorCode).Trim();
            if (vendorCode.StartsWith("#"))
                vendorCode = vendorCode.Substring(1);
            if (ValidateString("Vendor code", vendorCode, 1, 30, lineNumber))
                return false;
            decimal retailPrice;
            if (ValidateDecimal("Retail price", GetInputColumn(fields, mColRetail), out retailPrice, lineNumber))
                return false;
            decimal caseCost;
            if (ValidateDecimal("Case cost", GetInputColumn(fields, mColCsCost), out caseCost, lineNumber))
                return false;
            int countInCase;
            if (ValidateInt("Count in case", GetInputColumn(fields, mColCsSize), out countInCase, lineNumber))
                return false;
            decimal eachCost;
            if (ValidateDecimal("Each cost", GetInputColumn(fields, mColEaCost), out eachCost, lineNumber))
                return false;
            
            // Brand
            string brandName = GetInputColumn(fields, mColBrand).Trim();
            if (ValidateString("Brand name", brandName, 3, 80, lineNumber))
                return false;
            ProductBrand brandToUse = null;
            foreach (ProductBrand existingBrand in mBrands)
            {
                if (NormalizeBrandName(existingBrand.BrandName).Equals(
                    NormalizeBrandName(brandName), StringComparison.OrdinalIgnoreCase))
                {
                    brandToUse = existingBrand;
                    break;
                }
            }
            if (brandToUse == null)
            {
                DialogResult newBrandAnswer = MessageBox.Show(string.Format(
                    "Brand name \"{0}\" not found. Do you want to create it?", brandName),
                    "New Brand Name", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (newBrandAnswer != DialogResult.Yes)
                    return false;
                brandToUse = new ProductBrand(new ProductBrandId(), brandName, string.Empty, true, string.Empty,
                    DateTime.Now, DateTime.Now);
                mBrands.Add(brandToUse);
            }

            // Subcategory
            ProductSubCategory subCatToUse = null;
            string subCatName = GetInputColumn(fields, mColSubcategory);
            foreach (ProductSubCategory subCat in mAllowedSubcategories)
            {
                if (subCat.SubCategoryName.Equals(subCatName, StringComparison.OrdinalIgnoreCase))
                {
                    subCatToUse = subCat;
                    break;
                }
            }
            if (subCatToUse == null)
            {
                MessageBox.Show(string.Format("Subcategory \"{0}\" not found.", subCatName),
                    "No such subcategory", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // IsActive
            string isActiveText = GetInputColumn(fields, mColIsActive).ToUpper();
            bool isActive;
            if (isActiveText == "Y")
                isActive = true;
            else if (isActiveText == "N")
                isActive = false;
            else
            {
                MessageBox.Show(string.Format("Invalid active flag on line {0}", lineNumber));
                return false;
            }
            
            // Barcode
            string barcode =GetInputColumn(fields, mColBarcode);
            if (ValidateString("Barcode", barcode, 0, 30, lineNumber))
                return false;

            // Model
            string model = GetInputColumn(fields, mColModel);
            if (ValidateString("Model", model, 0, 30, lineNumber))
                return false;

            NewProductData rec = new NewProductData();
            rec.Product = new Product(new ProductId(), productName, subCatToUse.Id, productSize,
                retailPrice, brandToUse.Id, barcode, model, isActive,
                false, false, false, false, 0, 0, 0, 0, string.Empty, 0.0m, 0.0m, DateTime.Now, DateTime.Now);
            rec.VendorProduct = new VendorProduct(new VendorProductId(), mVendor.Id, new ProductId(),
                0m, vendorCode, caseCost, countInCase, eachCost, isActive, isActive,
                false, false, new DateTime(1980, 1, 1), string.Empty, false, false, string.Empty,
                DateTime.Now, DateTime.Now);
            rec.BrandName = brandName;
            mProductDataToSave.Add(rec);
            ShowNewProductData(rec);
            return true;
        }

        private string GetInputColumn(string[] colValues, int colIndex)
        {
            if (colIndex < colValues.Length)
                return colValues[colIndex];
            return string.Empty;
        }

        private bool ValidateString(string fieldName, string value, int minLength, int maxLength, int lineNumber)
        {
            if (value.Length < minLength)
            {
                MessageBox.Show(string.Format("{0} too short on line {1}", fieldName, lineNumber));
                return true;
            }
            if (value.Length > maxLength)
            {
                MessageBox.Show(string.Format("{0} too long on line {1}", fieldName, lineNumber));
                return true;
            }
            return false;
        }

        private string NormalizeBrandName(string input)
        {
            return input.Replace(" ", string.Empty).Replace("'", string.Empty).Replace(
                "&", string.Empty).Replace("/", string.Empty);
        }

        private bool ValidateDecimal(string fieldName, string value, out decimal decimalValue, int lineNumber)
        {
            if (decimal.TryParse(value, out decimalValue))
                return false;
            MessageBox.Show(string.Format("Invalid {0} on line {1}", fieldName, lineNumber));
            return true;
        }

        private bool ValidateInt(string fieldName, string value, out int intValue, int lineNumber)
        {
            if (int.TryParse(value, out intValue))
                return false;
            MessageBox.Show(string.Format("Invalid {0} on line {1}", fieldName, lineNumber));
            return true;
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            ImportAddProductForm enterForm = new ImportAddProductForm();
            string importLine = enterForm.GetImportLine(mVendor.Id, mAllowedSubcategories);
            if (!string.IsNullOrEmpty(importLine))
            {
                if (mProductDataToSave == null)
                    mProductDataToSave = new List<NewProductData>();
                TryProcessFields(importLine.Split('\t'), 1);
            }
        }

        private void ShowNewProductData(NewProductData newProd)
        {
            ListViewItem item = new ListViewItem(new string[] {
                mAllowedSubcategories.Find(subcat=>newProd.Product.ProductSubCategoryId==subcat.Id).SubCategoryName,
                newProd.BrandName,
                newProd.Product.ProductName,
                newProd.Product.Size,
                newProd.Product.ManufacturerPartNum,
                newProd.VendorProduct.VendorPartNum,
                newProd.Product.RetailPrice.ToString("C2"),
                newProd.VendorProduct.EachCost.ToString("C2"),
                newProd.VendorProduct.CaseCost.ToString("C2"),
                newProd.VendorProduct.CountInCase.ToString(),
                newProd.Product.IsActive.ToString(),
                newProd.Product.ManufacturerBarcode
            });
            lvwNewProducts.Items.Add(item);
        }
    }

    internal class NewProductData
    {
        public Product Product;
        public VendorProduct VendorProduct;
        public string BrandName;
    }
}
