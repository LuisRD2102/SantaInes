using Microsoft.AspNetCore.Mvc;
using SantaInesAPI.BussinessLogic.DTO;
using SantaInesAPI.Persistence.DAO.Interface;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.BussinesLogic.Response;

namespace SantaInesAPI.Controllers
{
    [Route("Dashboard")]
    [ApiController]
    public class DashboardController : Controller
    {
        private readonly IDashboardDAO _dao;
        

        public DashboardController(IDashboardDAO dao)
        {
            _dao = dao;
        }

        [HttpGet]
        [Route("GetGraficaGenero/{mes}")]
        public ApplicationResponse<DashboardDTO> GraficaGenero([FromRoute] int mes)
        {
			var response = new ApplicationResponse<DashboardDTO>();
			try
            {
                response.Data = _dao.GraficaGenero(mes);
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
