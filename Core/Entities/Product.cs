using System;
using System.Collections.Generic;
using System.Text;
using Willowsoft.WillowLib.Data.Entity;
using Willowsoft.Ordering.Core.Repositories;

namespace Willowsoft.Ordering.Core.Entities
{
    public partial class Product
    {
        public override void Validate(Willowsoft.WillowLib.Data.Misc.ErrorList errors)
        {
            base.Validate(errors);
            ValidateLength(mProductName, errors, 1, 100, "Product Name");
            ValidateIdRequired(mProductSubCategoryId, errors, "Product Subcategory");
            ValidateIdRequired(mProductBrandId, errors, "Product Brand");
            ValidateLength(mSize, errors, 0, 30, "Size");
            ValidateDecimalRange(mRetailPrice.ToString(), 0m, 999999.99m, 2, errors, "Retail Price");
            ValidateLength(mManufacturerBarcode, errors, 0, 30, "Manufacturer Barcode");
            ValidateLength(mManufacturerPartNum, errors, 0, 30, "Manufacturer Part Number");
        }

        public override string ToString()
        {
            return mProductName + " " + mSize;
        }
    }
}
