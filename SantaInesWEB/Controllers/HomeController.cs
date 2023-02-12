using Microsoft.AspNetCore.Mvc;
using SantaInesWEB.Models;
using SantaInesWEB.Servicios.ServicioDepartamento;
using SantaInesWEB.Servicios.ServicioGrafica;
using System.Diagnostics;

namespace SantaInesWEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IServicioGrafica _servicioApiGrafica;

        public HomeController(ILogger<HomeController> logger, IServicioGrafica servicioApiGrafica)
        {
            _logger = logger;
            _servicioApiGrafica = servicioApiGrafica;
        }

        public async Task<IActionResult> Index()
        {
            GraphModel grafica = new GraphModel();
            grafica = await _servicioApiGrafica.GraficaGenero();
            return View(grafica);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}