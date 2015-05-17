using System;
using System.Collections.Generic;
using Willowsoft.WillowLib.Data.Entity;
using Willowsoft.WillowLib.Data.Misc;
using Willowsoft.Ordering.Core.Entities;
using Willowsoft.Ordering.Core.Repositories;

namespace Willowsoft.Ordering.UI.Reports
{
    public interface IOrderReportFilter
    {
        void StartReport(PurOrder order);
        bool IncludeLine(JoinPlToVpToProd line);
    }
}
