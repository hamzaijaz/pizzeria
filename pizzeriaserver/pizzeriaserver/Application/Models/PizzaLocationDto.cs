using pizzeriaserver.Data.Entities;

namespace pizzeriaserver.Application.Models
{
    public class PizzaLocationDto
    {
        public int PizzaId { get; set; }
        public PizzaDto Pizza { get; set; }
        public int LocationId { get; set; }
        public LocationDto Location { get; set; }
        public decimal Price { get; set; }
    }
}
