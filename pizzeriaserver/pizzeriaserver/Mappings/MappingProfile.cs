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
                .ForMember(x => x.Price, s => s.MapFrom(source => source.Price))
                .ForMember(x => x.Id, s => s.MapFrom(source => source.Id))
                .ForMember(x => x.Location, s => s.MapFrom(source => source.Location))
                .ReverseMap();

            CreateMap<ToppingDto, Topping>()
                .ForMember(x => x.Name, s => s.MapFrom(source => source.Name))
                .ForMember(x => x.Id, s => s.MapFrom(source => source.Id))
                .ReverseMap();
        }
    }
}
