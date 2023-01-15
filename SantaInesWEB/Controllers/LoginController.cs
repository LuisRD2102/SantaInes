using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SantaInesWEB.Models;
using SantaInesWEB.Servicios.ServicioDireccion;
using SantaInesWEB.Servicios.ServicioEmpleado;
using SantaInesWEB.Servicios.ServicioUsuario;

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
                    return RedirectToAction("Index", "Home");
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
