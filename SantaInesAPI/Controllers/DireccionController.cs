using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SantaInesAPI.BussinessLogic.DTO;
using SantaInesAPI.BussinessLogic.Mapper;
using SantaInesAPI.Persistence.DAO.Interface;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.BussinesLogic.Response;

namespace SantaInesAPI.Controllers
{
    [Route("Direccion")]
    [ApiController]
    public class DireccionController : ControllerBase
    {
        private readonly IDireccionDAO _DireccionDAO;
        private readonly ILogger<DireccionController> _logDireccion;

        public DireccionController(IDireccionDAO direccionDAO, ILogger<DireccionController> logDireccion)
        {
            _DireccionDAO = direccionDAO;
            _logDireccion = logDireccion;
        }

        [HttpGet]
        [Route("ConsultarDireccion/")]
        public ApplicationResponse<List<DireccionDTO>> ConsultarDireccionDAO()
        {
			var response = new ApplicationResponse<List<DireccionDTO>>();
			try
            {
				response.Data = _DireccionDAO.ConsultarDireccionDAO();
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
        [Route("CrearDireccion/")]
        public ApplicationResponse<DireccionDTO> AgregarDireccion([FromBody] DireccionDTO dto1)
        {
			var response = new ApplicationResponse<DireccionDTO>();
			try
            {
                response.Data = _DireccionDAO.AgregarDireccionDAO(DireccionMapper.DtoToEntity(dto1));
                
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
        [Route("ActualizarDireccion/")]
        public ApplicationResponse<DireccionDTO> ActualizarDireccion([FromBody] DireccionDTO direccion)
        {
			var response = new ApplicationResponse<DireccionDTO>();
			try
            {
				response.Data = _DireccionDAO.ActualizarDireccionDAO(DireccionMapper.DtoToEntity(direccion));

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
        [Route("EliminarDireccion/{guidDireccion}")]
        public ApplicationResponse<DireccionDTO> EliminarDireccion([FromRoute] Guid id)
        {
			var response = new ApplicationResponse<DireccionDTO>();
			try
            {
				response.Data = _DireccionDAO.EliminarDireccionDAO(id);
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
