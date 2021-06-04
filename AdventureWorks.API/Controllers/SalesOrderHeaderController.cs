using AdventureWorks.Core.Abstractions.Operations;
using Microsoft.AspNetCore.Mvc;

namespace AdventureWorks.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalesOrderHeaderController : ControllerBase
    {
        private readonly ISalesOrderHeaderOperations _SalesOrderHeaderOperations;
        public SalesOrderHeaderController(ISalesOrderHeaderOperations SalesOrderHeaderOperations)
        {
            _SalesOrderHeaderOperations = SalesOrderHeaderOperations;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var req = _SalesOrderHeaderOperations.GetSalesOrderHeader();
            return Ok(req);
        }
    }
}
