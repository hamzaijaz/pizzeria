using MediatR;
using Microsoft.AspNetCore.Mvc;
using pizzeriaserver.Application.Commands;
using pizzeriaserver.Application.Models;
using pizzeriaserver.Application.Queries;

namespace pizzeriaserver.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PizzaController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet]
        [Route("all")]
        public async Task<List<PizzaDto>> GetAllAsync()
        {
            var pizzas = await _mediator.Send(new GetAllPizzasQuery());
            return pizzas;
        }

        [HttpGet]
        [Route("pizzasforlocation/{locationId}")]
        public async Task<List<PizzaDto>> GetPizzasForLocationAsync(int locationId)
        {
            var pizzas = await _mediator.Send(new GetPizzasForLocationQuery() { LocationId = locationId });
            return pizzas;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<PizzaDto> GetPizzaById(int id)
        {
            var resp = await _mediator.Send(new GetPizzaByIdQuery() { Id = id });
            return resp;
        }

        [HttpDelete]
        public async Task<int> DeletePizza(int pizzaId, int pizzaLocationId)
        {
            var resp = await _mediator.Send(new DeletePizzaCommand()
            {
                Id = pizzaId,
                PizzaLocationId = pizzaLocationId
            });

            return resp;
        }
    }
}
