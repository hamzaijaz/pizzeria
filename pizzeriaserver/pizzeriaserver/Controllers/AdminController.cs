using MediatR;
using Microsoft.AspNetCore.Mvc;
using pizzeriaserver.Application.Commands;
using pizzeriaserver.Application.Models;
using pizzeriaserver.Application.Queries;

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
        [Route("location")]
        public async Task<int> DeleteLocation(int locationId)
        {
            var resp = await _mediator.Send(new DeleteLocationCommand()
            {
                Id = locationId
            });

            return resp;
        }
    }
}
