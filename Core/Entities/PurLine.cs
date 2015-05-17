using System;
using System.Collections.Generic;
using System.Text;
using Willowsoft.WillowLib.Data.Entity;
using Willowsoft.Ordering.Core.Repositories;
using Willowsoft.WillowLib.Data.Misc;

namespace Willowsoft.Ordering.Core.Entities
{
    public partial class PurLine
    {
        public override void Validate(ErrorList errors)
        {
            base.Validate(errors);
            ValidateLength(mNotes, errors, 0, 2048, "Notes");
        }

        public override string ToString()
        {
            return "PurOrderId=" + this.PurOrderId + " VendorProductId=" + this.VendorProductId;
        }
    }
}
