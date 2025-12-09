using Domain.Entities;
using Domain.Ports.Primary;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/productos")]
    public class ProductApiController : ControllerBase
    {
        private readonly IService _service;

        public ProductApiController(IService service)
        {
            _service = service;
        }

        [HttpGet(Name ="ListProduct")]
        public IActionResult GetAll()
        {
            var products = _service.GetAll();
            return Ok(products);
        }

        [HttpPost("registro")]
        public IActionResult Register(string name, decimal price)
        {
            _service.Register(name, price);
            return Ok();
        }
    }
}
