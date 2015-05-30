using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using Willowsoft.WillowLib.WinForm;
using Willowsoft.WillowLib.Data.Misc;
using Willowsoft.Ordering.Core.Entities;
using Willowsoft.Ordering.Core.Repositories;

namespace Willowsoft.Ordering.UI.Helpers
{
    public class PurOrderGridHelper : GridBindingHelper<PurOrder>
    {
        private DataGridViewColumn mVendorIdCol;
        private DataGridViewColumn mOrderDateCol;
        private DataGridViewColumn mSubmitDateCol;
        private DataGridViewColumn mShipDateCol;
        private DataGridViewColumn mDiscountCol;
        private DataGridViewColumn mFreightCol;

        public PurOrderGridHelper(BindingSource bindingSource, DataGridView grid, Form form)
            : base(bindingSource, grid, form)
        {
        }

        public bool VendorReadOnly
        {
            get { return mVendorIdCol.ReadOnly; }
            set { mVendorIdCol.ReadOnly = value; }
        }

        public void AddAllColumns(VendorBindingList vendorList)
        {
            mVendorIdCol = AddComboBoxColumn("VendorId", "Vendor", 14, false, vendorList, "VendorName", "Id");
            mVendorIdCol.Frozen = true;
            mOrderDateCol = AddDateColumn("OrderDate", "Order Date", 6, false);
            mOrderDateCol.Frozen = true;
            AddTextBoxColumn("OrderNumber", "Order Number", 8, false).Frozen = true;
            mSubmitDateCol = AddDateColumn("SubmitDate", "Submit Date", 6, false);
            mShipDateCol = AddDateColumn("ShipDate", "Ship Date", 6, false);
            AddTextBoxColumn("CreatedBy", "Created By", 7, false);
            mDiscountCol = AddIntegerColumn("Discount", "Disc%", 4, false);
            mFreightCol = AddCurrencyColumn("Freight", "Freight", 6, false);
            AddTextBoxColumn("InvoiceNumber", "Invoice Number", 8, false);
            AddTextBoxColumn("Terms", "Terms", 7, false);
            AddCheckBoxColumn("Imported", "Imported", 4, false);
            AddTextBoxColumn("Notes", "Notes", 30, false).DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            AddTextBoxColumn("Id", "ID", 5, true);
            AddTextBoxColumn("CreateDate", "Created", 10, true);
            AddTextBoxColumn("ModifyDate", "Modified", 10, true);
        }

        protected override string ValidateCell(DataGridViewColumn column, object value)
        {
            if (!ValidDateCell(column, mOrderDateCol, value))
                return "Invalid order date";
            if (!ValidDateCell(column, mShipDateCol, value))
                return "Invalid ship date";
            if (!ValidDateCell(column, mSubmitDateCol, value))
                return "Invalid submit date";
            if (!ValidInt32Cell(column, mDiscountCol, value))
                return "Invalid discount";
            if (!ValidDecimalCell(column, mFreightCol, value))
                return "Invalid freight";
            return null;
        }

        protected override void ValidateDeleting(ErrorList errors)
        {
            using (Ambient.DbSession.Activate())
            {
                List<PurLine> lines = OrderingRepositories.PurLine.Get(CurrentEntity.Id);
                if (lines.Count > 0)
                    errors.Add(new SevereError("Order has line items"));
            }
        }
    }
}
