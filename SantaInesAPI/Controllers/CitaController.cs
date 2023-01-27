using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        [Route("ConsultaCitas/")]
        public ApplicationResponse<List<CitaDTO>> ConsultarCitaDAO()
        {
			var response = new ApplicationResponse<List<CitaDTO>>();
			try
            {
				response.Data = _dao.ConsultarCitasDAO();
            }
			catch (ExceptionsControl ex)
			{
				response.Success = false;
				response.Message = ex.Mensaje;
				response.Exception = ex.Excepcion.ToString();
			}
			return response;
		}

        [HttpPost]
        [Route("CrearCita/")]
        public ApplicationResponse<CitaDTO> AgregarCita([FromBody] CitaDTO dto1)
        {
			var response = new ApplicationResponse<CitaDTO>();
			try
            {
				response.Data = _dao.AgregarCitaDAO(CitaMapper.DtoToEntity(dto1));
            }
			catch (ExceptionsControl ex)
			{
				response.Success = false;
				response.Message = ex.Mensaje;
				response.Exception = ex.Excepcion.ToString();
			}
			return response;
		}

        [HttpPut]
        [Route("ActualizarCita/")]
        public ApplicationResponse<CitaDTO> ActualizarCita([FromBody] CitaDTO empleado)
        {
			var response = new ApplicationResponse<CitaDTO>();
			try
            {
				response.Data = _dao.ActualizarCitaDAO(CitaMapper.DtoToEntity(empleado));
            }
			catch (ExceptionsControl ex)
			{
				response.Success = false;
				response.Message = ex.Mensaje;
				response.Exception = ex.Excepcion.ToString();
			}
			return response;
		}

        [HttpDelete]
        [Route("EliminarCita/{id}")]
        public ApplicationResponse<CitaDTO> EliminarCita([FromRoute] Guid id)
        {
			var response = new ApplicationResponse<CitaDTO>();
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
