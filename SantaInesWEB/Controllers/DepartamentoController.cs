using Microsoft.AspNetCore.Mvc;
using SantaInesWEB.Servicios.ServicioDepartamento;

namespace SantaInesWEB.Controllers
{
    public class DepartamentoController : Controller
    {
        private readonly IServicioDepartamento _servicioApiDepartamento;

        public DepartamentoController(IServicioDepartamento servicioApiDepartamento)
        {
            _servicioApiDepartamento = servicioApiDepartamento;
        }

        public async Task<IActionResult> GestionEmpleados()
        {
            return View(await _servicioApiDepartamento.MostrarTabla());
        }
    }
}
