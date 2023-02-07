namespace pizzeriaserver.Data.Common
{
    public interface IEntity
    {
        DateTime CreatedOnUtc { get; set; }

        DateTime? ModifiedOnUtc { get; set; }
    }
}
