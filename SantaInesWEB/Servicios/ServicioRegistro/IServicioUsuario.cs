using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SantaInesWEB.Models;

namespace SantaInesWEB.Servicios.ServicioRegistro
{
	public interface IServicioUsuario
	{
		Task<JObject> RegistrarUsuario(UsuarioModel user);
	}
}
