using Microsoft.AspNetCore.Mvc;
using SantaInesAPI.BussinessLogic.DTO;
using SantaInesAPI.BussinessLogic.Mapper;
using SantaInesAPI.Persistence.DAO.Interface;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.BussinesLogic.Response;

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
        public ApplicationResponse<List<DepartamentoDTO>> ConsultarDepartamento()
        {
			var response = new ApplicationResponse<List<DepartamentoDTO>>();
			try
            {
			    response.Data = _daoDepartamento.ConsultarDepartamentoDAO();
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
        [Route("CrearDepartamento/")]
        public ApplicationResponse<DepartamentoDTO> AgregarDepartamento([FromBody] DepartamentoDTO dto1)
        {
			var response = new ApplicationResponse<DepartamentoDTO>();
			try
            {
				response.Data = _daoDepartamento.AgregarDepartamentoDAO(DepartamentoMapper.DtoToEntity(dto1));
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
        [Route("ActualizarDepartamento/")]
        public ApplicationResponse<DepartamentoDTO> ActualizarDepartamento([FromBody] DepartamentoDTO departamento)
        {
			var response = new ApplicationResponse<DepartamentoDTO>();
			try
            {
				response.Data = _daoDepartamento.ActualizarDepartamentoDAO(DepartamentoMapper.DtoToEntity_Update(departamento));

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
        [Route("EliminarDepartamento/{id}")]
        public ApplicationResponse<DepartamentoDTO> EliminarDepartamento([FromRoute] Guid id)
        {
			var response = new ApplicationResponse<DepartamentoDTO>();
			try
            {
				response.Data = _daoDepartamento.EliminarDepartamentoDAO(id);
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
