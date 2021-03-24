using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using Willowsoft.WillowLib.WinForm;
using Willowsoft.Ordering.Core.Entities;

namespace Willowsoft.Ordering.UI.Helpers
{
    public class PurLineJoinGridHelper : GridBindingHelper<JoinPlToVpToProd>
    {
        private DataGridViewColumn mPurLine_QtyOrderedColumn;
        private DataGridViewColumn mPurLine_QtyReceivedColumn;
        private DataGridViewColumn mPurLine_OrderedEachesColumn;
        private DataGridViewColumn mPurLine_QtyBackorderedColumn;
        private DataGridViewColumn mPurLine_QtyMissingColumn;
        private DataGridViewColumn mPurLine_QtyDamagedColumn;
        private DataGridViewColumn mPurLine_QtyOnHandColumn;
        private DataGridViewColumn mPurLine_CaseCostColumn;
        private DataGridViewColumn mPurLine_CaseCostOverrideColumn;
        private DataGridViewColumn mPurLine_CountInCaseColumn;
        private DataGridViewColumn mPurLine_EachCostColumn;
        private DataGridViewColumn mPurLine_EachCostOverrideColumn;
        private DataGridViewColumn mPurLine_RetailPriceColumn;
        private DataGridViewColumn mPurLine_RetailPriceOverrideColumn;

        private Dictionary<int, ProductSubCategory> mSubCategories;
        private Dictionary<int, ProductBrand> mBrands;
        private PurOrder mPurOrder;

        private bool mUpdateTotalCost;

        public PurLineJoinGridHelper(BindingSource bindingSource, DataGridView grid, Form form)
            : base(bindingSource, grid, form)
        {
            mUpdateTotalCost = false;
        }

        public void Init(PurOrder order, 
            Dictionary<int, ProductSubCategory> subCategories,
            Dictionary<int, ProductBrand> brands)
        {
            mSubCategories = subCategories;
            mBrands = brands;
            mPurOrder = order;
        }

        public void AddAllColumns(ProductSubCategoryBindingList subcategoryList,
            ProductBrandBindingList brandList)
        {
            DataGridViewTextBoxColumn col;

            mPurLine_QtyOnHandColumn = AddIntegerColumn("PurLine_QtyOnHand", "On Hand", 3, false);
            AddComboBoxColumn("PurLine_ProductSubCategoryId", "Sub Category", 10, false, subcategoryList, "SubCategoryName", "Id").Frozen = true;
            AddComboBoxColumn("PurLine_ProductBrandId", "Brand", 8, false, brandList, "BrandName", "Id").Frozen = true;
            AddTextBoxColumn("PurLine_ProductName", "Product Name", 20, false).Frozen = true;
            AddTextBoxColumn("PurLine_Size", "Size", 4, false).Frozen = true; ;
            AddTextBoxColumn("PurLine_ManufacturerPartNum", "Model Number", 4, false);
            AddTextBoxColumn("PurLine_VendorPartNum", "Vendor Code", 8, false);
            mPurLine_QtyOrderedColumn = AddIntegerColumn("PurLine_QtyOrdered", "Qty Ord", 3, false);
            //mPurLine_QtyOrderedColumn.Frozen = true;
            mPurLine_OrderedEachesColumn = AddCheckBoxColumn("PurLine_OrderedEaches", "Order Eaches", 4, false);
            //mPurLine_OrderedEachesColumn.Frozen = true;
            AddCurrencyColumn("ExtendedCost", "Extended Cost", 5, true);
            mPurLine_EachCostColumn = AddCurrencyColumn("PurLine_EachCost", "Regular Each Cost", 4, false);
            mPurLine_CaseCostColumn = AddCurrencyColumn("PurLine_CaseCost", "Regular Case Cost", 4, false);
            mPurLine_CountInCaseColumn = AddIntegerColumn("PurLine_CountInCase", "Case Size", 4, false);
            AddCheckBoxColumn("PurLine_SpecialOrder", "Special Order", 4, false);
            AddTextBoxColumn("Product_QtyBusyMin", "Qty Busy Min", 3, true);
            AddTextBoxColumn("Product_QtyBusyMax", "Qty Busy Max", 3, true);
            AddTextBoxColumn("Product_QtySlowMin", "Qty Slow Min", 3, true);
            AddTextBoxColumn("Product_QtySlowMax", "Qty Slow Max", 3, true);
            mPurLine_CaseCostOverrideColumn = AddCurrencyColumn("PurLine_CaseCostOverride", "Special Case Cost", 4, false);
            AddCurrencyColumn("EachCostFromNominalCaseCost", "Best Each In Case", 4, true);
            mPurLine_EachCostOverrideColumn = AddCurrencyColumn("PurLine_EachCostOverride", "Special Each Cost", 4, false);
            AddCurrencyColumn("BestEachCost", "Best Each Cost", 4, true);
            mPurLine_RetailPriceColumn = AddCurrencyColumn("PurLine_RetailPrice", "Normal Retail", 4, false);
            mPurLine_RetailPriceOverrideColumn = AddCurrencyColumn("PurLine_RetailPriceOverride", "Vendor Retail", 4, false);
            col = AddTextBoxColumn("BestNormalMargin", "Best Normal Margin", 5, true);
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            col.DefaultCellStyle.Format = VendorProduct.MarginFormat;
            col = AddTextBoxColumn("BestVendorMargin", "Best Vendor Margin", 5, true);
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            col.DefaultCellStyle.Format = VendorProduct.MarginFormat;
            mPurLine_QtyReceivedColumn = AddIntegerColumn("PurLine_QtyReceived", "Received", 5, false);
            mPurLine_QtyBackorderedColumn = AddIntegerColumn("PurLine_QtyBackordered", "Back Ordered", 5, false);
            mPurLine_QtyMissingColumn = AddIntegerColumn("PurLine_QtyMissing", "Missing", 5, false);
            mPurLine_QtyDamagedColumn = AddIntegerColumn("PurLine_QtyDamaged", "Damaged", 5, false);
            AddTextBoxColumn("PurLine_ManufacturerBarcode", "Barcode", 8, false);
            AddTextBoxColumn("PurLine_ShelfOrder", "Shelf Order", 4, false);
            AddTextBoxColumn("PurLine_Notes", "Notes", 30, false);
            AddTextBoxColumn("PurLine_VendorProductId", "V.P. Id", 5, true);
            AddTextBoxColumn("PurLine_CreateDate", "Created", 10, true);
            AddTextBoxColumn("PurLine_ModifyDate", "Modified", 10, true);
        }

        protected override string ValidateCell(DataGridViewColumn column, object value)
        {
            if (column == mPurLine_QtyOrderedColumn ||
                column == mPurLine_OrderedEachesColumn ||
                column == mPurLine_CaseCostOverrideColumn ||
                column == mPurLine_EachCostOverrideColumn ||
                column == mPurLine_CaseCostColumn ||
                column == mPurLine_EachCostColumn ||
                column == mPurLine_CountInCaseColumn ||
                column == mPurLine_RetailPriceColumn ||
                column == mPurLine_RetailPriceOverrideColumn)
                mUpdateTotalCost = true;
            if (!ValidInt32Cell(column, mPurLine_QtyOrderedColumn, value))
                return "Invalid quantity ordered";
            if (!ValidInt32Cell(column, mPurLine_QtyReceivedColumn, value))
                return "Invalid quantity received";
            if (!ValidInt32Cell(column, mPurLine_QtyBackorderedColumn, value))
                return "Invalid quantity backordered";
            if (!ValidInt32Cell(column, mPurLine_QtyMissingColumn, value))
                return "Invalid quantity missing";
            if (!ValidInt32Cell(column, mPurLine_QtyDamagedColumn, value))
                return "Invalid quantity damaged";
            if (!ValidInt32Cell(column, mPurLine_QtyOnHandColumn, value))
                return "Invalid quantity on hand";
            if (!ValidDecimalCell(column, mPurLine_CaseCostColumn, value))
                return "Invalid case cost";
            if (!ValidDecimalCell(column, mPurLine_CaseCostOverrideColumn, value))
                return "Invalid special case cost";
            if (!ValidInt32Cell(column, mPurLine_CountInCaseColumn, value))
                return "Invalid case size";
            if (!ValidDecimalCell(column, mPurLine_EachCostColumn, value))
                return "Invalid each cost";
            if (!ValidDecimalCell(column, mPurLine_EachCostOverrideColumn, value))
                return "Invalid special each cost";
            if (!ValidDecimalCell(column, mPurLine_RetailPriceColumn, value))
                return "Invalid retail price";
            if (!ValidDecimalCell(column, mPurLine_RetailPriceOverrideColumn, value))
                return "Invalid special retail price";
            return null;
        }

        public bool UpdateTotalCost
        {
            get { return mUpdateTotalCost; }
            set { mUpdateTotalCost = value; }
        }

        protected override void SetCurrentFixedValues()
        {
            CurrentEntity.PurLine_PurOrderId = mPurOrder.Id;
        }

        protected override void RowAdded()
        {
            CurrentEntity.SetExternalData(mSubCategories, mBrands, mPurOrder);
        }
    }
}
