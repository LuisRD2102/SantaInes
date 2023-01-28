using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SantaInesWEB.Models;
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

        public IActionResult AgregarDepartamentoView()
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

        [HttpPost]
        public async Task<IActionResult> GuardarDepartamento(DepartamentoModel departamento)
        {

            try
            {
                JObject respuesta = await _servicioApiDepartamento.RegistrarDepartamento(departamento);

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
