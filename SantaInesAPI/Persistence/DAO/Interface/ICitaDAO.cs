using Microsoft.AspNetCore.Mvc;
using SantaInesAPI.BussinessLogic.DTO;
using SantaInesAPI.Persistence.Entity;
using System.Net;
using static SantaInesAPI.Controllers.CitaController;

namespace SantaInesAPI.Persistence.DAO.Interface
{
    public interface ICitaDAO
    {
        public Task<IEnumerable<Cita>> ConsultarCitasDAO(DateTime start, DateTime end, string? doctor);
        public Task<ActionResult<HttpStatusCode>> AgregarCitaDAO(AppointmentSlotRange range);
        //public CitaDTO ActualizarCitaDAO(Cita cita);
        public Cita EliminarCitaDAO(Guid id);
    }
}
