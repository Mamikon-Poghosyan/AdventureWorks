using AdventureWorks.Core.Abstractions.Repositories;
using AdventureWorks.Core.Entities;

namespace AdventureWorks.DAL.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(AdventureWorksLT2012Context dbContext)
            : base(dbContext)
        {
        }
    }
}
