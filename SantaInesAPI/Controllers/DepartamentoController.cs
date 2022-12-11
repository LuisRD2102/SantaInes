using Microsoft.AspNetCore.Mvc;
using SantaInesAPI.BussinessLogic.DTO;
using SantaInesAPI.BussinessLogic.Mapper;
using SantaInesAPI.Persistence.DAO.Interface;

namespace SantaInesAPI.Controllers
{
    [Route("Departamento")]
    [ApiController]
    public class DepartamentoController : Controller
    {
        private readonly IDepartamentoDAO _daoDepartamento;
        

        public DepartamentoController(IDepartamentoDAO dao)
        {
            _daoDepartamento = dao;
        }

        [HttpGet]
        [Route("ConsultaDepartamentos/")]
        public ActionResult<List<DepartamentoDTO>> ConsultarDepartamento()
        {
            try
            {
                return _daoDepartamento.ConsultarDepartamentoDAO();
            }
            catch (Exception ex)
            {

                throw ex.InnerException!;
            }
        }

        [HttpPost]
        [Route("CrearDepartamento/")]
        public ActionResult<DepartamentoDTO> AgregarDepartamento([FromBody] DepartamentoDTO dto1)
        {
            try
            {
                var dao0 = _daoDepartamento.AgregarDepartamentoDAO(DepartamentoMapper.DtoToEntity(dto1));
                return dao0;

            }
            catch (Exception ex)
            {

                throw ex.InnerException!;
            }
        }

        [HttpPut]
        [Route("ActualizarDepartamento/")]
        public ActionResult<DepartamentoDTO> ActualizarDepartamento([FromBody] DepartamentoDTO departamento)
        {
            try
            {
                return _daoDepartamento.ActualizarDepartamentoDAO(DepartamentoMapper.DtoToEntity_Update(departamento));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " : " + ex.StackTrace);
                throw ex.InnerException!;
            }
        }

        [HttpDelete]
        [Route("EliminarDepartamento/{id}")]
        public ActionResult<DepartamentoDTO> EliminarDepartamento([FromRoute] Guid id)
        {
            try
            {
                return _daoDepartamento.EliminarDepartamentoDAO(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " : " + ex.StackTrace);
                throw ex.InnerException!;
            }
        }
    }
}
