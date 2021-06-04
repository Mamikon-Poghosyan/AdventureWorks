using AdventureWorks.Core.Abstractions.Repositories;
using AdventureWorks.Core.Entities;

namespace AdventureWorks.DAL.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(AdventureWorksLT2012Context dbContext)
            : base(dbContext)
        {
        }
    }
}
