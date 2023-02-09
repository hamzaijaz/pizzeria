using pizzeriaserver.Data.Common;

namespace pizzeriaserver.Data.Entities
{
    public class Topping : Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
