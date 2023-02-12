using Newtonsoft.Json.Linq;
using SantaInesWEB.Models;

namespace SantaInesWEB.Servicios.ServicioGrafica
{
    public interface IServicioGrafica
    {
        Task<GraphModel> GraficaGenero(int? mes);
    }
}
