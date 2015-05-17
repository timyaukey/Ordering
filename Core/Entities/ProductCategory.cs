using System;
using System.Collections.Generic;
using System.Text;
using Willowsoft.WillowLib.Data.Entity;
using Willowsoft.WillowLib.Data.Misc;
using Willowsoft.Ordering.Core.Repositories;

namespace Willowsoft.Ordering.Core.Entities
{
    public partial class ProductCategory
    {
        public override void Validate(Willowsoft.WillowLib.Data.Misc.ErrorList errors)
        {
            base.Validate(errors);
            ValidateLength(mCategoryName, errors, 1, 40, "Category Name");
            ValidateLength(mSortCode, errors, 1, 4, "Sort Code");
            ValidateLength(mNotes, errors, 0, 2048, "Notes");
        }

        public override string ToString()
        {
            return mCategoryName;
        }
    }

    public class ProductCategoryBindingList : EntityBindingList<ProductCategory, ProductCategoryId>
    {
        public ProductCategoryBindingList()
            : base(Ambient.DbSession, OrderingRepositories.ProductCategory)
        {
        }

        public override string EntityDisplayName
        {
            get { return "product category"; }
        }
    }
}
