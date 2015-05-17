using System;
using System.Collections.Generic;
using System.Text;
using Willowsoft.WillowLib.Data.Entity;
using Willowsoft.Ordering.Core.Entities;

namespace Willowsoft.Ordering.Core.Repositories
{
    public interface IProductBrandRepository : IEntityRepository<ProductBrand, ProductBrandId>
    {
        List<ProductBrand> GetAll();
    }
}
