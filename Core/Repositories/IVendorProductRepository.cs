using System;
using System.Collections.Generic;
using System.Text;
using Willowsoft.WillowLib.Data.Entity;
using Willowsoft.Ordering.Core.Entities;

namespace Willowsoft.Ordering.Core.Repositories
{
    public interface IVendorProductRepository : IEntityRepository<VendorProduct, VendorProductId>
    {
        List<VendorProduct> Get(VendorId vendorId);
        List<VendorProduct> Get(VendorId vendorId, ProductCategoryId productCategoryId);
        List<VendorProduct> Get(VendorId vendorId, string vendorPartNum);
        List<VendorProduct> Get(ProductId productId);
        List<BrandUsageSummary> Get(ProductBrandId productBrandId);
    }

    public class BrandUsageSummary
    {
        public VendorId VendorId { get; set; }
        public ProductCategoryId CategoryId { get; set; }
    }
}
