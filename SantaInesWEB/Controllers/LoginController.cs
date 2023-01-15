using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SantaInesWEB.Models;
using SantaInesWEB.Servicios.ServicioDireccion;
using SantaInesWEB.Servicios.ServicioEmpleado;
using SantaInesWEB.Servicios.ServicioUsuario;
using System.Globalization;

namespace SantaInesWEB.Controllers
{
    public class LoginController : Controller
    {
        private readonly IServicioEmpleado _servicioApiEmpleado;
        private readonly IServicioUsuario _servicioApiUsuario;

        public LoginController(IServicioEmpleado servicioEmpleado, IServicioUsuario servicioUsuario)
        {
            _servicioApiEmpleado = servicioEmpleado;
            _servicioApiUsuario = servicioUsuario;

        }

        public IActionResult Login()
        {          
         
           return View();
            
           
        }

        public async Task<IActionResult> LoginUsuario(LoginModel loginData)
        {

            try
            {
                JObject respuestaEmpleado = await _servicioApiEmpleado.ValidarEmpleadoLogin(loginData.username, loginData.password);
                JObject respuestaUsuario = await _servicioApiUsuario.ValidarUsuarioLogin(loginData.username, loginData.password);

                if ((respuestaEmpleado is not null && (bool)respuestaEmpleado["success"]) || (respuestaUsuario is not null && (bool)respuestaUsuario["success"]))
                {
                    if (respuestaEmpleado is not null && (bool)respuestaEmpleado["success"])
                        asignarDatosSesion(respuestaEmpleado,false);
                    else if (respuestaUsuario is not null && (bool)respuestaUsuario["success"])
						asignarDatosSesion(respuestaUsuario,true);
					return RedirectToAction("Index", "Home");
                }
                
            }
            catch (Exception ex)
            {
                throw ex.InnerException!;
            }
            return NoContent();
        }

        private void asignarDatosSesion (JObject respuesta, bool isPaciente)
        {
			TextInfo textInfo = new CultureInfo("es", false).TextInfo;


			HttpContext.Session.SetString("username", (string)respuesta.SelectToken("data.username"));
			HttpContext.Session.SetString("nombre_completo", textInfo.ToTitleCase((string)respuesta.SelectToken("data.nombre_completo")));
			HttpContext.Session.SetString("apellido_completo", textInfo.ToTitleCase((string)respuesta.SelectToken("data.apellido_completo")));
            if (isPaciente)
				HttpContext.Session.SetString("rol", "Paciente");
			else
			    HttpContext.Session.SetString("rol", textInfo.ToTitleCase((string)respuesta.SelectToken("data.rol")));
		}

    }
}
