using System;
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
    public class ProductBrandGridHelper : GridBindingHelper<ProductBrand>
    {
        public ProductBrandGridHelper(BindingSource bindingSource, DataGridView grid, Form form)
            : base(bindingSource, grid, form)
        {
        }

        public void AddAllColumns()
        {
            AddTextBoxColumn("BrandName", "Brand Name", 14, false).Frozen = true;
            AddCheckBoxColumn("IsActive", "Active", 3, false);
            AddTextBoxColumn("Notes", "Notes", 30, false).DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            AddTextBoxColumn("Id", "ID", 5, true);
            AddTextBoxColumn("CreateDate", "Created", 10, true);
            AddTextBoxColumn("ModifyDate", "Modified", 10, true);
        }

        protected override void ValidateDeleting(ErrorList errors)
        {
            using (Ambient.DbSession.Activate())
            {
                List<BrandUsageSummary> usages = OrderingRepositories.VendorProduct.Get(CurrentEntity.Id);
                if (usages.Count > 0)
                    errors.Add(new SevereError("Product brand is in use"));
            }
        }
    }
}
