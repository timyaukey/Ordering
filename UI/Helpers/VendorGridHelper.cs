using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using Willowsoft.WillowLib.WinForm;
using Willowsoft.Ordering.Core.Entities;

namespace Willowsoft.Ordering.UI.Helpers
{
    public class VendorGridHelper : GridBindingHelper<Vendor>
    {
        private DataGridViewColumn mPriceCodeCol;

        public VendorGridHelper(BindingSource bindingSource, DataGridView grid, Form form)
            : base(bindingSource, grid, form)
        {
            mPriceCodeCol = null;
        }

        public void AddAllColumns(ContactBindingList contactList)
        {
            AddTextBoxColumn("VendorName", "Vendor Name", 14, false).Frozen = true;
            AddTextBoxColumn("Terms", "Terms", 4, false);
            AddTextBoxColumn("Shipping", "Shipping", 4, false);
            AddTextBoxColumn("SortCode", "Sort Code", 3, false);
            mPriceCodeCol = AddTextBoxColumn("PriceCode", "Price Code", 3, false);
            AddComboBoxColumn("RepContactId", "Sales Rep", 10, false, contactList, "ContactName", "Id");
            AddComboBoxColumn("OrdContactId", "Order Contact", 10, false, contactList, "ContactName", "Id");
            AddComboBoxColumn("ShpContactId", "Ship Contact", 10, false, contactList, "ContactName", "Id");
            AddComboBoxColumn("ActContactId", "Accounting", 10, false, contactList, "ContactName", "Id");
            AddCurrencyColumn("MinimumOrder", "Min Order", 6, false);
            AddCheckBoxColumn("PreferredVendor", "Preferred", 3, false);
            AddCheckBoxColumn("IsActive", "Active", 3, false);
            AddTextBoxColumn("Notes", "Notes", 30, false).DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            AddTextBoxColumn("Id", "ID", 5, true);
            AddTextBoxColumn("CreateDate", "Created", 10, true);
            AddTextBoxColumn("ModifyDate", "Modified", 10, true);
        }

        protected override string ValidateCell(DataGridViewColumn column, object value)
        {
            if (!ValidInt32Cell(column, mPriceCodeCol, value))
                return "Invalid price code";
            return null;
        }
    }
}
