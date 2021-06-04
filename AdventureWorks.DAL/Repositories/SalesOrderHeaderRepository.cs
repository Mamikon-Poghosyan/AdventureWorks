using AdventureWorks.Core.Abstractions.Repositories;
using AdventureWorks.Core.Entities;

namespace AdventureWorks.DAL.Repositories
{
    public class SalesOrderHeaderRepository : RepositoryBase<SalesOrderHeader>, ISalesOrderHeaderRepository
    {
        public SalesOrderHeaderRepository(AdventureWorksLT2012Context dbContex)
            : base(dbContex)
        {
        }
    }
}
