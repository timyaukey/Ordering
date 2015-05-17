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
    public partial class ProductSubCategoryForm : Form
    {
        private static Form mSingleton;
        private ProductSubCategoryGridHelper mHelper;

        public ProductSubCategoryForm()
        {
            InitializeComponent();
            mHelper = new ProductSubCategoryGridHelper(subcategoryBindingSource, grdSubCategories, this);
        }

        public static void Show(Form mdiParent)
        {
            if (mSingleton == null)
            {
                mSingleton = new ProductSubCategoryForm();
                mSingleton.MdiParent = mdiParent;
                mSingleton.Show();
            }
            else
            {
                mSingleton.Activate();
            }
        }

        private void ProductSubCategoryForm_Load(object sender, EventArgs e)
        {
            ProductSubCategoryBindingList subcategoryList = new ProductSubCategoryBindingList();
            ProductCategoryBindingList categoryList = new ProductCategoryBindingList();
            categoryList.AddNew();
            using (Ambient.DbSession.Activate())
            {
                subcategoryList.Add(OrderingRepositories.ProductSubCategory.GetAll());
                categoryList.Add(OrderingRepositories.ProductCategory.GetAll());
            }
            mHelper.AddAllColumns(categoryList);
            mHelper.DataSource = subcategoryList;
        }

        private void ProductSubCategoryForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            mSingleton = null;
        }

        private void btnShowUsages_Click(object sender, EventArgs e)
        {
            if (mHelper.CurrentEntity != null && !mHelper.CurrentEntity.Id.IsNull)
            {
                string msg = string.Empty;
                using (Ambient.DbSession.Activate())
                {
                    List<Vendor> usages = OrderingRepositories.Vendor.GetBySubCategoryUse(
                        mHelper.CurrentEntity.Id);
                    foreach (Vendor usage in usages)
                    {
                        msg += usage.VendorName + Environment.NewLine;
                    }
                }
                if (string.IsNullOrEmpty(msg))
                    msg = "Subcategory is not being used.";
                MessageBox.Show(msg, "Uses Of Subcategory \"" + mHelper.CurrentEntity.SubCategoryName + "\"",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
