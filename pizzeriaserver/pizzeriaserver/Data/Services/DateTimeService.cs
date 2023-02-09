using pizzeriaserver.Application.Common.Interfaces;

namespace pizzeriaserver.Data.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;

        public DateTime UtcNow => DateTime.UtcNow;
    }
}
