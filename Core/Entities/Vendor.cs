using System;
using System.Collections.Generic;
using System.Text;
using Willowsoft.WillowLib.Data.Entity;
using Willowsoft.Ordering.Core.Repositories;
using Willowsoft.WillowLib.Data.Misc;

namespace Willowsoft.Ordering.Core.Entities
{
    public partial class Vendor
    {
        public override void Validate(ErrorList errors)
        {
            base.Validate(errors);
            ValidateLength(mVendorName, errors, 1, 100, "Vendor Name");
            ValidateLength(mTerms, errors, 0, 20, "Vendor Terms");
            ValidateLength(mShipping, errors, 0, 50, "Shipping Info");
            ValidateLength(mSortCode, errors, 0, 6, "Sort Code");
            ValidateLength(mNotes, errors, 0, 2048, "Notes");
            ValidateIntRange(mPriceCode.ToString(), 0, 99, errors, "Price Code");
        }

        public override string ToString()
        {
            return VendorName;
        }
    }

    public class VendorBindingList : EntityBindingList<Vendor, VendorId>
    {
        public VendorBindingList()
            : base(Ambient.DbSession, OrderingRepositories.Vendor)
        {
        }

        public override string EntityDisplayName
        {
            get { return "vendor"; }
        }
    }
}
