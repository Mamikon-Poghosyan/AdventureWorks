using AdventureWorks.Core.BusinessModels;
using System.Collections.Generic;

namespace AdventureWorks.Core.Abstractions.Operations
{
    public interface ICustomerOperations
    {
        IEnumerable<CustomerViewModel> GetCustomers();
        CustomerViewModel GetOrder(int id);
    }
}
