using System;
using System.Collections.Generic;
using Willowsoft.WillowLib.Data.Entity;
using Willowsoft.Ordering.Core.Entities;

namespace Willowsoft.Ordering.Core.Repositories
{
    public interface IPurOrderRepository : IEntityRepository<PurOrder, PurOrderId>
    {
        List<PurOrder> Get(DateTime startDate, DateTime endDate);
        List<PurOrderSummary> GetByVendorProduct(VendorProductId vendorProductId);
    }

    public class PurOrderSummary
    {
        public VendorId VendorId { get; set; }
        public PurOrderId PurOrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int QtyOrdered { get; set; }
        public bool OrderedEaches { get; set; }
        public int EachesEquivalent { get; set; }
    }
}
