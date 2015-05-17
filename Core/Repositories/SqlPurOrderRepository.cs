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
    public partial class SqlPurOrderRepository
    {
        public SqlPurOrderRepository(SqlDbSession session)
            : base(session)
        {
        }

        #region IPurOrderRepository Members

        public List<PurOrder> Get(DateTime startDate, DateTime endDate)
        {
            return Search("dbo.GetPurOrderByOrderDate",
                delegate(SqlCommand cmd)
                {
                    SqlHelper.AddParamDatetime(cmd, "@StartDate", startDate);
                    SqlHelper.AddParamDatetime(cmd, "@EndDate", endDate);
                });
        }

        public List<PurOrderSummary> GetByVendorProduct(VendorProductId vendorProductId)
        {
            List<PurOrderSummary> results = new List<PurOrderSummary>();
            using (PooledConnection pooledCon = GetPooledConnection())
            {
                using (SqlCommand cmd = SqlHelper.CreateProc("dbo.GetPurOrderByVendorProduct", pooledCon))
                {
                    SqlHelper.AddParamInputId(cmd, "@VendorProductId", vendorProductId.Value);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            PurOrderSummary sum = new PurOrderSummary();
                            sum.VendorId = new VendorId((int)reader["VendorId"]);
                            sum.PurOrderId = new PurOrderId((int)reader["PurOrderId"]);
                            sum.OrderDate = (DateTime)reader["OrderDate"];
                            sum.QtyOrdered = (int)reader["QtyOrdered"];
                            object orderedEaches = reader["OrderedEaches"];
                            sum.OrderedEaches = (byte)orderedEaches != 0;
                            if (sum.OrderedEaches)
                                sum.EachesEquivalent = sum.QtyOrdered;
                            else
                                sum.EachesEquivalent = sum.QtyOrdered * (int)reader["CountInCase"];
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
