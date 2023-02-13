using Newtonsoft.Json.Linq;
using SantaInesAPI.BussinessLogic.DTO;
using SantaInesWEB.Models;

namespace SantaInesWEB.Servicios.ServicioGrafica
{
    public interface IServicioGrafica
    {
        Task<GraphModel> GraficaGenero(int? mes);
        Task<GraphModel> GraficaDepartamentoPorCitas(int? mes);
        Task<GraphModel> GraficaTopDoctores(int? mes);
        Task<GraphModel> GraficaPacientesRangoEdad();
    }
}
