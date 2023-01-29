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
            try
            {
                var departamento = _context.Departamentos
                    .Where(d => d.id == id).First();

                _context.Departamentos.Remove(departamento);
                _context.SaveChanges();

                return DepartamentoMapper.EntityToDTO(departamento);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " || " + ex.StackTrace);
                throw new Exception("Fallo al eliminar por id: " + id, ex);
            }
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
