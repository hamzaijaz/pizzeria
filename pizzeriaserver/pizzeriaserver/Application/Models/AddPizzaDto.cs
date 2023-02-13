namespace pizzeriaserver.Application.Models
{
    public class AddPizzaDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public List<int> LocationIds { get; set; }
    }
}
