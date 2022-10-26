using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SantaInesAPI.BussinessLogic.DTO;
using SantaInesAPI.BussinessLogic.Mapper;
using SantaInesAPI.Persistence.DAO.Interface;

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
        public ActionResult<List<DireccionDTO>> ConsultarDireccionDAO()
        {
            try
            {
                return _DireccionDAO.ConsultarDireccionDAO();
            }
            catch (Exception ex)
            {

                throw ex.InnerException!;
            }
        }

        [HttpPost]
        [Route("CrearDireccion/")]
        public ActionResult<DireccionDTO> AgregarDireccion([FromBody] DireccionDTO dto1)
        {
            try
            {
                var dao0 = _DireccionDAO.AgregarDireccionDAO(DireccionMapper.DtoToEntity(dto1));
                return dao0;

            }
            catch (Exception ex)
            {

                throw ex.InnerException!;
            }
        }
        [HttpPut]
        [Route("ActualizarDireccion/")]
        public ActionResult<DireccionDTO> ActualizarDireccion([FromBody] DireccionDTO direccion)
        {
            try
            {
                return _DireccionDAO.ActualizarDireccionDAO(DireccionMapper.DtoToEntity(direccion));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " : " + ex.StackTrace);
                throw ex.InnerException!;
            }
        }

        [HttpDelete]
        [Route("EliminarDireccion/{guidDireccion}")]
        public ActionResult<DireccionDTO> EliminarDireccion([FromRoute] Guid id)
        {
            try
            {
                return _DireccionDAO.EliminarDireccionDAO(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " : " + ex.StackTrace);
                throw ex.InnerException!;
            }
        }
    }

    
}
