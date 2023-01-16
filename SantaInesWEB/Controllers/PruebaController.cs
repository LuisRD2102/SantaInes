using Microsoft.AspNetCore.Mvc;
using SantaInesWEB.Servicios.ServicioDepartamento;
using SantaInesWEB.Servicios.ServicioEmpleado;

namespace SantaInesWEB.Controllers
{
    public class PruebaController : Controller
    {
        private readonly IServicioDepartamento _servicioDepartamento;

        public PruebaController(IServicioDepartamento servicioDepartamento)
        {
            _servicioDepartamento = servicioDepartamento;
        }

        public async Task<IActionResult> PruebaDepartamento()
        {
            return View(await _servicioDepartamento.MostrarTabla());
        }
    }
}
