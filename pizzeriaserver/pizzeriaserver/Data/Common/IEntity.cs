namespace pizzeriaserver.Data.Common
{
    public interface IEntity
    {
        DateTime? ModifiedOnUtc { get; set; }
    }
}
