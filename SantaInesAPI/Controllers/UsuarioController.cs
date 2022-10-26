using Microsoft.AspNetCore.Mvc;
using SantaInesAPI.BussinessLogic.DTO;
using SantaInesAPI.BussinessLogic.Mapper;
using SantaInesAPI.Persistence.DAO.Interface;

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
        [Route("ConsultaUsuarios/")]
        public ActionResult<List<UsuarioDTO>> ConsultarUsuarioDAO()
        {
            try
            {
                return _dao.ConsultarUsuarioDAO();
            }
            catch (Exception ex)
            {

                throw ex.InnerException!;
            }
        }

        [HttpPost]
        [Route("CrearUsuario/")]
        public ActionResult<UsuarioDTO> AgregarTipoCargo([FromBody] UsuarioDTO dto1)
        {
            try
            {
                var dao0 = _dao.AgregarUsuarioDAO(UsuarioMapper.DtoToEntity(dto1));
                return dao0;

            }
            catch (Exception ex)
            {

                throw ex.InnerException!;
            }
        }

        [HttpPut]
        [Route("ActualizarUsuario/")]
        public ActionResult<UsuarioDTO> ActualizarUsuario([FromBody] UsuarioDTO usuario)
        {
            try
            {
                return _dao.ActualizarUsuarioDAO(UsuarioMapper.DtoToEntity(usuario));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " : " + ex.StackTrace);
                throw ex.InnerException!;
            }
        }

        [HttpDelete]
        [Route("EliminarUsuario/{username}/{idDireccion}")]
        public ActionResult<UsuarioDTO> EliminarTipoCargo([FromRoute] String username, [FromRoute] Guid idDireccion)
        {
            try
            {
                return _dao.EliminarUsuarioDAO(username,idDireccion);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " : " + ex.StackTrace);
                throw ex.InnerException!;
            }
        }

    }
}
