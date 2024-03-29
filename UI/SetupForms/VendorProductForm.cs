﻿using System;
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
using Willowsoft.Ordering.UI.Reports;

namespace Willowsoft.Ordering.UI.SetupForms
{
    public partial class VendorProductForm : Form, JoinVpToProd.IFreightProvider
    {
        private static Form mSingleton;
        private VPJoinGridHelper mHelper;

        private ProductBrandBindingList mBrandList;
        private ProductCategory mProductCategory;
        private Vendor mVendor;
        private List<ProductSubCategory> mAllSubCategories;
        private Product mExistingProduct;
        private JoinVpToProdBindingList mUnfilteredVendorProducts;
        private double mFreightPercent;

        public VendorProductForm()
        {
            InitializeComponent();
            mHelper = new VPJoinGridHelper(bindingSource, grdMain, this);
            mFreightPercent = 0.0;
            mVendor = null;
        }

        public static void Show(Form mdiParent)
        {
            if (mSingleton == null)
            {
                mSingleton = new VendorProductForm();
                mSingleton.MdiParent = mdiParent;
                mSingleton.Show();
            }
            else
            {
                mSingleton.Activate();
            }
        }

        private void VendorProductForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            mSingleton = null;
        }

        private void VendorProductForm_Load(object sender, EventArgs e)
        {
            //Willowsoft.WillowLib.CodeGenUI.PersistableWrapperGenerator gen = 
            //    new Willowsoft.WillowLib.CodeGenUI.PersistableWrapperGenerator("JoinVpToProd");
            //gen.Add(typeof(VendorProduct));
            //gen.Add(typeof(Product));
            //gen.GenerateToClipboard();

            using (Ambient.DbSession.Activate())
            {
                List<Vendor> allVendors = OrderingRepositories.Vendor.GetAll();
                cboVendor.DataSource = allVendors;
                List<ProductCategory> allCategories = OrderingRepositories.ProductCategory.GetAll();
                ProductCategory allowAll = new ProductCategory(
                    new ProductCategoryId(VendorProductHelper.AllCategoriesId),
                    "(all categories)", "0", "", true, DateTime.Now, DateTime.Now);
                allCategories.Insert(0, allowAll);
                cboCategory.DataSource = allCategories;
                mAllSubCategories = OrderingRepositories.ProductSubCategory.GetAll();
            }
            mHelper.AddAllColumns(new ProductSubCategoryBindingList(), mBrandList);
            LoadBrandList();
        }

        private void LoadBrandList()
        {
            using (Ambient.DbSession.Activate())
            {
                mBrandList = new ProductBrandBindingList();
                mBrandList.AddNew();
                mBrandList.Add(OrderingRepositories.ProductBrand.GetAll());
                cboBrand.DataSource = mBrandList;
                mHelper.SetProductBrands(mBrandList);
            }
        }

        private void btnLoadProducts_Click(object sender, EventArgs e)
        {
            LoadCurrentVendorAndCategory();
        }

        private void LoadCurrentVendorAndCategory()
        {
            if (!mHelper.IsOkayToChangeDataSource("reload vendor product list"))
                return;
            Vendor vendor = (Vendor)cboVendor.SelectedItem;
            if (vendor == null)
            {
                MessageBox.Show("Please select a vendor first.", "Select Vendor");
                return;
            }
            ProductCategory category = (ProductCategory)cboCategory.SelectedItem;
            if (category == null)
            {
                MessageBox.Show("Please select a product category first.", "Select Category");
                return;
            }
            LoadList(vendor, category);
        }

        private void LoadList(Vendor vendor, ProductCategory category)
        {
            if (vendor != mVendor)
            {
                mVendor = vendor;
                if (mVendor.Shipping.EndsWith("%"))
                {
                    txtFreightPercent.Text = mVendor.Shipping.Substring(0, mVendor.Shipping.Length - 1);
                }
                else
                {
                    txtFreightPercent.Text = "";
                }
            }
            mProductCategory = category;
            mHelper.DataSource = null;
            if (chkShowAllSubcats.Checked  || category.Id.Value == VendorProductHelper.AllCategoriesId)
                mHelper.SetProductSubCategories(GetAllSubCategories());
            else
                mHelper.SetProductSubCategories(GetSubCategoriesOfCategory());
            mUnfilteredVendorProducts = GetVendorProducts(vendor.Id);
            mHelper.DataSource = mUnfilteredVendorProducts;
            mHelper.VendorId = vendor.Id;
            grdMain.Visible = true;
            lblBrand.Visible = true;
            cboBrand.Visible = true;
            lblFreightPercent.Visible = true;
            txtFreightPercent.Visible = true;
            btnUseExistingProduct.Visible = true;
            btnImport.Visible = true;
            btnShowOrdersUsedBy.Visible = true;
            txtFilter.Visible = true;
            btnFilter.Visible = true;
            btnClearFilter.Visible = true;
            btnPrint.Visible = true;
            btnRefreshOrders.Visible = true;
        }

        private ProductSubCategoryBindingList GetSubCategoriesOfCategory()
        {
            ProductSubCategoryBindingList subCats = new ProductSubCategoryBindingList();
            subCats.AddNew();
            foreach (ProductSubCategory subCat in mAllSubCategories)
            {
                if (subCat.ProductCategoryId == mProductCategory.Id)
                    subCats.Add(subCat);
            }
            return subCats;
        }

        private ProductSubCategoryBindingList GetAllSubCategories()
        {
            ProductSubCategoryBindingList subCats = new ProductSubCategoryBindingList();
            subCats.AddNew();
            foreach (ProductSubCategory subCat in mAllSubCategories)
            {
                subCats.Add(subCat);
            }
            return subCats;
        }

        private JoinVpToProdBindingList GetVendorProducts(VendorId vendorId)
        {
            JoinVpToProdBindingList venprodJoinList = new JoinVpToProdBindingList();
            using (Ambient.DbSession.Activate())
            {
                Dictionary<int, Product> productDict;
                List<VendorProduct> venprodList;
                if (mProductCategory.Id.Value == VendorProductHelper.AllCategoriesId)
                    VendorProductHelper.LoadForAllCategories(vendorId, out productDict, out venprodList);
                else
                    VendorProductHelper.LoadForCategory(vendorId, mProductCategory.Id, out productDict, out venprodList);
                bool showInactive = chkShowInactive.Checked;
                bool showDeleted = chkShowDeleted.Checked;
                foreach (VendorProduct venprod in venprodList)
                {
                    Product product = productDict[venprod.ProductId.Value];
                    bool showProduct = true;
                    if ((product.IsProductDeleted || venprod.IsProductDeleted) && !showDeleted)
                        showProduct = false;
                    if ((!product.IsActive || !venprod.IsActive) && !showInactive)
                        showProduct = false;
                    if (showProduct)
                    {
                        JoinVpToProd join = new JoinVpToProd(venprod, product);
                        join.SetExternalData(this);
                        venprodJoinList.Add(join);
                    }
                }
            }
            return venprodJoinList;
        }

        private void btnUseExistingProduct_Click(object sender, EventArgs e)
        {
            ProductBrand brand = (ProductBrand)cboBrand.SelectedItem;
            if (brand == null || brand.Id.IsNull)
            {
                MessageBox.Show("Select a brand first.", "Select Brand");
                return;
            }
            if (mProductCategory.Id.Value == VendorProductHelper.AllCategoriesId)
            {
                MessageBox.Show("Select a single category first.", "Select Category");
                return;
            }
            if (!mHelper.IsOkayToChangeDataSource("use existing product"))
                return;
            UseExistingProductForm useExistingForm = new UseExistingProductForm();
            Product product;
            using (useExistingForm)
            {
                product = useExistingForm.Show(mProductCategory, brand, mAllSubCategories);
            }
            if (product == null)
                return;
            foreach (JoinVpToProd join in mHelper.DataSource)
            {
                if (join.InnerProduct.Id == product.Id)
                {
                    MessageBox.Show("That product is already listed for this vendor.", "Product Already Used");
                    return;
                }
            }
            try
            {
                mExistingProduct = product;
                mHelper.DisableValidation();
                try
                {
                    bindingSource.AddNew();
                }
                finally
                {
                    mHelper.EnableValidation();
                }
            }
            finally
            {
                mExistingProduct = null;
            }
        }

        private void bindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            if (mExistingProduct != null)
            {
                VendorProduct venProd = new VendorProduct();
                venProd.IsDirty = true;
                JoinVpToProd newJoin = new JoinVpToProd(venProd, mExistingProduct);
                e.NewObject = newJoin;
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            ImportProductsForm form = new ImportProductsForm();
            Vendor vendor = (Vendor)cboVendor.SelectedItem;
            List<ProductSubCategory> allowedSubCats = mAllSubCategories.FindAll(subCat =>
                (subCat.ProductCategoryId.Value == mProductCategory.Id.Value) ||
                (mProductCategory.Id.Value == VendorProductHelper.AllCategoriesId)
                );
            form.Show(vendor, allowedSubCats);
            LoadBrandList();
            LoadCurrentVendorAndCategory();
        }

        private void btnShowOrdersUsedBy_Click(object sender, EventArgs e)
        {
            if (mHelper.CurrentEntity == null)
            {
                MessageBox.Show("Select the row with the product whose orders you want to see.");
                return;
            }
            if (mHelper.CurrentEntity != null && mHelper.CurrentEntity.IsPersisted)
            {
                using (PurOrderSummaryForm frm = new PurOrderSummaryForm())
                {
                    List<PurOrderSummary> orders;
                    using (Ambient.DbSession.Activate())
                    {
                        orders = OrderingRepositories.PurOrder.GetByVendorProduct(
                            mHelper.CurrentEntity.VendorProduct_Id);
                    }
                    frm.Show(orders, mHelper.CurrentEntity.Product_ProductName);
                }
            }
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            mHelper.DataSource = null;
            mHelper.DataSource = mUnfilteredVendorProducts;
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilter.Text))
            {
                MessageBox.Show("Please enter text to filter with first.");
                return;
            }
            JoinVpToProdBindingList filteredList = new JoinVpToProdBindingList();
            foreach (JoinVpToProd join in mUnfilteredVendorProducts)
            {
                if ((join.Product_ProductName.IndexOf(txtFilter.Text, StringComparison.InvariantCultureIgnoreCase) >= 0) ||
                    (join.VendorProduct_VendorPartNum.IndexOf(txtFilter.Text, StringComparison.InvariantCultureIgnoreCase) >= 0))
                {
                    filteredList.Add(join);
                }
            }
            mHelper.DataSource = null;
            mHelper.DataSource = filteredList;
        }

        private void txtFreightPercent_TextChanged(object sender, EventArgs e)
        {
            if (!double.TryParse(txtFreightPercent.Text, out mFreightPercent))
            {
                mFreightPercent = 0.0;
            }
            else
            {
                mFreightPercent = mFreightPercent / 100.0;
            }
        }

        private void txtFreightPercent_Leave(object sender, EventArgs e)
        {
            grdMain.Invalidate();
        }

        #region IFreightProvider Members

        public double FreightPercent
        {
            get { return mFreightPercent; }
        }

        #endregion

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (mVendor == null || mProductCategory == null)
            {
                MessageBox.Show("Select vendor and category first.");
                return;
            }
            VendorProductReport report = new VendorProductReport();
            report.Run(mVendor, mProductCategory, this.MdiParent);
        }

        private void btnRefreshOrders_Click(object sender, EventArgs e)
        {
            DialogResult dlgRes = MessageBox.Show("This will refresh all existing order lines for the selected " +
                "vendor with the current product names, subcategories, brands, sizes, models, and barcodes. " +
                "Prices will NOT be refreshed.", "Confirm", 
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dlgRes != DialogResult.OK)
            {
                MessageBox.Show("Refresh operation canceled.");
                return;
            }
            if (mVendor == null)
            {
                MessageBox.Show("Select vendor first.");
                return;
            }
            using (Ambient.DbSession.Activate())
            {
                OrderingRepositories.PurLine.RefreshFromDefinitions(mVendor.Id);
            }
            MessageBox.Show("All order lines for this vendor refreshed.");
        }
    }
}
