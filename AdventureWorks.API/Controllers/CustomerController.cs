using AdventureWorks.Core.Abstractions.Operations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdventureWorks.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerOperations _customerOperation;
        public CustomerController(ICustomerOperations customerOperation)
        {
            _customerOperation = customerOperation;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var req = _customerOperation.GetCustomers();
            return Ok(req);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var result = _customerOperation.GetOrder(id);
            return Ok(result);
        }
    }
}
