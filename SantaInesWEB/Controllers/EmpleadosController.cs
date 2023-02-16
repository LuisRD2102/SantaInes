using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;
using SantaInesWEB.Models;
using SantaInesWEB.Servicios.ServicioDepartamento;
using SantaInesWEB.Servicios.ServicioEmpleado;

namespace SantaInesWEB.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly IServicioEmpleado _servicioApiEmpleado;
        private readonly IServicioDepartamento _servicioApiDepartamento;

        public EmpleadosController(IServicioEmpleado servicioApiEmpleado, IServicioDepartamento servicioApiDepartamento)
        {
            _servicioApiEmpleado = servicioApiEmpleado;
            _servicioApiDepartamento = servicioApiDepartamento;
        }

        public async Task<IActionResult> GestionEmpleados()
        {
            var tupla = new Tuple<List<EmpleadoModel>, List<DepartamentoModel>>(null!, null!);
            tupla = await _servicioApiEmpleado.MostrarTabla();
            return View(tupla);
        }

        public async Task<IActionResult> AgregarEmpleado()
        {
            try
            {
                var resp = await _servicioApiDepartamento.MostrarTabla();
                List<SelectListItem> listItemsDepartamentos = crearDepartamentoDropDown(resp);
                var tupla = new Tuple<EmpleadoModel, List<SelectListItem>>(null!, listItemsDepartamentos);
                return PartialView(tupla);
            }
            catch (Exception ex)
            {
                throw ex.InnerException!;
            }
        }

         private static List<SelectListItem> crearDepartamentoDropDown(List<DepartamentoModel> lista)
         {
            List<SelectListItem> listItems = new List<SelectListItem>();

            foreach (var item in lista)
            {
                listItems.Add(new SelectListItem
                {
                    Text = item.nombre,
                    Value = item.id.ToString(),
                });
            }

            return listItems;
         }

        [HttpPost]
        public async Task<IActionResult> GuardarEmpleado([Bind(Prefix = "Item1")] EmpleadoModel empleado)
        {

            try
            {
                JObject respuesta = await _servicioApiEmpleado.RegistrarEmpleado(empleado);

                if ((bool)respuesta["success"])
                {
                    return RedirectToAction("GestionEmpleados", new { message = "Se ha agregado correctamente" });
                }
                else return RedirectToAction("GestionEmpleados", new { message2 = "La cédula ingresada ya existe" });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return NoContent();
        }

        public async Task<IActionResult> EditarEmpleado(string username)
        {
            try
            {
                EmpleadoModel empleado = new EmpleadoModel();
                var resp = await _servicioApiDepartamento.MostrarTabla();
                List<SelectListItem> listItemsDepartamentos = crearDepartamentoDropDown(resp);
                empleado = await _servicioApiEmpleado.MostrarInfoEmpleado(username);
                var tupla = new Tuple<EmpleadoModel, List<SelectListItem>>(empleado, listItemsDepartamentos);
                
                return PartialView(tupla);
            }
            catch (Exception ex)
            {
                throw ex.InnerException!;
            }
        }

        public async Task<IActionResult> ModificarEmpleado([Bind(Prefix = "Item1")] EmpleadoModel empleado)
        {
            try
            {
                JObject respuesta = await _servicioApiEmpleado.EditarEmpleado(empleado);
                if ((bool)respuesta["success"])
                    return RedirectToAction("GestionEmpleados", "Empleados", new { message = "Se ha modificado correctamente" });
                //else return RedirectToAction("GestionEmpleados", new { message2 = "El nombre del departamento ingresado ya existe" });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return NoContent();
        }

        public IActionResult EliminarEmpleado(string username)
        {
            try
            {
                return PartialView((object)username);
            }
            catch (Exception ex)
            {
                throw ex.InnerException!;
            }
        }

        [HttpGet]
        public async Task<IActionResult> AccionEliminarEmpleado(string username)
        {
            JObject respuesta;
            respuesta = await _servicioApiEmpleado.EliminarEmpleado(username);
            if ((bool)respuesta["success"])
                return RedirectToAction("GestionEmpleados", "Empleados", new { message = "Se ha eliminado correctamente" });
            else
                return NoContent();
        }
    }
}
