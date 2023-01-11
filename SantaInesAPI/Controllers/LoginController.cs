using Microsoft.AspNetCore.Mvc;
using SantaInesAPI.BussinessLogic.DTO;
using SantaInesAPI.BussinessLogic.Mapper;
using SantaInesAPI.Persistence.DAO.Interface;
using SantaInesAPI.Persistence.Entity;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.BussinesLogic.Response;

namespace SantaInesAPI.Controllers
{
    [Route("Login")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly IUsuarioDAO _daoUsuario;
        private readonly IEmpleadoDAO _daoEmpleado;
        private readonly ILogger<UsuarioController> _log;

        public LoginController(IUsuarioDAO dao, ILogger<UsuarioController> log, IDireccionDAO daoDireccion, IEmpleadoDAO daoEmpleado)
        {
            this._daoUsuario = dao;
            this._log = log;
            _daoEmpleado = daoEmpleado;
        }

        [HttpGet]
        [Route("LoginUsuario/{username}/{pass}")]
        public ApplicationResponse<UsuarioDTO> Login([FromRoute] string username, [FromRoute] string pass)
        {
			var response = new ApplicationResponse<UsuarioDTO>();
			try
            {
				response.Data = _daoUsuario.VerificarDatosLogin(username, pass);
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
        [Route("LoginEmpleado/{username}/{pass}")]
        public ApplicationResponse<EmpleadoDTO> LoginEmpleado([FromRoute] string username, [FromRoute] string pass)
        {
            var response = new ApplicationResponse<EmpleadoDTO>();
            try
            {
                response.Data = _daoEmpleado.VerificarDatosLogin(username, pass);
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
