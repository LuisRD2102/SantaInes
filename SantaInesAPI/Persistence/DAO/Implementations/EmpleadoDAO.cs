using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SantaInesAPI.BussinessLogic.DTO;
using SantaInesAPI.BussinessLogic.Mapper;
using SantaInesAPI.Migrations;
using SantaInesAPI.Persistence.DAO.Interface;
using SantaInesAPI.Persistence.Database;
using SantaInesAPI.Persistence.Entity;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;

namespace SantaInesAPI.Persistence.DAO.Implementations
{
    public class EmpleadoDAO : IEmpleadoDAO
    {
        private readonly MigrationDbContext _context;
        private readonly ICitaDAO _citaDAO;

        public EmpleadoDAO(MigrationDbContext context, ICitaDAO citaDAO)
        {
            _context = context;
            _citaDAO = citaDAO;
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
                        id_departamento = e.id_departamento
                    }
                );
                return data.First();
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("Ya existe la cedula ingresada" + " " + empleado.cedula, ex);
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

            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("Ya existe la cedula ingresada" + " " + empleado.cedula, ex);
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
                        id_departamento = e.id_departamento
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

        public EmpleadoDTO EliminarEmpleadoDAO(string username)
        {
            var empleadoDTO = new EmpleadoDTO();

            try
            {
                var empleado = _context.Empleados
                        .Where(d => d.username == username).Include(u => u.Citas).First();

                if (empleado != null)
                {
                    if (QuitarAsociacionDepartamentos(empleado.id_departamento))
                    {
                        empleadoDTO = EmpleadoMapper.EntityToDTO(empleado);
                    }

                    if (QuitarAsociacionCitas(empleado))
                    {
                        empleadoDTO = EmpleadoMapper.EntityToDTO(empleado);
                    }

                    _context.Empleados.Remove(empleado);
                    _context.SaveChanges();


                }
                return empleadoDTO;
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("No se encuentra el empleado" + " " + username, ex);
            }
        }

        public bool QuitarAsociacionCitas(Empleado empleado)
        {
            var asociacionQuitada = false;
            try
            {
                              
                if (empleado.Citas != null)
                {
                    foreach (var cita in empleado.Citas.ToList())
                    {
                        cita.doctor = null;
                        cita.patient = null;
                       _citaDAO.EliminarCita(cita.id);
                    }

                    _context.SaveChanges();
                    return asociacionQuitada = true;
                }              

            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("Fallo al quitar asociacion a un grupo", ex);
            }

            return asociacionQuitada;
        }

        public bool QuitarAsociacionDepartamentos(Guid? deptID)
        {
            var asociacionQuitada = false;
            try
            {
                var listaEmpleados = _context.Empleados.Where(x => x.id_departamento == deptID && x.rol == "Doctor" );

                if (listaEmpleados != null)
                {

                    foreach (var item in listaEmpleados)
                    {
                        item.id_departamento = null;

                    }
                    _context.UpdateRange(listaEmpleados);
                    _context.SaveChanges();
                    return asociacionQuitada = true;

                }

            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("Fallo al quitar asociacion a un grupo", ex);
            }

            return asociacionQuitada;
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

        public EmpleadoDTO ConsultarPorUsername(string username)
        {
            try
            {

                var empleado = _context.Empleados
               .Where(d => d.username == username).First();
                return EmpleadoMapper.EntityToDTO(empleado);

            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("No se encuentra el empleado" + " " + username, ex);
            }
        }

        public async Task<IEnumerable<Empleado>> GetDoctors()
        {
            return await _context.Empleados.Where(u => u.rol == "Doctor").ToListAsync();
        }
    }
}
