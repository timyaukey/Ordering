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
    public partial class ImportPurLineForm : Form
    {
        private VendorId mVendorId;
        private PurOrderId mOrderId;

        public ImportPurLineForm()
        {
            InitializeComponent();
        }

        public void Show(VendorId vendorId, PurOrderId purOrderId)
        {
            mVendorId = vendorId;
            mOrderId = purOrderId;
            this.ShowDialog();
        }

        private void ImportPurLineForm_Load(object sender, EventArgs e)
        {
            using (Ambient.DbSession.Activate())
            {
                List<ProductSubCategory> subCats = OrderingRepositories.ProductSubCategory.GetAll();
                cboDefaultSubCat.DataSource = subCats;
                cboDefaultSubCat.SelectedItem = null;

                List<ProductBrand> brands = OrderingRepositories.ProductBrand.GetAll();
                cboDefaultBrand.DataSource = brands;
                cboDefaultBrand.SelectedItem = null;

                List<IFileImporter> formats = new List<IFileImporter>();
                formats.Add(new ImportPurLineForm.Horizon());
                formats.Add(new ImportPurLineForm.LLSupply());
                cboFileFormat.DataSource = formats;
                cboFileFormat.SelectedItem = null;
            }
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            if (dlgSelectFile.ShowDialog() == DialogResult.OK)
            {
                lblSelectedFile.Text = dlgSelectFile.FileName;
            }
        }

        private void btnImportFile_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblSelectedFile.Text))
            {
                MessageBox.Show("Please select a file first.");
                return;
            }
            if (cboDefaultSubCat.SelectedItem == null)
            {
                MessageBox.Show("Please select a subcategory first.");
                return;
            }
            ProductSubCategoryId subCatId = ((ProductSubCategory)cboDefaultSubCat.SelectedItem).Id;

            if (cboDefaultBrand.SelectedItem == null)
            {
                MessageBox.Show("Please select a brand first.");
                return;
            }
            ProductBrandId brandId = ((ProductBrand)cboDefaultBrand.SelectedItem).Id;
            
            if (cboFileFormat.SelectedItem == null)
            {
                MessageBox.Show("Please select a file format first.");
                return;
            }
            IFileImporter importer = (IFileImporter)cboFileFormat.SelectedItem;
            using (StreamReader input = new StreamReader(lblSelectedFile.Text))
            {
                PurLine purLine;
                int importCount = 0;
                int productCount = 0;
                importer.Init(input, subCatId, brandId);
                while(importer.GetPurLine(input, out purLine))
                {
                    if (purLine != null)
                    {
                        purLine.PurOrderId = mOrderId;
                        importCount++;
                        using (Ambient.DbSession.Activate())
                        {
                            List<VendorProduct> matchingVPs = OrderingRepositories.VendorProduct.Get(mVendorId, purLine.VendorPartNum);
                            if (matchingVPs.Count > 0)
                                purLine.VendorProductId = matchingVPs[0].Id;
                            else
                                productCount++;
                            OrderingRepositories.PurLine.Insert(purLine);
                        }
                    }
                }
                MessageBox.Show("Created " + importCount.ToString() + 
                    " order line items, of which " + productCount.ToString() + " are for new products. " +
                    "Use \"Create Products\" to turn these order lines into products.");
            }
            this.Close();
        }

        private interface IFileImporter
        {
            void Init(TextReader input, ProductSubCategoryId defaultSubCatId, ProductBrandId defaultBrandId);
            bool GetPurLine(TextReader input, out PurLine purLine);
        }

        private class Horizon : IFileImporter
        {
            private ProductSubCategoryId mSubCatId;
            private ProductBrandId mBrandId;
            private Dictionary<string, ProductBrandId> mBarcodeBrands;

            public override string ToString()
            {
                return "Horizon Distribution";
            }

            public void Init(TextReader input, ProductSubCategoryId defaultSubCatId, ProductBrandId defaultBrandId)
            {
                mSubCatId = defaultSubCatId;
                mBrandId = defaultBrandId;
                mBarcodeBrands = new Dictionary<string, ProductBrandId>();
                using (Ambient.DbSession.Activate())
                {
                    foreach (ProductBrand brand in OrderingRepositories.ProductBrand.GetAll())
                    {
                        if (!string.IsNullOrEmpty(brand.BarcodePrefix))
                        {
                            if (!mBarcodeBrands.ContainsKey(brand.BarcodePrefix))
                                mBarcodeBrands[brand.BarcodePrefix] = brand.Id;
                        }
                    }
                }
                input.ReadLine();
            }

            public bool GetPurLine(TextReader input, out PurLine purLine)
            {
                purLine = new PurLine();
                string line = input.ReadLine();
                if (line == null)
                    return false;
                string[] parts = line.Split(',');
                purLine.VendorPartNum = parts[0].Substring(0,4) + "-" + parts[0].Substring(4,4) + "-" + parts[0].Substring(8);
                purLine.ManufacturerBarcode = parts[1];
                purLine.ProductName = parts[3];
                double qtyOrdered;
                double.TryParse(parts[4], out qtyOrdered);
                purLine.QtyOrdered = (int)qtyOrdered;
                double eachCost;
                double.TryParse(parts[7], out eachCost);
                purLine.EachCost = (decimal)eachCost;
                purLine.OrderedEaches = true;
                purLine.PreferredSource = true;
                purLine.ProductSubCategoryId = mSubCatId;
                ProductBrandId matchedBrandId;
                if (mBarcodeBrands.TryGetValue(purLine.ManufacturerBarcode.Substring(0, 6), out matchedBrandId))
                    purLine.ProductBrandId = matchedBrandId;
                else
                    purLine.ProductBrandId = mBrandId;
                return true;
            }
        }

        private class LLSupply : IFileImporter
        {
            public override string ToString()
            {
                return "L & L Supply";
            }

            public void Init(TextReader input, ProductSubCategoryId defaultSubCatId, ProductBrandId defaultBrandId)
            {
            }

            public bool GetPurLine(TextReader input, out PurLine purLine)
            {
                purLine = null;
                return false;
            }
        }
    }
}
