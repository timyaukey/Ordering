using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using Willowsoft.WillowLib.WinForm;
using Willowsoft.Ordering.Core.Entities;

namespace Willowsoft.Ordering.UI.Helpers
{
    public class ContactGridHelper : GridBindingHelper<Contact>
    {
        public ContactGridHelper(BindingSource bindingSource, DataGridView grid, Form form)
            : base(bindingSource, grid, form)
        {
        }

        public void AddAllColumns()
        {
            AddTextBoxColumn("FirstName", "First Name", 8, false).Frozen = true;
            AddTextBoxColumn("Initial", "", 2, false).Frozen = true;
            AddTextBoxColumn("LastName", "Last Name", 8, false).Frozen = true;
            AddTextBoxColumn("Street1", "Address 1", 12, false);
            AddTextBoxColumn("Street2", "Address 2", 6, false);
            AddTextBoxColumn("City", "City", 10, false);
            AddTextBoxColumn("StateProvince", "State", 3, false);
            AddTextBoxColumn("PostalCode", "Zip", 6, false);
            AddTextBoxColumn("Country", "Country", 4, false);
            AddTextBoxColumn("PhoneNumber", "Phone", 8, false);
            AddTextBoxColumn("CellNumber", "Cell", 8, false);
            AddTextBoxColumn("FaxNumber", "Fax", 8, false);
            AddTextBoxColumn("EmailAddress", "Email", 10, false);
            AddCheckBoxColumn("IsActive", "Active", 3, false);
            AddTextBoxColumn("Notes", "Notes", 30, false).DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            AddTextBoxColumn("Id", "ID", 5, true);
            AddTextBoxColumn("CreateDate", "Created", 10, true);
            AddTextBoxColumn("ModifyDate", "Modified", 10, true);
        }
    }
}
