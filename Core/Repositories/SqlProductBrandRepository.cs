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
    public partial class SqlProductBrandRepository
    {
        public SqlProductBrandRepository(SqlDbSession session)
            : base(session)
        {
        }

        #region IProductBrandRepository Members

        public List<ProductBrand> GetAll()
        {
            return Search("dbo.GetAllProductBrands", delegate(SqlCommand cmd) { });
        }

        #endregion

    }
}
