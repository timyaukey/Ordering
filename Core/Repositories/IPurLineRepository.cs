using System;
using System.Collections.Generic;
using Willowsoft.WillowLib.Data.Entity;
using Willowsoft.Ordering.Core.Entities;

namespace Willowsoft.Ordering.Core.Repositories
{
    public interface IPurLineRepository : IEntityRepository<PurLine, PurLineId>
    {
        List<PurLine> Get(PurOrderId orderId);
        List<PurLine> GetInShelfOrder(PurOrderId orderId);
        void AddCategory(PurOrderId orderId, ProductCategoryId categoryId, bool includeInactive);
        int RemoveCategory(PurOrderId orderId, ProductCategoryId categoryId);
        List<ProductCategory> GetCategories(PurOrderId orderId);
        void RefreshFromDefinitions(VendorId vendorId);
        void SaveToDefinitions(PurOrderId orderId);
    }
}
