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
    }
}
