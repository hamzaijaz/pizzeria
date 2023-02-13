﻿namespace pizzeriaserver.Controllers.Requests
{
    public class AddNewPizzaRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public List<int> LocationIds { get; set; }
    }
}
