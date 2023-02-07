using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pizzeriaserver.Application.Models;
using pizzeriaserver.Application.Commands;
using pizzeriaserver.Application.Queries;

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
        public async Task<List<PizzaDto>> GetAllAsync()
        {
            var pizzas = await mediator.Send(new GetAllPizzasQuery());
            return pizzas;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<PizzaDto> GetById(int id)
        {
            var resp = await mediator.Send(new GetPizzaByIdQuery() { Id = id });
            return resp;
        }

        [HttpPost]
        public async Task<PizzaDto> AddNewPizza(PizzaDto pizza) 
        {
            var resp = await mediator.Send(new CreatePizzaCommand() 
            { 
                Name = pizza.Name,
                Description = pizza.Description,
                Location = pizza.Location,
                Price = pizza.Price
            });

            return resp;
        }
    }
}
