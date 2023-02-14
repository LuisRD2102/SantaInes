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
    public class HistoriaMedicaController : Controller
    {
        //private readonly IServicioCita _servicioCita;

        //public HistoriaMedicaController(IServicioCita servicioCita)
        //{
        //    _servicioCita = servicioCita;

        //}
        public IActionResult HistoriaMedica()
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
