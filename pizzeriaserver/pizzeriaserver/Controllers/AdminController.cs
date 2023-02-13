using MediatR;
using Microsoft.AspNetCore.Mvc;
using pizzeriaserver.Application.Commands;
using pizzeriaserver.Application.Models;
using pizzeriaserver.Application.Queries;
using pizzeriaserver.Controllers.Requests;

namespace pizzeriaserver.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AdminController(IMediator mediator) 
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("location/all")]
        public async Task<List<LocationDto>> GetAllAsync()
        {
            var locations = await _mediator.Send(new GetAllLocationsQuery());
            return locations;
        }

        [HttpPost]
        [Route("location")]
        public async Task<LocationDto> AddNewLocation(LocationDto location)
        {
            var resp = await _mediator.Send(new CreateLocationCommand()
            {
                Name = location.Name,
                Address = location.Address
            });

            return resp;
        }

        [HttpPost]
        [Route("pizza")]
        public async Task<PizzaDto> AddNewPizza(AddNewPizzaRequest pizza)
        {
            var resp = await _mediator.Send(new CreatePizzaCommand()
            {
                Name = pizza.Name,
                Description = pizza.Description,
                Price = pizza.Price,
                LocationIds = pizza.LocationIds
            });

            return resp;
        }

        [HttpPut]
        [Route("pizza")]
        public async Task<PizzaDto> UpdatePizza(UpdatePizzaRequest pizza)
        {
            var resp = await _mediator.Send(new UpdatePizzaCommand()
            {
                Id = pizza.Id,
                Name = pizza.Name,
                Description = pizza.Description,
                Price = pizza.Price,
                LocationId = pizza.LocationId
            });

            return resp;
        }

        [HttpPost]
        [Route("pizzalocation")]
        public async Task<PizzaLocationDto> AddNewPizzaLocation(AddNewPizzaLocationRequest pizzaLocation)
        {
            var resp = await _mediator.Send(new AddPizzaToLocationCommand()
            {
                PizzaId = pizzaLocation.PizzaId,
                LocationId = pizzaLocation.LocationId,
                Price = pizzaLocation.Price
            });

            return resp;
        }

        [HttpPut]
        [Route("location")]
        public async Task<LocationDto> UpdateLocation(LocationDto location)
        {
            var resp = await _mediator.Send(new UpdateLocationCommand()
            {
                Id = location.Id,
                Name = location.Name,
                Address = location.Address
            });

            return resp;
        }

        [HttpDelete]
        [Route("location/{locationId}")]
        public async Task<int> DeleteLocation(int locationId)
        {
            var resp = await _mediator.Send(new DeleteLocationCommand()
            {
                Id = locationId
            });

            return resp;
        }

        [HttpDelete]
        [Route("pizza/{pizzaId}/location/{locationId}")]
        public async Task<int> DeletePizza(int pizzaId, int locationId)
        {
            var resp = await _mediator.Send(new DeletePizzaCommand()
            {
                Id = pizzaId,
                PizzaLocationId = locationId
            });

            return resp;
        }
    }
}
