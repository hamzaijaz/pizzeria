namespace pizzeriaserver.Data.Common
{
    public class Entity : IEntity
    {
        public DateTime CreatedOnUtc { get; set; }

        public DateTime? ModifiedOnUtc { get; set; }
    }
}
