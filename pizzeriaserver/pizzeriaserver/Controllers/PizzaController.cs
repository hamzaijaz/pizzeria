using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pizzeriaserver.Models;
using pizzeriaserver.Queries;

namespace pizzeriaserver.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly IMediator mediator;

        public PizzaController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("all")]
        public async Task<List<Pizza>> GetAllAsync()
        {
            var pizzas = await mediator.Send(new GetAllPizzasQuery());
            return pizzas;
        }

        [HttpGet]
        [Route("one")]
        public IActionResult GetById(int id)
        {
            return Ok(new Pizza() { Id = id });
        }
    }
}
