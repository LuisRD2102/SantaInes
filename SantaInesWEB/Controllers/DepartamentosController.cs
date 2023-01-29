using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SantaInesWEB.Models;
using SantaInesWEB.Servicios.ServicioDepartamento;

namespace SantaInesWEB.Controllers
{ 
    public class DepartamentosController : Controller
    {
        private readonly IServicioDepartamento _servicioApiDepartamento;

        public DepartamentosController(IServicioDepartamento servicioApiDepartamento)
        {
            _servicioApiDepartamento = servicioApiDepartamento;
        }

        public IActionResult AgregarDepartamento()
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

        public async Task<IActionResult> EditarDepartamento(Guid id)
        {
            try
            {
                DepartamentoModel departamento = new DepartamentoModel();
                departamento = await _servicioApiDepartamento.MostrarInfoDepartamento(id);
                return PartialView(departamento);
            }
            catch (Exception ex)
            {
                throw ex.InnerException!;
            }
        }

        public async Task<IActionResult> ModificarDepartamento(DepartamentoModel dept)
        {
            try
            {
                JObject respuesta = await _servicioApiDepartamento.EditarDepartamento(dept);
                if ((bool)respuesta["success"])
                    return RedirectToAction("GestionEmpleados"/*, new { message = "Se ha modificado correctamente" }*/);
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
