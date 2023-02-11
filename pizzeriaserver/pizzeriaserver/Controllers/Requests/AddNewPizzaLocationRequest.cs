namespace pizzeriaserver.Controllers.Requests
{
    public class AddNewPizzaLocationRequest
    {
        public int PizzaId { get; set; }
        public int LocationId { get; set; }
        public decimal Price { get; set; }
    }
}
