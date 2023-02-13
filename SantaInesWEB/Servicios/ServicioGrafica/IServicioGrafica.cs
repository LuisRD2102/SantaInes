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
        Task<StatsModel> CantidadCitasPendientes(int? mes);
        Task<StatsModel> CantidadCitasConfirmadas(int? mes);
        Task<StatsModel> CantidadPacientes();
        Task<StatsModel> CantidadDoctores();
    }
}
