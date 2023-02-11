using pizzeriaserver.Data.Common;

namespace pizzeriaserver.Data.Entities
{
    public class PizzaLocation : Entity
    {
        public int PizzaId { get; set; }
        public Pizza Pizza { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
    }
}
