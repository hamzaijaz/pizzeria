using Microsoft.EntityFrameworkCore.Metadata.Internal;
using pizzeriaserver.Data.Common;

namespace pizzeriaserver.Data.Entities
{
    public class Pizza : Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<Topping> Toppings { get; set; }
        public virtual List<PizzaLocation> PizzaLocations { get; set; }
    }
}
