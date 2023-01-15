using Microsoft.AspNetCore.Mvc;
using SantaInesWEB.Models;
using SantaInesWEB.Servicios.ServicioEmpleado;

namespace SantaInesWEB.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly IServicioEmpleado _servicioApiEmpleado;

        public EmpleadosController(IServicioEmpleado servicioApiEmpleado)
        {
            _servicioApiEmpleado = servicioApiEmpleado;
        }

        public async Task<IActionResult> GestionEmpleados()
        {
            var tupla = new Tuple<List<EmpleadoModel>, List<DepartamentoModel>>(null, null);
            tupla = await _servicioApiEmpleado.MostrarTabla();
            return View(tupla);
            //return View(await _servicioApiDepartamento.MostrarTabla());
        }
    }
}
