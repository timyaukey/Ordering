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
        private List<ProductSubCategory> mAllSubcategories;
        List<ProductBrand> mBrands;
        List<NewProductData> mProductDataToSave;

        public ImportProductsForm()
        {
            InitializeComponent();
        }

        public void Show(Vendor vendor, List<ProductSubCategory> allSubcategories)
        {
            mVendor = vendor;
            mAllSubcategories = allSubcategories;
            lblVendor.Text = "Vendor: " + vendor.VendorName;
            if (ParseInput())
                return;
            this.ShowDialog();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            foreach (NewProductData rec in mProductDataToSave)
            {
                using (Ambient.DbSession.Activate())
                {
                    List<VendorProduct> partNumMatches = OrderingRepositories.VendorProduct.Get(
                        mVendor.Id, rec.VendorProduct.VendorPartNum);
                    if (partNumMatches.Count > 0)
                    {
                        MessageBox.Show(string.Format("Vendor code {0} already exists in database.",
                            rec.VendorProduct.VendorPartNum));
                        return;
                    }
                    if (!rec.Product.ProductBrandId.IsNull)
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
            foreach (NewProductData objToSave in mProductDataToSave)
            {
                using (ITranScope tranScope = Ambient.DbSession.CreateTranScope())
                {
                    using (IDbSession session = Ambient.DbSession.Activate())
                    {
                        OrderingRepositories.Product.Insert(objToSave.Product);
                        objToSave.VendorProduct.ProductId = objToSave.Product.Id;
                        OrderingRepositories.VendorProduct.Insert(objToSave.VendorProduct);
                    }
                    tranScope.Complete();
                    recordsCreated++;
                }
                //MessageBox.Show(string.Format("Create {0} {1} {2}",
                //    objToSave.Product.ProductName, objToSave.Product.Size, objToSave.VendorProduct.VendorPartNum));
            }
            MessageBox.Show(string.Format("{0} products created", recordsCreated));
        }

        private bool ParseInput()
        {
            
            StringReader reader = new StringReader(System.Windows.Forms.Clipboard.GetText());
            mProductDataToSave = new List<NewProductData>();
            using (Ambient.DbSession.Activate())
            {
                mBrands = OrderingRepositories.ProductBrand.GetAll();
            }
            int lineNumber = 0;
            for (; ; )
            {
                string line = reader.ReadLine();
                if (string.IsNullOrEmpty(line))
                    break;
                lineNumber++;
                string[] fields = line.Split('\t');
                if (TryProcessFields(fields, lineNumber))
                    return true;
            }
            return false;
        }

        private bool TryProcessFields(string[] fields, int lineNumber)
        {
            if (fields.Length != 10)
            {
                MessageBox.Show(string.Format("Wrong number of fields on line {0}", lineNumber));
                return true;
            }
            if (ValidateString("Product name", fields[0], 4, 100, lineNumber))
                return true;
            if (ValidateString("Product size", fields[1], 0, 30, lineNumber))
                return true;
            if (ValidateString("Vendor code", fields[2], 1, 30, lineNumber))
                return true;
            decimal retailPrice;
            if (ValidateDecimal("Retail price", fields[3], out retailPrice, lineNumber))
                return true;
            decimal caseCost;
            if (ValidateDecimal("Case cost", fields[4], out caseCost, lineNumber))
                return true;
            int countInCase;
            if (ValidateInt("Count in case", fields[5], out countInCase, lineNumber))
                return true;
            decimal eachCost;
            if (ValidateDecimal("Each cost", fields[6], out eachCost, lineNumber))
                return true;
            string brandName = fields[7];
            if (ValidateString("Brand name", brandName, 3, 80, lineNumber))
                return true;
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
                    return true;
                brandToUse = new ProductBrand(new ProductBrandId(), brandName, string.Empty, true, string.Empty,
                    DateTime.Now, DateTime.Now);
                mBrands.Add(brandToUse);
            }
            ProductSubCategory subCatToUse = null;
            string subCatName = fields[8];
            foreach (ProductSubCategory subCat in mAllSubcategories)
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
                return true;
            }
            bool isActive;
            if (fields[9].ToUpper() == "Y")
                isActive = true;
            else if (fields[9].ToUpper() == "N")
                isActive = false;
            else
            {
                MessageBox.Show(string.Format("Invalid active flag on line {0}", lineNumber));
                return true;
            }
            NewProductData rec = new NewProductData();
            rec.Product = new Product(new ProductId(), fields[0], subCatToUse.Id, fields[1],
                retailPrice, brandToUse.Id, string.Empty, string.Empty, isActive,
                false, false, false, false, 0, 0, 0, 0, string.Empty, 0.0m, 0.0m, DateTime.Now, DateTime.Now);
            rec.VendorProduct = new VendorProduct(new VendorProductId(), mVendor.Id, new ProductId(),
                0m, fields[2], caseCost, countInCase, eachCost, isActive, isActive,
                false, false, new DateTime(1980, 1, 1), string.Empty, false, false, string.Empty,
                DateTime.Now, DateTime.Now);
            rec.BrandName = brandName;
            mProductDataToSave.Add(rec);
            ShowNewProductData(rec);
            return false;
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
            string importLine = enterForm.GetImportLine(mVendor.Id, mAllSubcategories);
            if (!string.IsNullOrEmpty(importLine))
            {
                TryProcessFields(importLine.Split('\t'), 1);
            }
        }

        private void ShowNewProductData(NewProductData newProd)
        {
            ListViewItem item = new ListViewItem(new string[] {
                newProd.Product.ProductName,
                newProd.Product.Size,
                newProd.VendorProduct.VendorPartNum,
                newProd.Product.RetailPrice.ToString("C2"),
                newProd.VendorProduct.CaseCost.ToString("C2"),
                newProd.VendorProduct.CountInCase.ToString(),
                newProd.VendorProduct.EachCost.ToString("C2"),
                newProd.BrandName,
                mAllSubcategories.Find(subcat=>newProd.Product.ProductSubCategoryId==subcat.Id).SubCategoryName,
                newProd.Product.IsActive.ToString()
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
