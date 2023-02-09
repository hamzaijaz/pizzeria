using Ardalis.GuardClauses;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using pizzeriaserver.Application.Models;
using pizzeriaserver.Repositories;
using System.ComponentModel.DataAnnotations.Schema;

namespace pizzeriaserver.Application.Commands
{
    public class CreatePizzaCommand : IRequest<PizzaDto>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Location { get; set; }

        public class CreatePizzaCommandHandler : IRequestHandler<CreatePizzaCommand, PizzaDto>
        {
            private readonly IPizzaRepository _pizzaRepository;

            public CreatePizzaCommandHandler(IPizzaRepository pizzaRepository)
            {
                Guard.Against.Null(pizzaRepository, nameof(pizzaRepository));
                _pizzaRepository = pizzaRepository;
            }

            public async Task<PizzaDto> Handle(CreatePizzaCommand command, CancellationToken cancellation)
            {
                var pizza = new PizzaDto()
                {
                    Name = command.Name,
                    Description = command.Description,
                    Price = command.Price,
                    Location = command.Location
                };

                return await _pizzaRepository.AddPizzaAsync(pizza);
            }
        }
    }
}
