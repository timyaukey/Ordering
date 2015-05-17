using System;
using System.Collections.Generic;
using Willowsoft.Ordering.Core.Entities;
using Willowsoft.Ordering.Core.Repositories;

namespace Willowsoft.Ordering.UI.Helpers
{
    public static class VendorProductHelper
    {
        public static void LoadForCategory(VendorId vendorId, ProductCategoryId productCategoryId,
            out Dictionary<int, Product> productDict, out List<VendorProduct> venprodList)
        {
            List<Product> products = OrderingRepositories.Product.Get(vendorId, productCategoryId);
            productDict = new Dictionary<int, Product>();
            foreach (Product product in products)
            {
                productDict.Add(product.Id.Value, product);
            }
            venprodList = OrderingRepositories.VendorProduct.Get(vendorId, productCategoryId);
        }
    }
}
