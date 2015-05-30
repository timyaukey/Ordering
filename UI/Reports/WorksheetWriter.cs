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
            TableHeader("Levels");
        }

        public override void OutputLine(JoinPlToVpToProd line)
        {
            TableCellLeft(line.SubCategoryName);
            TableCellRight(line.PurLine_QtyOnHand.ToString());
            TableCellRight(line.PurLine_QtyOrdered.ToString());
            TableCellLeft(line.OrderingUnit);
            TableCellLeft(line.ProductNameAndModel);
            TableCellLeft(line.NonBlankSize);
            TableCellLeft(line.BrandName);
            string levels = string.Empty;
            string busyLevels = string.Empty;
            string slowLevels = string.Empty;
            if (line.Product_QtyBusyMin != 0 || line.Product_QtyBusyMax != 0)
                busyLevels = line.Product_QtyBusyMin.ToString() + "/" + line.Product_QtyBusyMax.ToString();
            if (line.Product_QtySlowMin != 0 || line.Product_QtySlowMax != 0)
                slowLevels = line.Product_QtySlowMin.ToString() + "/" + line.Product_QtySlowMax.ToString();
            if (busyLevels == string.Empty)
                levels = slowLevels;
            else if (slowLevels == string.Empty)
                levels = busyLevels;
            else
                levels = busyLevels + ":" + slowLevels;
            TableCellLeft(levels);
        }

    }
}
