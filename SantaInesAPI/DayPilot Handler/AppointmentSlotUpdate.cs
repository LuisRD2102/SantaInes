using SantaInesAPI.Persistence.Entity;

namespace Project.DayPilot_Handler
{
    public class AppointmentSlotUpdate
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string? Name { get; set; }
        public string? Status { get; set; }
    }
}
