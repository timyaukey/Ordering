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
    public partial class SqlVendorRepository
    {
        public SqlVendorRepository(SqlDbSession session)
            : base(session)
        {
        }

        #region IVendorRepository Members

        public List<Vendor> GetAll()
        {
            return Search("dbo.GetAllVendors", delegate(SqlCommand cmd) { });
        }

        public List<Vendor> GetBySubCategoryUse(ProductSubCategoryId subCategoryId)
        {
            return Search("dbo.GetVendorsBySubCategoryUse", delegate(SqlCommand cmd)
            {
                SqlHelper.AddParamInputId(cmd, "@ProductSubCategoryId", subCategoryId.Value);
            });
        }

        #endregion

    }
}
