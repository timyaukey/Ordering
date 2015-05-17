using System;
using System.Collections.Generic;
using System.IO;
using Willowsoft.WillowLib.Data.Entity;
using Willowsoft.WillowLib.Data.Misc;
using Willowsoft.Ordering.Core.Entities;
using Willowsoft.Ordering.Core.Repositories;

namespace Willowsoft.Ordering.UI.Reports
{
    public class WorksheetWriter : OrderReportWriter
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
            TableHeader("Subcategory");
            TableHeader("Eaches<br>On Hand");
            TableHeader("Qty<br>Ordered");
            TableHeader("Ordering<br>Unit");
            TableHeader("Description");
            TableHeader("Size");
            TableHeader("Brand");
        }

        public override void OutputLine(JoinPlToVpToProd line)
        {
            TableCellLeft(line.SubCategoryName);
            TableCellRight(line.PurLine_QtyOnHand.ToString());
            TableCellRight(line.PurLine_QtyOrdered.ToString());
            TableCellLeft(line.OrderingUnit);
            TableCellLeft(line.Product_ProductName);
            TableCellLeft(line.NonBlankSize);
            TableCellLeft(line.BrandName);
        }

    }
}
