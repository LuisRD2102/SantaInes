using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SantaInesWEB.Models;

namespace SantaInesWEB.Servicios.ServicioUsuario
{
	public interface IServicioUsuario
	{
		Task<JObject> RegistrarUsuario(UsuarioModel user);
        Task<JObject> ValidarUsuarioLogin(string username, string password);
        Task<List<UsuarioModel>> MostrarTabla();
    }
}
