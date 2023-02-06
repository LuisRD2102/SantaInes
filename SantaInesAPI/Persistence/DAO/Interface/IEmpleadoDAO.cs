using Microsoft.AspNetCore.Mvc;
using SantaInesAPI.BussinessLogic.DTO;
using SantaInesAPI.Persistence.Entity;

namespace SantaInesAPI.Persistence.DAO.Interface
{
    public interface IEmpleadoDAO
    {
        public List<EmpleadoDTO> ConsultarEmpleadoDAO();
        public EmpleadoDTO AgregarEmpleadoDAO(Empleado empleado);
        public EmpleadoDTO ActualizarEmpleadoDAO(Empleado empleado);
        public EmpleadoDTO EliminarEmpleadoDAO(string empleado);
        public EmpleadoDTO VerificarDatosLogin(string username, string pass);
        public EmpleadoDTO ConsultarPorUsername(string username);
        public Task<IEnumerable<Empleado>> GetDoctors();
    }
}
