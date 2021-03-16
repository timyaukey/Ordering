using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Willowsoft.WillowLib.Data.Entity;
using Willowsoft.WillowLib.Data.Misc;
using Willowsoft.WillowLib.Data.Sql;
using Willowsoft.Ordering.Core.Entities;
using Willowsoft.Ordering.Core.Repositories;

namespace Willowsoft.Ordering.UI.SetupForms
{
    public partial class ImportAddProductForm : Form
    {
        private VendorId mVendorId;
        private List<ProductSubCategory> mAllowedSubcategories;
        private string mImportLine;

        public ImportAddProductForm()
        {
            InitializeComponent();
        }

        public string GetImportLine(VendorId vendorId, List<ProductSubCategory> allowedSubcategories)
        {
            mVendorId = vendorId;
            mAllowedSubcategories = allowedSubcategories;
            mImportLine = null;
            using (Ambient.DbSession.Activate())
            {
                cboBrandName.Items.Clear();
                foreach (ProductBrand brand in OrderingRepositories.ProductBrand.GetAll())
                {
                    cboBrandName.Items.Add(brand.BrandName);
                }
            }
            cboSubcategory.Items.Clear();
            foreach (ProductSubCategory subCat in mAllowedSubcategories)
            {
                cboSubcategory.Items.Add(subCat.SubCategoryName);
            }
            this.ShowDialog();
            return mImportLine;
        }

        private void txtVendorCode_Leave(object sender, EventArgs e)
        {
            using (Ambient.DbSession.Activate())
            {
                List<VendorProduct> vendorProducts =
                    OrderingRepositories.VendorProduct.Get(mVendorId, txtVendorCode.Text);
                if (vendorProducts.Count > 0)
                {
                    Product product = OrderingRepositories.Product.Get(vendorProducts[0].ProductId);
                    MessageBox.Show(string.Format("Vendor code is already used, for product \"{0}\".",
                        product.ProductName));
                }
            }
        }

        private void btnOkay_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtProductName.Text))
            {
                MessageBox.Show("Product name is required.");
                return;
            }
            if (string.IsNullOrEmpty(txtVendorCode.Text))
            {
                MessageBox.Show("Vendor code is required.");
                return;
            }
            if (string.IsNullOrEmpty(cboBrandName.Text))
            {
                MessageBox.Show("Brand name is required.");
                return;
            }
            if (string.IsNullOrEmpty(cboSubcategory.Text))
            {
                MessageBox.Show("Subcategory is required.");
                return;
            }
            mImportLine = txtProductName.Text + "\t" +
                txtSize.Text + "\t" +
                txtVendorCode.Text + "\t" +
                (string.IsNullOrEmpty(txtRetailPrice.Text) ? "0" : txtRetailPrice.Text) + "\t" +
                (string.IsNullOrEmpty(txtCaseCost.Text) ? "0" : txtCaseCost.Text) + "\t" +
                (string.IsNullOrEmpty(txtCaseSize.Text) ? "0" : txtCaseSize.Text) + "\t" +
                (string.IsNullOrEmpty(txtEachCost.Text) ? "0" : txtEachCost.Text) + "\t" +
                cboBrandName.Text + "\t" +
                cboSubcategory.Text + "\t" +
                (chkIsActive.Checked ? "Y" : "N") + "\t" +
                txtBarcode.Text + "\t" +
                txtModel.Text;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
