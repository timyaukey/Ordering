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

        public static decimal NominalCaseCost(decimal caseCost, decimal caseCostOverride)
        {
            if (caseCost == 0m)
                return caseCostOverride;
            else if (caseCostOverride == 0m)
                return caseCost;
            else if (caseCostOverride < caseCost)
                return caseCostOverride;
            else
                return caseCost;
        }

        public static decimal NominalEachCost(decimal eachCost, decimal eachCostOverride)
        {
            if (eachCost == 0m)
                return eachCostOverride;
            else if (eachCostOverride == 0m)
                return eachCost;
            else if (eachCostOverride < eachCost)
                return eachCostOverride;
            else
                return eachCost;
        }

        public static decimal EachCostFromNominalCaseCost(int countInCase, decimal caseCost, decimal caseCostOverride)
        {
            if (countInCase == 0)
                return 0m;
            return (decimal)(NominalCaseCost(caseCost, caseCostOverride) / countInCase);
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
