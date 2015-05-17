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
    public class ProductSubCategoryGridHelper : GridBindingHelper<ProductSubCategory>
    {
        private DataGridViewColumn mDefaultMarginCol;

        public ProductSubCategoryGridHelper(BindingSource bindingSource, DataGridView grid, Form form)
            : base(bindingSource, grid, form)
        {
            mDefaultMarginCol = null;
        }

        public void AddAllColumns(ProductCategoryBindingList categoryList)
        {
            AddComboBoxColumn("ProductCategoryId", "Category", 12, false, categoryList, "CategoryName", "Id").Frozen = true;
            AddTextBoxColumn("SubCategoryName", "Subcategory Name", 14, false).Frozen = true;
            AddTextBoxColumn("SortCode", "Sort Code", 6, false);
            mDefaultMarginCol = AddTextBoxColumn("DefaultProfitMargin", "Default Margin", 5, false);
            AddCheckBoxColumn("PricingRequiresReview", "Review Pricing", 5, false);
            AddCheckBoxColumn("IsActive", "Active", 3, false);
            AddTextBoxColumn("Notes", "Notes", 30, false).DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            AddTextBoxColumn("Id", "ID", 5, true);
            AddTextBoxColumn("CreateDate", "Created", 10, true);
            AddTextBoxColumn("ModifyDate", "Modified", 10, true);
        }

        protected override string ValidateCell(DataGridViewColumn column, object value)
        {
            if (!ValidInt32Cell(column, mDefaultMarginCol, value))
                return "Invalid default margin";
            return null;
        }

        protected override void ValidateDeleting(ErrorList errors)
        {
            using (Ambient.DbSession.Activate())
            {
                List<Vendor> usages = OrderingRepositories.Vendor.GetBySubCategoryUse(CurrentEntity.Id);
                if (usages.Count > 0)
                    errors.Add(new SevereError("Product subcategory is in use"));
            }
        }
    }
}
