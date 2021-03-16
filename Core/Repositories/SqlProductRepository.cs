using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;
using Willowsoft.WillowLib.Data.Misc;
using Willowsoft.WillowLib.Data.Entity;
using Willowsoft.WillowLib.Data.Sql;
using Willowsoft.Ordering.Core;
using Willowsoft.Ordering.Core.Entities;

namespace Willowsoft.Ordering.Core.Repositories
{
    public partial class SqlProductRepository
    {
        public SqlProductRepository(SqlDbSession session)
            : base(session)
        {
        }

        #region IProductRepository Members

        public List<Product> Get(VendorId vendorId)
        {
            return Search("dbo.GetProductsByVendor",
                delegate (SqlCommand cmd)
                {
                    SqlHelper.AddParamInputId(cmd, "@VendorId", vendorId.Value);
                });
        }

        public List<Product> Get(VendorId vendorId, ProductCategoryId productCategoryId)
        {
            return Search("dbo.GetProductsByVendorCategory",
                delegate(SqlCommand cmd)
                {
                    SqlHelper.AddParamInputId(cmd, "@VendorId", vendorId.Value);
                    SqlHelper.AddParamInputId(cmd, "@ProductCategoryId", productCategoryId.Value);
                });
        }

        public List<Product> Get(ProductBrandId brandId, ProductCategoryId productCategoryId)
        {
            return Search("dbo.GetProductsByBrandCategory",
                delegate(SqlCommand cmd)
                {
                    SqlHelper.AddParamInputId(cmd, "@BrandId", brandId.Value);
                    SqlHelper.AddParamInputId(cmd, "@ProductCategoryId", productCategoryId.Value);
                });
        }

        public List<Product> Get(ProductBrandId brandId, string productName, string size)
        {
            return Search("dbo.GetProductsByBrandNameSize",
                delegate(SqlCommand cmd)
                {
                    SqlHelper.AddParamInputId(cmd, "@BrandId", brandId.Value);
                    SqlHelper.AddParamVarchar(cmd, "@ProductName", productName);
                    SqlHelper.AddParamVarchar(cmd, "@Size", size);
                });
        }

        #endregion

    }
}
