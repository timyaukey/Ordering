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
    public partial class SqlPurLineRepository
    {
        private SqlProductCategoryRepository mCategoryRep;

        public SqlPurLineRepository(SqlDbSession session, SqlProductCategoryRepository categoryRep)
            : base(session)
        {
            mCategoryRep = categoryRep;
        }

        #region IPurLineRepository Members

        public List<PurLine> Get(PurOrderId orderId)
        {
            return Search("dbo.GetPurLineByPurOrder",
                delegate(SqlCommand cmd)
                {
                    SqlHelper.AddParamInputId(cmd, "@OrderId", orderId.Value);
                });
        }

        public List<PurLine> GetInShelfOrder(PurOrderId orderId)
        {
            return Search("dbo.GetPurLineByShelfOrder",
                delegate(SqlCommand cmd)
                {
                    SqlHelper.AddParamInputId(cmd, "@OrderId", orderId.Value);
                });
        }

        public void AddCategory(PurOrderId orderId, ProductCategoryId categoryId, bool includeInactive)
        {
            ExecuteNonQuery("dbo.PurLineAddCategory",
                delegate(SqlCommand cmd)
                {
                    SqlHelper.AddParamInputId(cmd, "@OrderId", orderId.Value);
                    SqlHelper.AddParamInputId(cmd, "@CategoryId", categoryId.Value);
                    SqlHelper.AddParamInt(cmd, "@IncludeInactive", includeInactive ? 1 : 0);
                });
        }

        public int RemoveCategory(PurOrderId orderId, ProductCategoryId categoryId)
        {
            SqlParameter outputParam = null;
            ExecuteNonQuery("dbo.PurLineRemoveCategory",
                delegate(SqlCommand cmd)
                {
                    SqlHelper.AddParamInputId(cmd, "@OrderId", orderId.Value);
                    SqlHelper.AddParamInputId(cmd, "@CategoryId", categoryId.Value);
                    outputParam = SqlHelper.AddParamOutputInt(cmd, "@LinesRemaining");
                });
            return (int)outputParam.Value;
        }

        public List<ProductCategory> GetCategories(PurOrderId orderId)
        {
            return mCategoryRep.Search("dbo.PurLineGetCategories",
                delegate(SqlCommand cmd)
                {
                    SqlHelper.AddParamInputId(cmd, "@OrderId", orderId.Value);
                });
        }

        public void RefreshFromDefinitions(VendorId vendorId)
        {
            ExecuteNonQuery("dbo.PurLineRefreshFromDefinitions",
                delegate (SqlCommand cmd)
                {
                    SqlHelper.AddParamInputId(cmd, "@VendorId", vendorId.Value);
                });
        }

        public void SaveToDefinitions(PurOrderId orderId)
        {
            ExecuteNonQuery("dbo.PurLineSaveToDefinitions",
                delegate (SqlCommand cmd)
                {
                    SqlHelper.AddParamInputId(cmd, "@OrderId", orderId.Value);
                });
        }

        #endregion

    }
}
