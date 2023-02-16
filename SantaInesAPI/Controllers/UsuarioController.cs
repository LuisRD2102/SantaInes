using Microsoft.AspNetCore.Mvc;
using SantaInesAPI.BussinessLogic.DTO;
using SantaInesAPI.BussinessLogic.Mapper;
using SantaInesAPI.Persistence.DAO.Implementations;
using SantaInesAPI.Persistence.DAO.Interface;
using SantaInesAPI.Persistence.Entity;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.BussinesLogic.Response;

namespace SantaInesAPI.Controllers
{
    [Route("Usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly IUsuarioDAO _dao;
        private readonly IDireccionDAO _daoDireccion;
        private readonly ILogger<UsuarioController> _log;

        public UsuarioController(IUsuarioDAO dao, ILogger<UsuarioController> log, IDireccionDAO daoDireccion)
        {
            this._dao = dao;
            this._log = log;
            this._daoDireccion = daoDireccion;
        }

        [HttpGet]
        [Route("ConsultaUsuarios/{rol}/{username}")]
        public ApplicationResponse<List<UsuarioDTO>> ConsultarUsuarioDAO([FromRoute] string? rol, [FromRoute] string? username)
        {
            var response = new ApplicationResponse<List<UsuarioDTO>>();

            try
            {
                response.Data = _dao.ConsultarUsuarioDAO(rol,username);
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
        [Route("CrearUsuario/")]
        public ApplicationResponse<UsuarioDTO> AgregarUsuario([FromBody] UsuarioDTO dto1)
        {
            var response = new ApplicationResponse<UsuarioDTO>();
            try
            {
                response.Data = _dao.AgregarUsuarioDAO(UsuarioMapper.DtoToEntity(dto1));
                
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
        [Route("ActualizarUsuario/")]
        public ApplicationResponse<UsuarioDTO> ActualizarUsuario([FromBody] UsuarioDTO usuario)
        {
			var response = new ApplicationResponse<UsuarioDTO>();
			try
            {
				response.Data = _dao.ActualizarUsuarioDAO(UsuarioMapper.DtoToEntity(usuario));

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
        [Route("EliminarUsuario/{username}")]
        public ApplicationResponse<UsuarioDTO> EliminarUsuario([FromRoute] String username)
        {
			var response = new ApplicationResponse<UsuarioDTO>();
			try
            {
				response.Data = _dao.EliminarUsuarioDAO(username);
            }
			catch (ExceptionsControl ex)
			{
				response.Success = false;
				response.Message = ex.Mensaje;
				response.Exception = ex.Excepcion.ToString();
			}
			return response;
		}

        [HttpGet]
        [Route("ConsultarUsuarioPorUsername/{username}")]
        public ApplicationResponse<UsuarioDTO> ConsultarPorID([FromRoute] string username)
        {
            var response = new ApplicationResponse<UsuarioDTO>();
            try
            {
                response.Data = _dao.ConsultarPorUsername(username);
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
