using MediatR;
using Microsoft.AspNetCore.Mvc;
using pizzeriaserver.Application.Commands;
using pizzeriaserver.Application.Models;
using pizzeriaserver.Application.Queries;

namespace pizzeriaserver.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToppingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ToppingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("all")]
        public async Task<List<ToppingDto>> GetAllAsync()
        {
            var toppings = await _mediator.Send(new GetAllToppingsQuery());
            return toppings;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ToppingDto> GetById(int id)
        {
            var resp = await _mediator.Send(new GetToppingByIdQuery() { Id = id });
            return resp;
        }

        [HttpPost]
        public async Task<ToppingDto> AddNewTopping(ToppingDto topping)
        {
            var resp = await _mediator.Send(new CreateToppingCommand()
            {
                Name = topping.Name
            });

            return resp;
        }

        [HttpPut]
        public async Task<ToppingDto> UpdateTopping(ToppingDto topping)
        {
            var resp = await _mediator.Send(new UpdateToppingCommand()
            {
                Id = topping.Id,
                Name = topping.Name
            });

            return resp;
        }

        [HttpDelete]
        public async Task<int> DeleteTopping(int toppingId)
        {
            var resp = await _mediator.Send(new DeleteToppingCommand()
            {
                Id = toppingId
            });

            return resp;
        }
    }
}
