using System;
using System.Collections.Generic;
using System.Text;
using Willowsoft.WillowLib.Data.Entity;
using Willowsoft.WillowLib.Data.Misc;
using Willowsoft.Ordering.Core.Repositories;

namespace Willowsoft.Ordering.Core.Entities
{
    public partial class ProductSubCategory
    {
        public override void Validate(Willowsoft.WillowLib.Data.Misc.ErrorList errors)
        {
            base.Validate(errors);
            ValidateLength(mSubCategoryName, errors, 1, 40, "Subcategory Name");
            ValidateLength(mSortCode, errors, 1, 6, "Sort Code");
            ValidateLength(mNotes, errors, 0, 2048, "Notes");
            ValidateIdRequired(mProductCategoryId, errors, "Product Category");
            ValidateIntRange(mDefaultProfitMargin.ToString(), 0, 99, errors, "Default Profit Margin");
        }

        public override string ToString()
        {
            return mSubCategoryName;
        }
    }

    public class ProductSubCategoryBindingList : EntityBindingList<ProductSubCategory, ProductSubCategoryId>
    {
        public ProductSubCategoryBindingList()
            : base(Ambient.DbSession, OrderingRepositories.ProductSubCategory)
        {
        }

        public override string EntityDisplayName
        {
            get { return "product subcategory"; }
        }
    }
}
