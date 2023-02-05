using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SantaInesWEB.Models;
using SantaInesWEB.Servicios.ServicioDireccion;
using SantaInesWEB.Servicios.ServicioUsuario;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SantaInesWEB.Controllers
{
    public class CitasController : Controller
    {
        private readonly IServicioCita _servicioCita;

        public CitasController(IServicioCita servicioCita)
        {
            _servicioCita = servicioCita;

        }
        public IActionResult GestionCitas()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                throw ex.InnerException!;
            }
        }

        public IActionResult GestionCitasDoctor()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                throw ex.InnerException!;
            }
        }

    }
}
