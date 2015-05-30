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
            ValidateLength(mProductName, errors, 5, 100, "Product Name");
            ValidateIdRequired(mProductBrandId, errors, "Product Brand");
            ValidateIdRequired(mProductSubCategoryId, errors, "Product Subcategory");
            ValidateLength(mSize, errors, 0, 30, "Size");
            ValidateDecimalRange(mRetailPrice.ToString(), 0m, 999999.99m, 2, errors, "Retail Price");
            ValidateLength(mManufacturerBarcode, errors, 0, 30, "Manufacturer Barcode");
            ValidateLength(mManufacturerPartNum, errors, 0, 30, "Manufacturer Part Number");
            ValidateLength(mVendorPartNum, errors, 1, 30, "Vendor Code");
            if (mCaseCost > 0m && mCountInCase == 0)
                errors.Add(new EntityValidationError("Case size is required if case cost is specified"));
            ValidateLength(mNotes, errors, 0, 2048, "Notes");
        }

        public override string ToString()
        {
            return "PurOrderId=" + this.PurOrderId + " VendorProductId=" + this.VendorProductId +
                " Name=" + this.ProductName + " Qty=" + this.QtyOrdered;
        }
    }
}
