using AdventureWorks.Core.Abstractions;
using AdventureWorks.Core.Abstractions.Operations;
using AdventureWorks.Core.BusinessModels;
using System.Linq;
using System.Collections.Generic;

namespace AdventureWorks.BLL.Operations
{
    public class SalesOrderHeaderOperations : ISalesOrderHeaderOperations
    {
        private readonly IRepositoryManager _repositories;
        public SalesOrderHeaderOperations(IRepositoryManager repositories)
        {
            _repositories = repositories;
        }
        public IEnumerable<SalesOrderHeaderViewModel> GetSalesOrderHeader()
        {
            var data = _repositories.SalesOrderHeaders.GetAll();
            var result = data.Select(x => new SalesOrderHeaderViewModel
            {
                CustomerId = x.CustomerId,
                SalesOrderId = x.SalesOrderId
            });
            return result;
        }
    }
}
