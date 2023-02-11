using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;
using SantaInesWEB.Models;
using SantaInesWEB.Servicios.ServicioDireccion;
using SantaInesWEB.Servicios.ServicioUsuario;

namespace SantaInesWEB.Controllers
{
    public class ConfiguracionController : Controller
    {
        private readonly IServicioDireccion _servicioApiDireccion;
        private readonly IServicioUsuario _servicioApiUsuario;

        public ConfiguracionController(IServicioDireccion servicioApiDireccion, IServicioUsuario servicioApiUsuario)
        {
            _servicioApiDireccion = servicioApiDireccion;
            _servicioApiUsuario = servicioApiUsuario;
        }

        public async Task<IActionResult> Configuracion(string username)
        {
            try
            {
                
                UsuarioModel usuario = new UsuarioModel();
                DireccionModel direccion = new DireccionModel();
                
                usuario = await _servicioApiUsuario.MostrarInfoUsuario(username);
                direccion = await _servicioApiDireccion.MostrarInfoDireccion(usuario.id_direccion);
                var tupla = new Tuple<UsuarioModel, DireccionModel>(usuario, direccion);


                return View(tupla);


            }
            catch (Exception ex)
            {
                throw ex.InnerException!;
            }
        }

        public async Task<IActionResult> ModificarUsuario([Bind(Prefix = "Item1")] UsuarioModel usuario, [Bind(Prefix = "Item2")] DireccionModel direccion)
        {
            try
            {
                JObject respuestaUsuario = await _servicioApiUsuario.EditarUsuario(usuario);
                JObject respuestaDireccion = await _servicioApiDireccion.EditarDireccion(direccion);

                if ((bool)respuestaUsuario["success"] && (bool)respuestaDireccion["success"])
                    return RedirectToAction("Configuracion", new { message = "Se ha modificado correctamente", username = usuario.username });
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return NoContent();
        }

    }
}
