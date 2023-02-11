namespace pizzeriaserver.Data.Entities
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public virtual List<PizzaLocation> PizzaLocations { get; set; }
    }
}
