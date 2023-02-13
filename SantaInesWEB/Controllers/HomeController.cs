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

        public async Task<IActionResult> Index(int? mes)
        {
            DashboardModel modeloDashboard = new DashboardModel();
            //Graficas
            modeloDashboard.mes = mes is not null ? mes : DateTime.Now.Month;
            modeloDashboard.graficaGenero = await _servicioApiGrafica.GraficaGenero(modeloDashboard.mes);
            modeloDashboard.graficaTopDoctores = await _servicioApiGrafica.GraficaTopDoctores(modeloDashboard.mes);
            modeloDashboard.graficaDepartamentos = await _servicioApiGrafica.GraficaDepartamentoPorCitas(modeloDashboard.mes);
            modeloDashboard.graficaRangoEdad = await _servicioApiGrafica.GraficaPacientesRangoEdad();

            //Estadisticas
            modeloDashboard.CantidadCitasConfirmadas = await _servicioApiGrafica.CantidadCitasConfirmadas(modeloDashboard.mes);
            modeloDashboard.CantidadCitasPendientes = await _servicioApiGrafica.CantidadCitasPendientes(modeloDashboard.mes);
            modeloDashboard.CantidadDoctores = await _servicioApiGrafica.CantidadDoctores();
            modeloDashboard.CantidadPacientes = await _servicioApiGrafica.CantidadPacientes();

            return View(modeloDashboard);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}