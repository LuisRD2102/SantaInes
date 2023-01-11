using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SantaInesWEB.Models;

namespace SantaInesWEB.Servicios.ServicioEmpleado
{
	public interface IServicioEmpleado
	{
		//Task<JObject> RegistrarEmpleado(UsuarioModel user);
        Task<JObject> ValidarEmpleadoLogin(string username, string password);
    }
}
