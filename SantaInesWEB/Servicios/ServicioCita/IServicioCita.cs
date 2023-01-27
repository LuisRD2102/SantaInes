using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SantaInesWEB.Models;

namespace SantaInesWEB.Servicios.ServicioUsuario
{
	public interface IServicioCita
	{
        Task<List<CitaModel>> MostrarCitas();
    }
}
