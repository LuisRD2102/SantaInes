using Microsoft.AspNetCore.Mvc;
using Project.DayPilot_Handler;
using SantaInesAPI.Persistence.DAO.Interface;
using SantaInesAPI.Persistence.Entity;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.BussinesLogic.Response;
using System.Net;

namespace SantaInesAPI.Controllers
{
    [Route("Citas")]
    [ApiController]
    public class CitaController : ControllerBase
    {

        private readonly ICitaDAO _dao;
        private readonly ILogger<CitaController> _log;

        public CitaController(ICitaDAO dao, ILogger<CitaController> log)
        {
            this._dao = dao;
            this._log = log;
        }

        //Para la vista del doctores
        [HttpGet]
        [Route("/Citas/Doctor")]
        public async Task<IEnumerable<Cita>> ConsultarCitas([FromQuery] DateTime start, [FromQuery] DateTime end, [FromQuery] string? doctor)
        {
            try
            {
                return await _dao.ConsultarCitas(start, end, doctor);
            }
            catch (ExceptionsControl ex)
            {
                throw ex.InnerException!;
            }
        }

        //Para la vista del paciente
        [HttpGet]
        [Route("/Citas/Libres")]
        public async Task<IEnumerable<Cita>> ConsultarCitasLibres ([FromQuery] DateTime start, [FromQuery] DateTime end, [FromQuery] string patient, [FromQuery] string? doctor, [FromQuery] Guid? idDepartamento)
        {
            try
            {

                var citas = await _dao.ConsultarCitasLibres(start, end, patient,doctor, idDepartamento);
                return citas;
            }
            catch (ExceptionsControl ex)
            {
                throw ex.InnerException!;
            }
        }


        [HttpPut]
        [Route("/Citas/{id}/request")]
        public async Task<ActionResult<HttpStatusCode>> ActualizarCita(Guid id, AppointmentSlotRequest slotRequest)
        {
            try
            {
                return await _dao.ActualizarCita(id, slotRequest);
            }
            catch (ExceptionsControl ex)
            {
                throw ex.InnerException!;
            }
        }

        [HttpPut("/Citas/ActualizarCita/{id}")]
        public async Task<ActionResult<HttpStatusCode>> ActualizarSlotCita(Guid id, AppointmentSlotUpdate updateSlotInfo)
        {
            try
            {
                return await _dao.ActualizarSlotCita(id, updateSlotInfo);
            }
            catch (ExceptionsControl ex)
            {
                throw ex.InnerException!;
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<HttpStatusCode>> PostAppointmentSlots(AppointmentSlotRange range)
        {
            try
            {
                return await _dao.AgregarCita(range);
            }
            catch (ExceptionsControl ex)
            {
                throw ex.InnerException!;
            }

        }

        [HttpDelete]
        [Route("EliminarCita/{id}")]
        public ApplicationResponse<Cita> EliminarCita([FromRoute] Guid id)
        {
			var response = new ApplicationResponse<Cita>();
			try
            {
				response.Data = _dao.EliminarCita(id);
            }
			catch (ExceptionsControl ex)
			{
				response.Success = false;
				response.Message = ex.Mensaje;
				response.Exception = ex.Excepcion.ToString();
			}
			return response;
		}

    }
}
