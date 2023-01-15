using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SantaInesWEB.Models;

namespace SantaInesWEB.Servicios.ServicioDepartamento
{
    public interface IServicioDepartamento
    {
        Task<List<DepartamentoModel>> MostrarTabla();
    }
}
