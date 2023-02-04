using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Service;
using SantaInesAPI.BussinessLogic.DTO;
using SantaInesAPI.BussinessLogic.Mapper;
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

        public class AppointmentSlotRange
        {
            public DateTime Start { get; set; }
            public DateTime End { get; set; }
            public string Resource { get; set; }
            public string Scale { get; set; }
        }

        // GET: api/Citas
        [HttpGet]
        public async Task<IEnumerable<Cita>> GetAppointments([FromQuery] DateTime start, [FromQuery] DateTime end, [FromQuery] string? doctor)
        {
            return await _dao.ConsultarCitasDAO(start, end, doctor);
        }

        //[HttpPost]
        //public async Task<ActionResult<Cita>> PostAppointmentSlot(Cita appointmentSlot)
        //{
        //    _dao.

        //    return CreatedAtAction("GetAppointmentSlot", new { id = appointmentSlot.Id }, appointmentSlot);
        //}

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<HttpStatusCode>> PostAppointmentSlots(AppointmentSlotRange range)
        {
            try
            {
                return await _dao.AgregarCitaDAO(range);
            }
            catch (ExceptionsControl ex)
            {
                throw ex.InnerException!;
            }

        }

        //      [HttpPut]
        //      [Route("ActualizarCita/")]
        //      public ApplicationResponse<CitaDTO> ActualizarCita([FromBody] CitaDTO empleado)
        //      {
        //	var response = new ApplicationResponse<CitaDTO>();
        //	try
        //          {
        //		response.Data = _dao.ActualizarCitaDAO(CitaMapper.DtoToEntity(empleado));
        //          }
        //	catch (ExceptionsControl ex)
        //	{
        //		response.Success = false;
        //		response.Message = ex.Mensaje;
        //		response.Exception = ex.Excepcion.ToString();
        //	}
        //	return response;
        //}

        [HttpDelete]
        [Route("EliminarCita/{id}")]
        public ApplicationResponse<Cita> EliminarCita([FromRoute] Guid id)
        {
			var response = new ApplicationResponse<Cita>();
			try
            {
				response.Data = _dao.EliminarCitaDAO(id);
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
