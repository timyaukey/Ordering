using System;
using System.Collections.Generic;
using System.Text;
using Willowsoft.WillowLib.Data.Entity;
using Willowsoft.Ordering.Core.Entities;

namespace Willowsoft.Ordering.Core.Repositories
{
    public interface IProductCategoryRepository : IEntityRepository<ProductCategory, ProductCategoryId>
    {
        List<ProductCategory> GetAll();
    }
}
