using Microsoft.AspNetCore.Mvc;
using Project.DayPilot_Handler;
using SantaInesAPI.BussinessLogic.DTO;
using SantaInesAPI.BussinessLogic.Mapper;
using SantaInesAPI.Persistence.DAO.Interface;
using SantaInesAPI.Persistence.Entity;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.BussinesLogic.Response;
using System.Net;

namespace SantaInesAPI.Controllers
{
    [Route("HistoriaMedica")]
    [ApiController]
    public class HistoriaMedicaController : ControllerBase
    {

        private readonly IHistoriaMedicaDAO _dao;

        public HistoriaMedicaController(IHistoriaMedicaDAO dao)
        {
            this._dao = dao;
        }

        [HttpGet]
        [Route("ConsultarHM/{id}")]
        public ApplicationResponse<HistoriaMedicaDTO> ConsultarHM([FromRoute] Guid id)
        {
            var response = new ApplicationResponse<HistoriaMedicaDTO>();
            try
            {
                response.Data = _dao.GetHistoriaMedica(id);
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
        [Route("ActualizarHistoriaMedica/")]
        public ApplicationResponse<HistoriaMedicaDTO> ActualizarHistoriaMedica([FromBody] HistoriaMedicaDTO historiaMedica)
        {
            var response = new ApplicationResponse<HistoriaMedicaDTO>();
            try
            {
                response.Data = _dao.ActualizarHistoriaMedicaDAO(HistoriaMedicaMapper.DtoToEntity(historiaMedica));

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
