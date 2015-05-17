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
    public partial class SqlVendorProductRepository
    {
        public SqlVendorProductRepository(SqlDbSession session)
            : base(session)
        {
        }

        #region IVendorProductRepository Members

        public List<VendorProduct> Get(VendorId vendorId, ProductCategoryId productCategoryId)
        {
            return Search("dbo.GetVendorProductsByVendorCategory",
                delegate(SqlCommand cmd)
                {
                    SqlHelper.AddParamInputId(cmd, "@VendorId", vendorId.Value);
                    SqlHelper.AddParamInputId(cmd, "@ProductCategoryId", productCategoryId.Value);
                });
        }

        public List<VendorProduct> Get(VendorId vendorId, string vendorPartNum)
        {
            return Search("dbo.GetVendorProductsByPartNum",
                delegate(SqlCommand cmd)
                {
                    SqlHelper.AddParamInputId(cmd, "@VendorId", vendorId.Value);
                    SqlHelper.AddParamVarchar(cmd, "@VendorPartNum", vendorPartNum);
                });
        }

        public List<VendorProduct> Get(ProductId productId)
        {
            return Search("dbo.GetVendorProductsByProduct",
                delegate(SqlCommand cmd)
                {
                    SqlHelper.AddParamInputId(cmd, "@ProductId", productId.Value);
                });
        }

        public List<BrandUsageSummary> Get(ProductBrandId productBrandId)
        {
            List<BrandUsageSummary> results = new List<BrandUsageSummary>();
            using (PooledConnection pooledCon = GetPooledConnection())
            {
                using (SqlCommand cmd = SqlHelper.CreateProc("dbo.GetVendorCategoryByBrand", pooledCon))
                {
                    SqlHelper.AddParamInputId(cmd, "@ProductBrandId", productBrandId.Value);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            BrandUsageSummary sum = new BrandUsageSummary();
                            sum.VendorId = new VendorId((int)reader["VendorId"]);
                            sum.CategoryId = new ProductCategoryId((int)reader["ProductCategoryId"]);
                            results.Add(sum);
                        }
                    }
                }
            }
            return results;
        }

        #endregion

    }
}
