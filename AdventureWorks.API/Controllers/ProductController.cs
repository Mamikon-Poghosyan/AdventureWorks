using AdventureWorks.Core.Abstractions.Operations;
using Microsoft.AspNetCore.Mvc;

namespace AdventureWorks.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductOperations _ProductOperations;
        public ProductController(IProductOperations ProductOperations)
        {
            _ProductOperations = ProductOperations;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var req = _ProductOperations.GetProduct();
            return Ok(req);
        }
    }
}
