namespace pizzeriaserver.Controllers.Requests
{
    public class UpdatePizzaRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int LocationId { get; set; }
    }
}
