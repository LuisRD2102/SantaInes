using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SantaInesWEB.Models;

namespace SantaInesWEB.Servicios.ServicioEmpleado
{
	public interface IServicioEmpleado
	{
		Task<JObject> ValidarEmpleadoLogin(string username, string password);
        Task<Tuple<List<EmpleadoModel>,List<DepartamentoModel>>> MostrarTabla();
        Task<JObject> RegistrarEmpleado(EmpleadoModel empleado);
        Task<JObject> EditarEmpleado(EmpleadoModel empleado);
        Task<EmpleadoModel> MostrarInfoEmpleado(string username);
        Task<JObject> EliminarEmpleado(string username);
    }
}
