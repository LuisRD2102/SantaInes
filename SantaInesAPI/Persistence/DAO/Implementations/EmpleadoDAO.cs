using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SantaInesAPI.BussinessLogic.DTO;
using SantaInesAPI.BussinessLogic.Mapper;
using SantaInesAPI.Migrations;
using SantaInesAPI.Persistence.DAO.Interface;
using SantaInesAPI.Persistence.Database;
using SantaInesAPI.Persistence.Entity;

namespace SantaInesAPI.Persistence.DAO.Implementations
{
    public class EmpleadoDAO : IEmpleadoDAO
    {
        private readonly MigrationDbContext _context;

        public EmpleadoDAO(MigrationDbContext context)
        {
            _context = context;
        }

        public EmpleadoDTO ActualizarEmpleadoDAO(Empleado empleado)
        {
            try
            {
                _context.Empleados.Update(empleado);
                _context.SaveChanges();

                var data = _context.Empleados.Where(e => e.username == empleado.username).Select(
                    e => new EmpleadoDTO
                    {
                        username = e.username,
                        password = e.password,
                        cedula = e.cedula,
                        sexo = e.sexo,
                        nombre_completo = e.nombre_completo,
                        apellido_completo = e.apellido_completo,
                        rol = e.rol,
                        id_departamento = e.id_departamento,
                        id_itinerario = e.id_itinerario
                    }
                );
                return data.First();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " || " + ex.StackTrace);
                throw new Exception("Fallo al actualizar: " + empleado.username, ex);
            }
        }

        public EmpleadoDTO AgregarEmpleadoDAO(Empleado empleado)
        {
            try
            {
                if (!(ExisteCedula(empleado))) {
                    _context.Empleados.Add(empleado);
                    _context.SaveChanges();
                }

                var data = _context.Empleados.Where(e => e.username == empleado.username).First();
                return EmpleadoMapper.EntityToDTO(data);

                //var data = _context.Empleados.Where(e => e.username == empleado.username)
                //            .Select(e => new EmpleadoDTO
                //            {
                //                username = e.username,
                //                password = e.password,
                //                cedula = e.cedula,
                //                nombre_completo = e.nombre_completo,
                //                apellido_completo = e.apellido_completo,
                //                rol = e.rol,
                //                id_departamento = e.id_departamento,
                //                id_itinerario = e.id_itinerario
                //            });

                //return data.First();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " : " + ex.StackTrace);
                throw ex.InnerException!;
            }
        }

        public List<EmpleadoDTO> ConsultarEmpleadoDAO()
        {
            try
            {
                var lista = _context.Empleados.Select(
                    e => new EmpleadoDTO
                    {
                        username = e.username,
                        password = e.password,
                        cedula = e.cedula,
                        sexo = e.sexo,
                        nombre_completo = e.nombre_completo,
                        apellido_completo = e.apellido_completo,
                        rol = e.rol,
                        id_departamento = e.id_departamento,
                        id_itinerario = e.id_itinerario
                    }
                );

                return lista.ToList();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " : " + ex.StackTrace);
                throw ex.InnerException!;
            }
        }

        public EmpleadoDTO EliminarEmpleadoDAO(String username)
        {
            try
            {
                var empleado = _context.Empleados.Where(e => e.username == username).First();

                Guid? idDepartamento = empleado.id_departamento;
                _context.Empleados.Remove(empleado);
                _context.SaveChanges();

                var departamentoAsoc = _context.Departamentos.Where(d => d.id == idDepartamento).First();

                _context.Departamentos.Remove(departamentoAsoc);
                _context.SaveChanges();

                return EmpleadoMapper.EntityToDTO(empleado);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " || " + ex.StackTrace);
                throw new Exception("Fallo al Eliminar por empleado: " + username, ex);
            }
        }

        public bool ExisteCedula(Empleado empleado)
        {
            bool existe = false;

            try
            {
                var nuevoEmpleado = _context.Empleados.Where(d => d.cedula.Equals(empleado.cedula));
                if (nuevoEmpleado.Count() != 0)
                    existe = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " || " + ex.StackTrace);
                throw new Exception("Empleado no encontrado: " + empleado, ex);
            }
            return existe;
        }
     
        public EmpleadoDTO VerificarDatosLogin(string username, string pass)
        {
            try
            {
                var empleado = _context.Empleados.Where(u => u.username == username && u.password == pass).First();
                return EmpleadoMapper.EntityToDTO(empleado);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " || " + ex.StackTrace);
                throw new Exception("Usuario o contraseña incorrectos", ex);
            }
        }

        public async Task<IEnumerable<Empleado>> GetDoctors()
        {
            return await _context.Empleados.Where(u => u.rol == "Doctor").ToListAsync();
        }
    }
}
