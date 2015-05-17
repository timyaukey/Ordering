using System;
using System.Collections.Generic;
using System.Text;
using Willowsoft.WillowLib.Data.Entity;
using Willowsoft.Ordering.Core.Repositories;
using Willowsoft.WillowLib.Data.Misc;

namespace Willowsoft.Ordering.Core.Entities
{
    public partial class PurOrder
    {
        private decimal mUnpersistedTotal = 0m;

        /// <summary>
        /// Total cost of PurOrder, including freight.
        /// Intended for temporary use in calculations,
        /// so is not persisted.
        /// </summary>
        public decimal UnpersistedTotal
        {
            get { return mUnpersistedTotal; }
            set { mUnpersistedTotal = value; }
        }

        public override void Validate(ErrorList errors)
        {
            base.Validate(errors);
            ValidateLength(mNotes, errors, 0, 2048, "Notes");
            ValidateLength(mTerms, errors, 0, 20, "Terms");
            ValidateLength(mCreatedBy, errors, 0, 20, "Created By");
            ValidateIdRequired(mVendorId, errors, "Vendor");
            ValidateIntRange(mDiscount.ToString(), 0, 100, errors, "Discount");
        }

        public override string ToString()
        {
            return "VendorId=" + this.VendorId +
                " OrderDate=" + this.OrderDate.ToString("d") +
                " OrderNumber=" + this.OrderNumber;
        }
    }

    public class PurOrderBindingList : EntityBindingList<PurOrder, PurOrderId>
    {
        public PurOrderBindingList()
            : base(Ambient.DbSession, OrderingRepositories.PurOrder)
        {
        }

        public override string EntityDisplayName
        {
            get { return "order"; }
        }
    }
}
