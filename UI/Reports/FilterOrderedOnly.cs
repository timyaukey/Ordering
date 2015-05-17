using System;
using System.Collections.Generic;
using Willowsoft.WillowLib.Data.Entity;
using Willowsoft.WillowLib.Data.Misc;
using Willowsoft.Ordering.Core.Entities;
using Willowsoft.Ordering.Core.Repositories;

namespace Willowsoft.Ordering.UI.Reports
{
    public class FilterOrderedOnly : IOrderReportFilter
    {
        #region IOrderReportFilter Members

        public void StartReport(PurOrder order)
        {
        }

        public bool IncludeLine(JoinPlToVpToProd line)
        {
            return line.PurLine_QtyOrdered > 0;
        }

        #endregion
    }
}
