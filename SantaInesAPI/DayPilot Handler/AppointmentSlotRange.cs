using SantaInesAPI.Persistence.Entity;

namespace Project.DayPilot_Handler
{
    public class AppointmentSlotRange
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Resource { get; set; }
        public string Scale { get; set; }
    }
}
