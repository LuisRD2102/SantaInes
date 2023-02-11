using Microsoft.AspNetCore.Mvc;
using SantaInesWEB.Models;
using SantaInesWEB.Servicios.ServicioDepartamento;
using SantaInesWEB.Servicios.ServicioUsuario;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SantaInesWEB.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IServicioUsuario _servicioApiUsuario;

        public UsuariosController(IServicioUsuario servicioApiUsuario)
        {
            _servicioApiUsuario = servicioApiUsuario;
        }

        public async Task<IActionResult> GestionUsuarios()
        {
            try
            {
                return View(await _servicioApiUsuario.MostrarTabla());

            }
            catch (Exception ex)
            {
                throw ex.InnerException!;
            }
        }
    }
}
