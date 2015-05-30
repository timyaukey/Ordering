using System;
using System.Collections.Generic;
using System.IO;
using Willowsoft.WillowLib.Data.Entity;
using Willowsoft.WillowLib.Data.Misc;
using Willowsoft.Ordering.Core.Entities;
using Willowsoft.Ordering.Core.Repositories;

namespace Willowsoft.Ordering.UI.Reports
{
    public class CheckInWriter : OrderReportWriter
    {

        protected override void StartBodyDetails()
        {
            StartBodyVendor(Vendor);
            StartBodyDetail("", "&nbsp;");
            StartBodyDetail("Order Date:", Order.OrderDate.ToShortDateString());
            StartBodyDetail("PO Number:", Order.Id.ToString());
            StartBodyDetail("Freight:", Order.Freight.ToString("c"));
        }

        public override void OutputTableHeader()
        {
            //TableHeader("Subcategory");
            TableHeader("Part Num");
            TableHeader("Qty<br>Ord");
            TableHeader("Ord<br>Unit");
            TableHeader("Description");
            TableHeader("Size");
            TableHeader("Brand");
            TableHeader("Retail");
            //TableHeader("Vend<br>Rtl");
            //TableHeader("Margin");
            //TableHeader("Vend<br>Marg");
            TableHeader("Cost Per<br>Unit Ord");
            TableHeader("Each<br>Cost");
        }

        public override void OutputLine(JoinPlToVpToProd line)
        {
            //TableCellLeft(line.SubCategoryName);
            TableCellLeftHilite(line.PurLine_VendorPartNum);
            TableCellRight(line.PurLine_QtyOrdered.ToString());
            TableCellLeft(line.OrderingUnit);
            TableCellLeft(line.ProductNameAndModel);
            TableCellLeft(line.NonBlankSize);
            TableCellLeft(line.BrandName);
            TableCellRightHilite(line.PurLine_RetailPrice.ToString("c"));
            /*
            string vendorRetail = "(same)";
            if (line.VendorProduct_RetailPriceOverride > 0)
                vendorRetail = line.VendorProduct_RetailPriceOverride.ToString("c");
            TableCellRight(vendorRetail);
            TableCellRight((line.BestNormalMargin*100.0D).ToString("F1") + "%");
            string vendorMargin = "(same)";
            if (line.BestVendorMargin != line.BestNormalMargin)
                vendorMargin = (line.BestVendorMargin*100.0D).ToString("F1") + "%";
            TableCellRight(vendorMargin);
            */
            TableCellRight(line.CostPerUnitOrdered.ToString("c"));
            TableCellRight(line.BestEachCost.ToString("c"));
        }

    }
}
