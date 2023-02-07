using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pizzeriaserver.Models;

namespace pizzeriaserver.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        [HttpGet]
        public List<Pizza> GetAll()
        {
            return new List<Pizza>();
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            return Ok(new Pizza() { Id = id });
        }
    }
}
