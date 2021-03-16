using System;
using System.Collections.Generic;
using Willowsoft.Ordering.Core.Entities;
using Willowsoft.Ordering.Core.Repositories;

namespace Willowsoft.Ordering.UI.Helpers
{
    public static class VendorProductHelper
    {
        public const int AllCategoriesId = -1;

        public static void LoadForCategory(VendorId vendorId, ProductCategoryId productCategoryId,
            out Dictionary<int, Product> productDict, out List<VendorProduct> venprodList)
        {
            List<Product> products = OrderingRepositories.Product.Get(vendorId, productCategoryId);
            productDict = MakeProductDictionary(products);
            venprodList = OrderingRepositories.VendorProduct.Get(vendorId, productCategoryId);
        }

        public static void LoadForAllCategories(VendorId vendorId,
            out Dictionary<int, Product> productDict, out List<VendorProduct> venprodList)
        {
            List<Product> products = OrderingRepositories.Product.Get(vendorId);
            productDict = MakeProductDictionary(products);
            venprodList = OrderingRepositories.VendorProduct.Get(vendorId);
        }

        private static Dictionary<int, Product> MakeProductDictionary(IEnumerable<Product> products)
        {
            Dictionary<int, Product>  productDict = new Dictionary<int, Product>();
            foreach (Product product in products)
            {
                productDict.Add(product.Id.Value, product);
            }
            return productDict;
        }
    }
}
