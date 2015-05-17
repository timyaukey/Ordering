using System;
using System.Collections.Generic;
using System.IO;
using Willowsoft.WillowLib.Data.Entity;
using Willowsoft.WillowLib.Data.Misc;
using Willowsoft.Ordering.Core.Entities;
using Willowsoft.Ordering.Core.Repositories;

namespace Willowsoft.Ordering.UI.Reports
{
    public class FaxOrderWriter : OrderReportWriter
    {

        protected override void StartBodyDetails()
        {
            StartBodyVendor(Vendor);
            StartBodyDetail("", "&nbsp;");
            StartBodyDetail("Order Date:", Order.OrderDate.ToShortDateString());
            StartBodyDetail("PO Number:", Order.Id.ToString());
        }

        public override void OutputTableHeader()
        {
            TableHeader("Quantity");
            TableHeader("Unit");
            TableHeader("Part Num");
            TableHeader("Description");
            TableHeader("Size");
            TableHeader("Brand");
        }

        public override void OutputLine(JoinPlToVpToProd line)
        {
            TableCellRight(line.PurLine_QtyOrdered.ToString());
            TableCellLeft(line.OrderingUnit);
            TableCellLeft(line.VendorProduct_VendorPartNum);
            TableCellLeft(line.Product_ProductName);
            TableCellLeft(line.NonBlankSize);
            TableCellLeft(line.BrandName);
        }

    }
}
