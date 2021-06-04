using AdventureWorks.Core.BusinessModels;
using System.Collections.Generic;

namespace AdventureWorks.Core.Abstractions.Operations
{
    public interface ISalesOrderHeaderOperations
    {
        IEnumerable<SalesOrderHeaderViewModel> GetSalesOrderHeader();
    }
}
