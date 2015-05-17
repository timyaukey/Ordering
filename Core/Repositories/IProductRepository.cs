using System;
using System.Collections.Generic;
using System.Text;
using Willowsoft.WillowLib.Data.Entity;
using Willowsoft.Ordering.Core.Entities;

namespace Willowsoft.Ordering.Core.Repositories
{
    public interface IProductRepository : IEntityRepository<Product, ProductId>
    {
        List<Product> Get(VendorId vendorId, ProductCategoryId productCategoryId);
        List<Product> Get(ProductBrandId brandId, ProductCategoryId productCategoryId);
        List<Product> Get(ProductBrandId brandId, string productName, string productSize);
    }
}
