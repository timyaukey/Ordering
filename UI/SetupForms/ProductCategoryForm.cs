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
    public partial class ProductCategoryForm : Form
    {
        private static Form mSingleton;
        private ProductCategoryGridHelper mHelper;

        public ProductCategoryForm()
        {
            InitializeComponent();
            mHelper = new ProductCategoryGridHelper(categoryBindingSource, grdCategories, this);
        }

        public static void Show(Form mdiParent)
        {
            if (mSingleton == null)
            {
                mSingleton = new ProductCategoryForm();
                mSingleton.MdiParent = mdiParent;
                mSingleton.Show();
            }
            else
            {
                mSingleton.Activate();
            }
        }

        private void ProductCategoryForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            mSingleton = null;
        }

        private void ProductCategoryForm_Load(object sender, EventArgs e)
        {
            ProductCategoryBindingList productCategoryList = new ProductCategoryBindingList();
            using (Ambient.DbSession.Activate())
            {
                productCategoryList.Add(OrderingRepositories.ProductCategory.GetAll());
            }
            mHelper.AddAllColumns();
            mHelper.DataSource = productCategoryList;
        }
    }
}
