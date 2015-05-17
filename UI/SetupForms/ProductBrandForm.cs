using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Willowsoft.WillowLib.Data.Misc;
using Willowsoft.WillowLib.Data.Sql;
using Willowsoft.Ordering.Core.Entities;
using Willowsoft.Ordering.Core.Repositories;
using Willowsoft.Ordering.UI.Helpers;

namespace Willowsoft.Ordering.UI.SetupForms
{
    public partial class ProductBrandForm : Form
    {
        private static Form mSingleton;
        private ProductBrandGridHelper mHelper;

        public ProductBrandForm()
        {
            InitializeComponent();
            mHelper = new ProductBrandGridHelper(brandBindingSource, grdBrands, this);
        }

        public static void Show(Form mdiParent)
        {
            if (mSingleton == null)
            {
                mSingleton = new ProductBrandForm();
                mSingleton.MdiParent = mdiParent;
                mSingleton.Show();
            }
            else
            {
                mSingleton.Activate();
            }
        }

        private void ProductBrandForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            mSingleton = null;
        }

        private void ProductBrandForm_Load(object sender, EventArgs e)
        {
            ProductBrandBindingList productBrandList = new ProductBrandBindingList();
            using (Ambient.DbSession.Activate())
            {
                productBrandList.Add(OrderingRepositories.ProductBrand.GetAll());
            }
            mHelper.AddAllColumns();
            mHelper.DataSource = productBrandList;
        }

        private void btnShowUsage_Click(object sender, EventArgs e)
        {
            if (mHelper.CurrentEntity != null && !mHelper.CurrentEntity.Id.IsNull)
            {
                string msg = string.Empty;
                using (Ambient.DbSession.Activate())
                {
                    List<Vendor> allVendors = OrderingRepositories.Vendor.GetAll();
                    List<ProductCategory> allCategories = OrderingRepositories.ProductCategory.GetAll();
                    List<BrandUsageSummary> usages = OrderingRepositories.VendorProduct.Get(
                        mHelper.CurrentEntity.Id);
                    foreach(BrandUsageSummary usage in usages)
                    {
                        Vendor matchedVendor = null;
                        foreach (Vendor vendor in allVendors)
                        {
                            if (vendor.Id == usage.VendorId)
                            {
                                matchedVendor = vendor;
                                break;
                            }
                        }
                        ProductCategory matchedCategory = null;
                        foreach (ProductCategory category in allCategories)
                        {
                            if (category.Id == usage.CategoryId)
                            {
                                matchedCategory = category;
                                break;
                            }
                        }
                        msg += matchedVendor.VendorName + ", " + matchedCategory.CategoryName + Environment.NewLine;
                    }
                }
                if (string.IsNullOrEmpty(msg))
                    msg = "Brand is not being used.";
                MessageBox.Show(msg, "Uses Of Brand \"" + mHelper.CurrentEntity.BrandName + "\"",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
