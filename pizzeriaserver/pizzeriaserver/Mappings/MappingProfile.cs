using AutoMapper;
using pizzeriaserver.Application.Models;
using pizzeriaserver.Data.Entities;

namespace pizzeriaserver.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<PizzaDto, Pizza>()
                .ForMember(x => x.Name, s => s.MapFrom(source => source.Name))
                .ForMember(x => x.Description, s => s.MapFrom(source => source.Description))
                .ForMember(x => x.Id, s => s.MapFrom(source => source.Id))
                .ReverseMap();

            CreateMap<ToppingDto, Topping>()
                .ForMember(x => x.Name, s => s.MapFrom(source => source.Name))
                .ForMember(x => x.Id, s => s.MapFrom(source => source.Id))
                .ReverseMap();

            CreateMap<LocationDto, Location>()
                .ForMember(x => x.Name, s => s.MapFrom(source => source.Name))
                .ForMember(x => x.Id, s => s.MapFrom(source => source.Id))
                .ForMember(x => x.Address, s => s.MapFrom(source => source.Address))
                .ReverseMap();

            CreateMap<PizzaLocationDto, PizzaLocation>()
                .ForMember(x => x.PizzaId, s => s.MapFrom(source => source.PizzaId))
                .ForMember(x => x.LocationId, s => s.MapFrom(source => source.LocationId))
                .ReverseMap();
        }
    }
}
