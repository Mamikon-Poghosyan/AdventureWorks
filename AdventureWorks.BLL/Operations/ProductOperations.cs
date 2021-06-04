using AdventureWorks.Core.Abstractions;
using AdventureWorks.Core.Abstractions.Operations;
using AdventureWorks.Core.BusinessModels;
using System.Collections.Generic;
using System.Linq;

namespace AdventureWorks.BLL.Operations
{
    public class ProductOperations : IProductOperations
    {
        private readonly IRepositoryManager _repositoryes;
        public ProductOperations(IRepositoryManager repositoryes)
        {
            _repositoryes = repositoryes;
        }
        public IEnumerable<ProductViewModel> GetProduct()
        {
            var data = _repositoryes.Products.GetAll();
            var result = data.Select(x => new ProductViewModel
            {
                Name = x.Name,
                ProductNumber = x.ProductNumber,
                Color = x.Color
            });
            return result;
        }
    }
}
