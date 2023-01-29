using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SantaInesWEB.Models;

namespace SantaInesWEB.Servicios.ServicioDepartamento
{
    public interface IServicioDepartamento
    {
        Task<List<DepartamentoModel>> MostrarTabla();
        Task<JObject> RegistrarDepartamento(DepartamentoModel dept);
        Task<JObject> EditarDepartamento(DepartamentoModel dept);
        Task<DepartamentoModel> MostrarInfoDepartamento(Guid id);
    }
}
