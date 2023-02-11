using Microsoft.EntityFrameworkCore.Metadata.Internal;
using pizzeriaserver.Data.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace pizzeriaserver.Data.Entities
{
    public class Pizza : Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }
        public virtual List<Topping> Toppings { get; set; }
        public virtual List<PizzaLocation> PizzaLocations { get; set; }
    }
}
