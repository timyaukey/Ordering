using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Willowsoft.WillowLib.Data.Misc;
using Willowsoft.Ordering.Core.Entities;
using Willowsoft.Ordering.Core.Repositories;

namespace Willowsoft.Ordering.UI.SetupForms
{
    public partial class UseExistingProductForm : Form
    {
        private ProductCategory mCategory;
        private ProductBrand mBrand;
        private List<ProductSubCategory> mAllSubCategories;
        private Product mSelectedProduct;

        public UseExistingProductForm()
        {
            InitializeComponent();
        }

        public Product Show(ProductCategory category, ProductBrand brand, List<ProductSubCategory> allSubCategories)
        {
            mCategory = category;
            mBrand = brand;
            mAllSubCategories = allSubCategories;
            mSelectedProduct = null;
            ShowDialog();
            return mSelectedProduct;
        }

        private void UseExistingProductForm_Load(object sender, EventArgs e)
        {
            lblBrandValue.Text = mBrand.BrandName;
            lblCategoryValue.Text = mCategory.CategoryName;
            using (Ambient.DbSession.Activate())
            {
                List<Product> products = OrderingRepositories.Product.Get(mBrand.Id, mCategory.Id);
                foreach (Product product in products)
                {
                    ListViewItem item = new ListViewItem();
                    string subCatName = string.Empty;
                    foreach (ProductSubCategory subCat in mAllSubCategories)
                    {
                        if (subCat.Id == product.ProductSubCategoryId)
                        {
                            subCatName = subCat.SubCategoryName;
                            break;
                        }
                    }
                    item.Text = subCatName;
                    item.SubItems.Add(product.ProductName);
                    item.SubItems.Add(product.Size);
                    item.SubItems.Add(product.RetailPrice.ToString());
                    item.Tag = product;
                    lvwProducts.Items.Add(item);
                }
            }
        }

        private void btnOkay_Click(object sender, EventArgs e)
        {
            if (lvwProducts.SelectedItems.Count != 1)
            {
                MessageBox.Show("Please select a product.");
                return;
            }
            mSelectedProduct = (Product)lvwProducts.SelectedItems[0].Tag;
            this.Close();
        }
    }
}
