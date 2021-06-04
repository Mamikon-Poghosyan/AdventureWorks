using AdventureWorks.Core.Abstractions;
using AdventureWorks.Core.Abstractions.Repositories;
using AdventureWorks.DAL.Repositories;
using System.Data;
using System.Threading.Tasks;

namespace AdventureWorks.DAL
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly AdventureWorksLT2012Context _dbContext;
        public RepositoryManager(AdventureWorksLT2012Context dbContext)
        {
            _dbContext = dbContext;
        }
        public ICustomerRepository Customers => _Customers ?? (_Customers = new CustomerRepository(_dbContext));
        private IUserRepository _Users;
        public IUserRepository Users => _Users ?? (_Users = new UserRepository(_dbContext));
        private ICustomerRepository _Customers;
        public IProductRepository Products => _Products ?? (_Products = new ProductRepository(_dbContext));
        private IProductRepository _Products;
        public ISalesOrderHeaderRepository SalesOrderHeaders => _SalesOrderHeaders ?? (_SalesOrderHeaders = new SalesOrderHeaderRepository(_dbContext));
        private ISalesOrderHeaderRepository _SalesOrderHeaders;

        public IDatabaseTransaction BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            return new DatabaseTransaction(_dbContext, isolationLevel);
        }
        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
