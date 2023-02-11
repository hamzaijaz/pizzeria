using Microsoft.EntityFrameworkCore.Metadata.Internal;
using pizzeriaserver.Data.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace pizzeriaserver.Data.Entities
{
    public class PizzaLocation : Entity
    {
        public int PizzaId { get; set; }
        public Pizza Pizza { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }
    }
}
