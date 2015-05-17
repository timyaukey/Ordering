using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using Willowsoft.WillowLib.Data.Entity;
using Willowsoft.WillowLib.Data.Misc;
using Willowsoft.WillowLib.WinForm;
using Willowsoft.Ordering.Core.Entities;
using Willowsoft.Ordering.Core.Repositories;

namespace Willowsoft.Ordering.UI.Helpers
{
    public class VPJoinGridHelper : GridBindingHelper<JoinVpToProd>
    {
        private VendorId mVendorId;
        private DataGridViewComboBoxColumn mSubCatColumn;
        private DataGridViewColumn mRetailPriceColumn;
        private DataGridViewColumn mRetailPriceOverrideColumn;
        private DataGridViewColumn mCaseCostColumn;
        private DataGridViewColumn mCountInCaseColumn;
        private DataGridViewColumn mEachCostColumn;
        private DataGridViewComboBoxColumn mBrandColumn;

        public VPJoinGridHelper(BindingSource bindingSource, DataGridView grid, Form form)
            : base(bindingSource, grid, form)
        {
        }

        public void AddAllColumns(ProductSubCategoryBindingList subcategoryList,
            ProductBrandBindingList brandList)
        {
            DataGridViewTextBoxColumn col;
            mSubCatColumn = AddComboBoxColumn("Product_ProductSubCategoryId", "Sub Category", 10, false, subcategoryList, "SubCategoryName", "Id");
            mSubCatColumn.Frozen = true;
            AddTextBoxColumn("Product_ProductName", "Product Name", 20, false).Frozen = true;
            AddTextBoxColumn("Product_Size", "Size", 4, false);
            mBrandColumn = AddComboBoxColumn("Product_ProductBrandId", "Brand", 8, false, brandList, "BrandName", "Id");
            mRetailPriceColumn = AddCurrencyColumn("Product_RetailPrice", "Normal Retail", 4, false);
            mRetailPriceOverrideColumn = AddCurrencyColumn("VendorProduct_RetailPriceOverride", "Vendor Retail", 4, false);
            col = AddTextBoxColumn("NormalMargin", "Normal Margin", 4, true);
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            col.DefaultCellStyle.Format = VendorProduct.MarginFormat;
            col = AddTextBoxColumn("VendorMargin", "Vendor Margin", 4, true);
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            col.DefaultCellStyle.Format = VendorProduct.MarginFormat;
            AddTextBoxColumn("VendorProduct_VendorPartNum", "Vendor Code", 8, false);
            mCaseCostColumn = AddCurrencyColumn("VendorProduct_CaseCost", "Case Cost", 4, false);
            mCountInCaseColumn = AddIntegerColumn("VendorProduct_CountInCase", "Case Size", 3, false);
            mEachCostColumn = AddCurrencyColumn("VendorProduct_EachCost", "Each Cost", 4, false);
            AddCheckBoxColumn("Product_IsActive", "Product Active", 4, false);
            AddCheckBoxColumn("VendorProduct_IsActive", "V.P. Active", 4, false);
            AddCheckBoxColumn("VendorProduct_PreferredSource", "Pref. Source", 5, false);
            AddTextBoxColumn("Product_ManufacturerBarcode", "Barcode", 3, false);
            AddTextBoxColumn("Product_ManufacturerPartNum", "Man. Part", 3, false);
            AddCheckBoxColumn("Product_PricingRequiresReview", "Prod. Review Price", 3, false);
            AddCheckBoxColumn("VendorProduct_PricingRequiresReview", "Vendor Review Price", 5, false);
            AddCheckBoxColumn("VendorProduct_NumAndCostRequireReview", "Vendor Review Info", 5, false);
            AddTextBoxColumn("VendorProduct_Id", "ID", 5, true);
            AddTextBoxColumn("VendorProduct_CreateDate", "Created", 10, true);
            AddTextBoxColumn("VendorProduct_ModifyDate", "Modified", 10, true);
        }

        protected override string ValidateCell(DataGridViewColumn column, object value)
        {
            if (!ValidDecimalCell(column, mRetailPriceColumn, value))
                return "Invalid retail price";
            if (!ValidDecimalCell(column, mRetailPriceOverrideColumn, value))
                return "Invalid vendor retail price";
            if (!ValidDecimalCell(column, mCaseCostColumn, value))
                return "Invalid case cost";
            if (!ValidDecimalCell(column, mEachCostColumn, value))
                return "Invalid each cost";
            if (!ValidInt32Cell(column, mCountInCaseColumn, value))
                return "Invalid case size";
            return null;
        }

        protected override void AdditionalRowValidation(ErrorList errors)
        {
            using (Ambient.DbSession.Activate())
            {
                List<VendorProduct> matches =
                    OrderingRepositories.VendorProduct.Get(mVendorId, CurrentEntity.VendorProduct_VendorPartNum);
                if (matches.Count > 0)
                {
                    if (!CurrentEntity.IsPersisted || (matches[0].Id != CurrentEntity.VendorProduct_Id))
                    {
                        errors.Add(new EntityDuplicateKeyError("vendor code"));
                    }
                }
                List<Product> matches2 =
                    OrderingRepositories.Product.Get(CurrentEntity.Product_ProductBrandId,
                        CurrentEntity.Product_ProductName, CurrentEntity.Product_Size);
                if (matches2.Count > 0)
                {
                    if (!CurrentEntity.IsPersisted || (matches2[0].Id != CurrentEntity.Product_Id))
                    {
                        errors.Add(new EntityDuplicateKeyError("product name, brand and size"));
                    }
                }
            }
        }

        protected override void ValidateDeleting(ErrorList errors)
        {
            using (Ambient.DbSession.Activate())
            {
                int vendorMatches = 0;
                List<PurOrderSummary> usages = OrderingRepositories.PurOrder.GetByVendorProduct(
                    CurrentEntity.VendorProduct_Id);
                foreach (PurOrderSummary usage in usages)
                {
                    if (usage.VendorId == CurrentEntity.VendorProduct_VendorId)
                        vendorMatches++;
                }
                if (vendorMatches > 0)
                    errors.Add(new SevereError("Vendor product is in use"));
            }
        }

        public VendorId VendorId
        {
            get { return mVendorId; }
            set { mVendorId = value; }
        }

        public void SetProductSubCategories(ProductSubCategoryBindingList subcategoryList)
        {
            mSubCatColumn.DataSource = subcategoryList;
        }

        public void SetProductBrands(ProductBrandBindingList brandList)
        {
            mBrandColumn.DataSource = brandList;
        }

        protected override void SetCurrentFixedValues()
        {
            CurrentEntity.VendorProduct_VendorId = mVendorId;
        }
    }
}
