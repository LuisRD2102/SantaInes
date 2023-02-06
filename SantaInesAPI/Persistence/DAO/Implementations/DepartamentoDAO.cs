using SantaInesAPI.BussinessLogic.DTO;
using SantaInesAPI.BussinessLogic.Mapper;
using SantaInesAPI.Persistence.DAO.Interface;
using SantaInesAPI.Persistence.Database;
using SantaInesAPI.Persistence.Entity;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;

namespace SantaInesAPI.Persistence.DAO.Implementations
{
    public class DepartamentoDAO : IDepartamentoDAO
    {
        private readonly MigrationDbContext _context;

        public DepartamentoDAO(MigrationDbContext context)
        {
            _context = context;
        }

        public DepartamentoDTO ActualizarDepartamentoDAO(Departamento departamento)
        {
            try
            {
                _context.Departamentos.Update(departamento);
                _context.SaveChanges();

                var data = _context.Departamentos.Where(u => u.id == departamento.id).First();
                return DepartamentoMapper.EntityToDTO(data);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " : " + ex.StackTrace);
                throw ex.InnerException!;
            }
        }

        public DepartamentoDTO AgregarDepartamentoDAO(Departamento departamento)
        {
            try
            {
                _context.Departamentos.Add(departamento);
                _context.SaveChanges();

                var data = _context.Departamentos.Where(u => u.id == departamento.id).First();
                return DepartamentoMapper.EntityToDTO(data);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " : " + ex.StackTrace);
                throw ex.InnerException!;
            }
        }

        public List<DepartamentoDTO> ConsultarDepartamentoDAO()
        {
            try
            {
                var lista = _context.Departamentos.Select(
                    u => new DepartamentoDTO
                    {
                        id = u.id,
                        nombre = u.nombre,
                        descripcion = u.descripcion
                        
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
         
        public DepartamentoDTO EliminarDepartamentoDAO(Guid id)
        {
            var departamentoDTO = new DepartamentoDTO();

            try
            {
                var departamento = _context.Departamentos
                        .Where(d => d.id == id).First();

                if (departamento != null)
                {
                    if (QuitarAsociacion(id))
                    {
                        departamentoDTO = DepartamentoMapper.EntityToDTO(departamento);
                    }

                    _context.Departamentos.Remove(departamento);
                    _context.SaveChanges();


                }
                return departamentoDTO;
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("No se encuentra el departamento" + " " + id, ex);
            }
        }

        public bool QuitarAsociacion(Guid deptID)
        {
            var asociacionQuitada = false;
            try
            {
                var listaEmpleados = _context.Empleados.Where(x => x.id_departamento == deptID);

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

        public DepartamentoDTO ConsultarPorID(Guid id)
        {
            try
            {

                var departamento = _context.Departamentos
               .Where(d => d.id == id).First();
                return DepartamentoMapper.EntityToDTO(departamento);

            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("No se encuentra el departamento" + " " + id, ex);
            }
        }


    }
}
