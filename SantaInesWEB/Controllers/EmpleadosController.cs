using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
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
        }

        public IActionResult AgregarEmpleado()
        {
            try
            {
                return PartialView();
            }
            catch (Exception ex)
            {
                throw ex.InnerException!;
            }
        }

        [HttpPost]
        public async Task<IActionResult> GuardarEmpleado(EmpleadoModel empleado)
        {

            try
            {
                JObject respuesta = await _servicioApiEmpleado.RegistrarEmpleado(empleado);

                if ((bool)respuesta["success"])
                {
                    return RedirectToAction("GestionEmpleados", new { message = "Se ha agregado correctamente" });
                }
                //else return RedirectToAction("GestionEmpleados", new { message2 = "El nombre del departamento ingresado ya existe" });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return NoContent();
        }
    }
}
