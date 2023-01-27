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
    [Route("Itinerario")]
    [ApiController]
    public class ItinerarioController : ControllerBase
    {

        private readonly IItinerarioDAO _dao;
        private readonly ILogger<ItinerarioController> _log;

        public ItinerarioController(IItinerarioDAO dao, ILogger<ItinerarioController> log)
        {
            this._dao = dao;
            this._log = log;
        }

        [HttpGet]
        [Route("ConsultaItinerarios/")]
        public ApplicationResponse<List<ItinerarioDTO>> ConsultarItinerarioDAO()
        {
			var response = new ApplicationResponse<List<ItinerarioDTO>>();
			try
            {
				response.Data = _dao.ConsultarItinerariosDAO();
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
        [Route("CrearItinerario/")]
        public ApplicationResponse<ItinerarioDTO> AgregarItinerario([FromBody] ItinerarioDTO dto1)
        {
			var response = new ApplicationResponse<ItinerarioDTO>();
			try
            {
				response.Data = _dao.AgregarItinerarioDAO(ItinerarioMapper.DtoToEntity(dto1));
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
        [Route("ActualizarItinerario/")]
        public ApplicationResponse<ItinerarioDTO> ActualizarItinerario([FromBody] ItinerarioDTO empleado)
        {
			var response = new ApplicationResponse<ItinerarioDTO>();
			try
            {
				response.Data = _dao.ActualizarItinerarioDAO(ItinerarioMapper.DtoToEntity(empleado));
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
        [Route("EliminarItinerario/{id}")]
        public ApplicationResponse<ItinerarioDTO> EliminarItinerario([FromRoute] Guid id)
        {
			var response = new ApplicationResponse<ItinerarioDTO>();
			try
            {
				response.Data = _dao.EliminarItinerarioDAO(id);
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
