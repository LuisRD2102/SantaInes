using Microsoft.EntityFrameworkCore;
using SantaInesAPI.BussinessLogic.DTO;
using SantaInesAPI.BussinessLogic.Mapper;
using SantaInesAPI.Persistence.DAO.Interface;
using SantaInesAPI.Persistence.Database;
using SantaInesAPI.Persistence.Entity;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;

namespace SantaInesAPI.Persistence.DAO.Implementations
{
    public class DireccionDAO : IDireccionDAO
    {
        private readonly MigrationDbContext _context;

        public DireccionDAO(MigrationDbContext context)
        {
            _context = context;
        }
        public DireccionDTO ActualizarDireccionDAO(Direccion direccion)
        {
            try
            {
                _context.Direccion.Update(direccion);
                _context.SaveChanges();

                var data = _context.Direccion.Where(d => d.id == direccion.id).First();
                return DireccionMapper.EntityToDTO(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " || " + ex.StackTrace);
                throw new Exception("Fallo al actualizar: " + direccion.id, ex);
            }
        }

        public DireccionDTO AgregarDireccionDAO(Direccion direccion)
        {
            try
            {
                _context.Direccion.Add(direccion);
                _context.SaveChanges();

                var data = _context.Direccion.Where(d => d.id == direccion.id).First();

                return DireccionMapper.EntityToDTO(data);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " : " + ex.StackTrace);
                throw ex.InnerException!;
            }
        }

        public List<DireccionDTO> ConsultarDireccionDAO()
        {
            try
            {
                var lista = _context.Direccion                  
                    .Include(i => i.Estado)
                    .Include(i => i.Municipio)
                    .Include(i => i.Parroquia)
                    .Select(
                        d => DireccionMapper.EntityToDTO(d)
                    );

                return lista.ToList();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " : " + ex.StackTrace);
                throw ex.InnerException!;
            }
        }

        public DireccionDTO EliminarDireccionDAO(Guid id)
        {
            try
            {
                var direccion = _context.Direccion
                .Where(d => d.id == id).First();

                _context.Direccion.Remove(direccion);
                _context.SaveChanges();

                return DireccionMapper.EntityToDTO(direccion);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " || " + ex.StackTrace);
                throw new Exception("Fallo al Eliminar por id: " + id, ex);
            }
        }

        public DireccionDTO ConsultarPorID(Guid id)
        {
            try
            {
                var direccion = _context.Direccion
               .Where(d => d.id == id)
                    .Include(i => i.Estado)
                    .Include(i => i.Municipio)
                    .Include(i => i.Parroquia)
                    .First();

                return DireccionMapper.EntityToDTO(direccion);
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("No se encuentra la direccion" + " " + id, ex);
            }
        }

        public List<EstadoDTO> ConsultarEstados()
        {
            try
            {
                var lista = _context.Estados
                    .Select(
                        d => EstadoMapper.EntityToDTO(d)
                    );

                return lista.ToList();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " : " + ex.StackTrace);
                throw ex.InnerException!;
            }
        }

        public List<MunicipioDTO> ConsultarMunicipios(int id)
        {
            try
            {
                var lista = _context.Municipios.Where(m => m.id_estado == id)
                    .Select(
                        d => MunicipioMapper.EntityToDTO(d)
                    );

                return lista.ToList();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " : " + ex.StackTrace);
                throw ex.InnerException!;
            }
        }

        public List<ParroquiaDTO> ConsultarParroquias(int id)
        {
            try
            {
                var lista = _context.Parroquias.Where(p => p.id_municipio == id)
                    .Select(
                        d => ParroquiaMapper.EntityToDTO(d)
                    );

                return lista.ToList();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " : " + ex.StackTrace);
                throw ex.InnerException!;
            }
        }

    }
}
