using Ardalis.GuardClauses;
using AutoMapper;
using MediatR;
using pizzeriaserver.Application.Common.Interfaces;
using pizzeriaserver.Application.Models;
using pizzeriaserver.Repositories;
using System;

namespace pizzeriaserver.Application.Commands
{
    public class UpdatePizzaCommand : IRequest<PizzaDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int LocationId { get; set; }

        public class UpdatePizzaCommandHandler : IRequestHandler<UpdatePizzaCommand, PizzaDto>
        {
            private readonly IPizzaRepository _pizzaRepository;

            public UpdatePizzaCommandHandler(IPizzaRepository pizzaRepository)
            {
                Guard.Against.Null(pizzaRepository, nameof(pizzaRepository));

                _pizzaRepository = pizzaRepository;
            }

            public async Task<PizzaDto> Handle(UpdatePizzaCommand command, CancellationToken cancellationToken)
            {
                var pizza = new UpdatePizzaDto()
                {
                    Id = command.Id,
                    Name = command.Name,
                    Description = command.Description,
                    Price = command.Price,
                    LocationId = command.LocationId,
                };

                return await _pizzaRepository.UpdatePizzaAsync(pizza);
            }
        }
    }
}
