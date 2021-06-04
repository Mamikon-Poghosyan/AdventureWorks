using AdventureWorks.Core.Abstractions.Repositories;
using System.Data;
using System.Threading.Tasks;

namespace AdventureWorks.Core.Abstractions
{
    public interface IRepositoryManager
    {
        IUserRepository Users { get; }
        ICustomerRepository Customers { get; }
        IProductRepository Products { get; }
        ISalesOrderHeaderRepository SalesOrderHeaders { get; }
        public IDatabaseTransaction BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
