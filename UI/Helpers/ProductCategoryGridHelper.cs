using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using Willowsoft.WillowLib.WinForm;
using Willowsoft.Ordering.Core.Entities;

namespace Willowsoft.Ordering.UI.Helpers
{
    public class ProductCategoryGridHelper : GridBindingHelper<ProductCategory>
    {
        public ProductCategoryGridHelper(BindingSource bindingSource, DataGridView grid, Form form)
            : base(bindingSource, grid, form)
        {
        }

        public void AddAllColumns()
        {
            AddTextBoxColumn("CategoryName", "Category Name", 14, false).Frozen = true;
            AddTextBoxColumn("SortCode", "Sort Code", 4, false);
            AddCheckBoxColumn("IsActive", "Active", 3, false);
            AddTextBoxColumn("Notes", "Notes", 30, false).DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            AddTextBoxColumn("Id", "ID", 5, true);
            AddTextBoxColumn("CreateDate", "Created", 10, true);
            AddTextBoxColumn("ModifyDate", "Modified", 10, true);
        }
    }
}
