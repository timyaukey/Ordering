using System;
using System.Collections.Generic;
using System.Text;
using Willowsoft.WillowLib.Data.Entity;
using Willowsoft.Ordering.Core.Repositories;
using Willowsoft.WillowLib.Data.Misc;

namespace Willowsoft.Ordering.Core.Entities
{
    public partial class ProductBrand
    {
        public override void Validate(ErrorList errors)
        {
            base.Validate(errors);
            ValidateLength(mBrandName, errors, 1, 80, "Brand Name");
            ValidateLength(mNotes, errors, 0, 2048, "Notes");
        }

        public override string ToString()
        {
            return mBrandName;
        }
    }

    public class ProductBrandBindingList : EntityBindingList<ProductBrand, ProductBrandId>
    {
        public ProductBrandBindingList()
            : base(Ambient.DbSession, OrderingRepositories.ProductBrand)
        {
        }

        public override string EntityDisplayName
        {
            get { return "product brand"; }
        }
    }
}
