using AdventureWorks.Core.BusinessModels;
using System.Collections.Generic;

namespace AdventureWorks.Core.Abstractions.Operations
{
    public interface IProductOperations
    {
        IEnumerable<ProductViewModel> GetProduct();
    }
}
