using System;
using System.Collections.Generic;
using System.IO;
using Willowsoft.WillowLib.Data.Entity;
using Willowsoft.WillowLib.Data.Misc;
using Willowsoft.Ordering.Core.Entities;
using Willowsoft.Ordering.Core.Repositories;

namespace Willowsoft.Ordering.UI.Reports
{
    public interface IOrderReportWriter
    {
        void Init(string title, PurOrder order, Vendor vendor, TextWriter writer);
        void AddToStylesheet();
        void StartBody();
        void OutputTableHeader();
        void OutputLine(JoinPlToVpToProd line);
    }
}
