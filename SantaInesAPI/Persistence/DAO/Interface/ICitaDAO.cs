using Microsoft.AspNetCore.Mvc;
using Project.DayPilot_Handler;
using SantaInesAPI.Persistence.Entity;
using System.Net;

namespace SantaInesAPI.Persistence.DAO.Interface
{
    public interface ICitaDAO
    {
        public Task<IEnumerable<Cita>> ConsultarCitas(DateTime start, DateTime end, string? doctor);
        public Task<IEnumerable<Cita>> ConsultarCitasLibres(DateTime start, DateTime end, string patient);
        public Task<ActionResult<HttpStatusCode>> AgregarCita(AppointmentSlotRange range);
        public Task<ActionResult<HttpStatusCode>> ActualizarCita(Guid id, AppointmentSlotRequest slotRequest);
        public Task<ActionResult<HttpStatusCode>> ActualizarSlotCita(Guid id, AppointmentSlotUpdate update);
        public Cita EliminarCita(Guid id);
    }
}
