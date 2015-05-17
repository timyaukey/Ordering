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
        private DataGridViewColumn mPurLine_CaseCostOverrideColumn;
        private DataGridViewColumn mPurLine_EachCostOverrideColumn;

        private bool mUpdateTotalCost;

        public PurLineJoinGridHelper(BindingSource bindingSource, DataGridView grid, Form form)
            : base(bindingSource, grid, form)
        {
            mUpdateTotalCost = false;
        }

        public void AddAllColumns()
        {
            DataGridViewTextBoxColumn col;
            AddTextBoxColumn("SubCategoryName", "Sub Category", 10, true).Frozen = true;
            AddTextBoxColumn("Product_ProductName", "Product Name", 20, true).Frozen = true;
            AddTextBoxColumn("Product_Size", "Size", 5, true).Frozen = true; ;
            mPurLine_QtyOrderedColumn = AddIntegerColumn("PurLine_QtyOrdered", "Ordered", 4, false);
            mPurLine_QtyOrderedColumn.Frozen = true;
            mPurLine_OrderedEachesColumn = AddCheckBoxColumn("PurLine_OrderedEaches", "Eaches", 4, false);
            mPurLine_OrderedEachesColumn.Frozen = true;
            AddCurrencyColumn("ExtendedCost", "Extended Cost", 5, true).Frozen = true;
            mPurLine_QtyReceivedColumn = AddIntegerColumn("PurLine_QtyReceived", "Received", 5, false);
            mPurLine_QtyBackorderedColumn = AddIntegerColumn("PurLine_QtyBackordered", "Back Ordered", 5, false);
            mPurLine_QtyMissingColumn = AddIntegerColumn("PurLine_QtyMissing", "Missing", 5, false);
            mPurLine_QtyDamagedColumn = AddIntegerColumn("PurLine_QtyDamaged", "Damaged", 5, false);
            mPurLine_QtyOnHandColumn = AddIntegerColumn("PurLine_QtyOnHand", "On Hand", 5, false);
            AddTextBoxColumn("BrandName", "Brand", 10, true);
            AddTextBoxColumn("VendorProduct_VendorPartNum", "Vendor Code", 8, true);
            AddCurrencyColumn("VendorProduct_CaseCost", "Case Cost", 5, true);
            mPurLine_CaseCostOverrideColumn = AddCurrencyColumn("PurLine_CaseCostOverride", "Special Case Cost", 5, false);
            AddIntegerColumn("VendorProduct_CountInCase", "Case Size", 4, true);
            AddCurrencyColumn("VendorProduct_EachCost", "Each Cost", 5, true);
            mPurLine_EachCostOverrideColumn = AddCurrencyColumn("PurLine_EachCostOverride", "Special Each Cost", 5, false);
            AddCurrencyColumn("Product_RetailPrice", "Normal Retail", 5, true);
            AddCurrencyColumn("VendorProduct_RetailPriceOverride", "Vendor Retail", 5, true);
            col = AddTextBoxColumn("NormalMargin", "Normal Margin", 5, true);
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            col.DefaultCellStyle.Format = VendorProduct.MarginFormat;
            col = AddTextBoxColumn("VendorMargin", "Vendor Margin", 5, true);
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            col.DefaultCellStyle.Format = VendorProduct.MarginFormat;
            AddTextBoxColumn("PurLine_Notes", "Notes", 30, false);
            AddTextBoxColumn("VendorProduct_Id", "ID", 5, true);
            AddTextBoxColumn("VendorProduct_CreateDate", "Created", 10, true);
            AddTextBoxColumn("VendorProduct_ModifyDate", "Modified", 10, true);
        }

        protected override string ValidateCell(DataGridViewColumn column, object value)
        {
            if (column == mPurLine_QtyOrderedColumn ||
                column == mPurLine_OrderedEachesColumn ||
                column == mPurLine_CaseCostOverrideColumn ||
                column == mPurLine_EachCostOverrideColumn)
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
            if (!ValidDecimalCell(column, mPurLine_CaseCostOverrideColumn, value))
                return "Invalid special case cost";
            if (!ValidDecimalCell(column, mPurLine_EachCostOverrideColumn, value))
                return "Invalid special each cost";
            return null;
        }

        public bool UpdateTotalCost
        {
            get { return mUpdateTotalCost; }
            set { mUpdateTotalCost = value; }
        }
    }
}
