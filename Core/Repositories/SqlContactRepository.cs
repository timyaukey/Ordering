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
    public partial class SqlContactRepository
    {
        public SqlContactRepository(SqlDbSession session)
            : base(session)
        {
        }

        #region IContactRepository Members

        public List<Contact> GetAll()
        {
            return Search("dbo.GetAllContacts", delegate(SqlCommand cmd) { });
        }

        #endregion

    }
}
