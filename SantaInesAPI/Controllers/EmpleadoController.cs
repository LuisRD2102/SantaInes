using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SantaInesAPI.BussinessLogic.DTO;
using SantaInesAPI.BussinessLogic.Mapper;
using SantaInesAPI.Persistence.DAO.Interface;
using SantaInesAPI.Persistence.Entity;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.BussinesLogic.Response;
using System.Net;
using System.Numerics;

namespace SantaInesAPI.Controllers
{
    [Route("Empleado")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {

        private readonly IEmpleadoDAO _dao;
        private readonly ILogger<EmpleadoController> _log;

        public EmpleadoController(IEmpleadoDAO dao, ILogger<EmpleadoController> log)
        {
            this._dao = dao;
            this._log = log;
        }

        [HttpGet]
        [Route("ConsultaEmpleados/")]
        public ApplicationResponse<List<EmpleadoDTO>> ConsultarEmpleadoDAO()
        {
			var response = new ApplicationResponse<List<EmpleadoDTO>>();
			try
            {
				response.Data = _dao.ConsultarEmpleadoDAO();
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
        [Route("CrearEmpleado/")]
        public ApplicationResponse<EmpleadoDTO> AgregarEmpleado([FromBody] EmpleadoDTO dto1)
        {
			var response = new ApplicationResponse<EmpleadoDTO>();
			try
            {
				response.Data = _dao.AgregarEmpleadoDAO(EmpleadoMapper.DtoToEntity(dto1));
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
        [Route("ActualizarEmpleado/")]
        public ApplicationResponse<EmpleadoDTO> ActualizarEmpleado([FromBody] EmpleadoDTO empleado)
        {
			var response = new ApplicationResponse<EmpleadoDTO>();
			try
            {
				response.Data = _dao.ActualizarEmpleadoDAO(EmpleadoMapper.DtoToEntity(empleado));
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
        [Route("EliminarEmpleado/{username}")]
        public ApplicationResponse<EmpleadoDTO> EliminarEmpleado([FromRoute] String username)
        {
			var response = new ApplicationResponse<EmpleadoDTO>();
			try
            {
				response.Data = _dao.EliminarEmpleadoDAO(username);
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
        [Route("ConsultarEmpleadoPorUsername/{username}")]
        public ApplicationResponse<EmpleadoDTO> ConsultarPorID([FromRoute] string username)
        {
            var response = new ApplicationResponse<EmpleadoDTO>();
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


        [HttpGet]
        [Route("Doctores/")]
        public async Task<IEnumerable<Empleado>> GetDoctors()
		{

			var doctores= await _dao.GetDoctors();

			foreach(var doctor in doctores)
			{
				doctor.nombre_completo = (doctor.sexo.ToUpper()=="M" ? "Dr. " : "Dra. ") + doctor.nombre_completo.Split(' ').First() + ' ' + doctor.apellido_completo.Split(' ').First();

            }

			return doctores;

        }



    }
}
