using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SantaInesWEB.Models;

namespace SantaInesWEB.Servicios.ServicioDireccion
{
    public interface IServicioDireccion
    {
        Task<JObject> RegistrarDireccion(DireccionModel direccion);
        Task<DireccionModel> MostrarInfoDireccion(Guid id);
        Task<JObject> EditarDireccion(DireccionModel direccion);
    }
}
