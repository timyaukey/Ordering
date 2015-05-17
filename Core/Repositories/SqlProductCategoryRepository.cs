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
    public partial class SqlProductCategoryRepository
    {
        public SqlProductCategoryRepository(SqlDbSession session)
            : base(session)
        {
        }

        #region IProductCategoryRepository Members

        public List<ProductCategory> GetAll()
        {
            return Search("dbo.GetAllProductCategories", delegate(SqlCommand cmd) { });
        }

        #endregion

    }
}
