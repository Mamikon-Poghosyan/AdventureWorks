using AdventureWorks.Core.Abstractions;
using AdventureWorks.Core.Abstractions.Operations;
using AdventureWorks.Core.BusinessModels;
using AdventureWorks.Core.Exceptions;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace AdventureWorks.BLL.Operations
{
    public class CustomerOperations : ICustomerOperations
    {
        private readonly IRepositoryManager _repositories;
        private readonly ILogger<CustomerOperations> _logger;
        public CustomerOperations(IRepositoryManager repositories, ILogger<CustomerOperations> logger)
        {
            _repositories = repositories;
            _logger = logger;
        }
        public IEnumerable<CustomerViewModel> GetCustomers()
        {
            var data = _repositories.Customers.GetAll();
            var result = data.Select(x => new CustomerViewModel
            {
                CustomerId = x.CustomerId,
                FirstName = x.FirstName,
                LastName = x.LastName,
                CompanyName = x.CompanyName
            });
            return result;
        }
        public CustomerViewModel GetOrder(int id)
        {
            _logger.LogInformation("OrderOperations --- GetOrder method started");
            var customer = _repositories.Customers.Get(id) ?? throw new LogicException("Wrong Cusromer Id");
            _logger.LogInformation("OrderOperations --- GetOrder method finished");
            return new CustomerViewModel
            {
                CustomerId = customer.CustomerId,
                CompanyName = customer.CompanyName,
                FirstName = customer.FirstName,
                LastName = customer.LastName
            };
        }
        public void Test()
        {   // TRANZACTION
            using (var transaction = _repositories.BeginTransaction())
            {
                try
                {
                    //add
                    //remove
                    //delete
                    _repositories.SaveChanges();
                    transaction.Commit();
                }
                catch (System.Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
