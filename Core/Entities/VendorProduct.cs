using System;
using System.Collections.Generic;
using System.Text;
using Willowsoft.WillowLib.Data.Entity;
using Willowsoft.Ordering.Core.Repositories;
using Willowsoft.WillowLib.Data.Misc;

namespace Willowsoft.Ordering.Core.Entities
{
    public partial class VendorProduct
    {
        public override void Validate(ErrorList errors)
        {
            base.Validate(errors);
            ValidateIdRequired(mVendorId, errors, "Vendor");
            ValidateLength(mVendorPartNum, errors, 1, 30, "Vendor Code");
            if (mCaseCost > 0m && mCountInCase == 0)
                errors.Add(new EntityValidationError("Case size is required if case cost is specified"));
        }

        public static double ComputeMargin(decimal eachRetail, decimal eachCostWithoutFreight, double freightPercent)
        {
            if (eachRetail == 0m)
                return 0.0;
            double freightMultiplier = 1.0 + freightPercent;
            decimal costWithFreight = (decimal)((double)eachCostWithoutFreight * freightMultiplier);
            //return System.Math.Round(100.0 * (double)((eachRetail - costWithFreight) / eachRetail), 1);
            return (double)((eachRetail - costWithFreight) / eachRetail);
        }

        public static string MarginFormat
        {
            get { return "##0.0%"; }
        }

        public override string ToString()
        {
            return string.Format("Id:{0} VendorId:{1} ProductId:{2} VendorPartNum:{3}",
                Id.Value, VendorId.Value, ProductId.Value, VendorPartNum);
        }
    }
}
