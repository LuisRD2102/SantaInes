using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SantaInesWEB.Models;
using SantaInesWEB.Servicios.ServicioDireccion;
using SantaInesWEB.Servicios.ServicioUsuario;
using System.Reflection.PortableExecutable;
using System.Text.Json;

namespace SantaInesWEB.Controllers
{
    public class RegistroController : Controller
    {
		private readonly IServicioDireccion _servicioApiDireccion;
		private readonly IServicioUsuario _servicioApiUsuario;

		public RegistroController(IServicioDireccion servicioDireccion, IServicioUsuario servicioUsuario)
		{
			_servicioApiDireccion= servicioDireccion;
			_servicioApiUsuario= servicioUsuario;
				
		}

		public IActionResult Registro()
        {
            return View();
        }

		public async Task<IActionResult> RegistroExitoso([Bind(Prefix = "Item1")] UsuarioModel user, [Bind(Prefix = "Item2")] DireccionModel dir)
		{
			
			try
			{
				dir.id = Guid.NewGuid();
				user.id_direccion = dir.id;
				user.idHistoria = Guid.NewGuid();
                JObject respuestaDireccion = await _servicioApiDireccion.RegistrarDireccion(dir);
				JObject respuestaUsuario = await _servicioApiUsuario.RegistrarUsuario(user);

				if ((bool)respuestaDireccion["success"] && (bool)respuestaUsuario["success"])
				{
					return RedirectToAction("Login","Login", new { message = "Usuario " +user.username + " registrado de manera exitosa" });
				}
								
			}
			catch (Exception ex)
			{
				throw ex.InnerException!;
			}
			return NoContent();
		}

	}
}
