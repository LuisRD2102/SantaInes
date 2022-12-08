using Microsoft.EntityFrameworkCore;
using SantaInesAPI.BussinessLogic.DTO;
using SantaInesAPI.BussinessLogic.Mapper;
using SantaInesAPI.Persistence.DAO.Interface;
using SantaInesAPI.Persistence.Database;
using SantaInesAPI.Persistence.Entity;

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

                var data = _context.Direccion.Where(d => d.id == direccion.id).Select(
                    d => new DireccionDTO
                    {
                        id = d.id,
                        estado = d.estado,
                        municipio = d.municipio,
                        direccion = d.direccion,
                        codPostal = d.cod_postal
                    }
                );
                return data.First();
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

                var data = _context.Direccion.Where(d => d.id == direccion.id)
                            .Select(d => new DireccionDTO
                            {
                                id = d.id,
                                estado = d.estado,
                                municipio = d.municipio,
                                direccion = d.direccion,
                                codPostal = d.cod_postal                             

                            });

                return data.First();

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
                var lista = _context.Direccion.Select(
                    d => new DireccionDTO
                    {
                        id = d.id,
                        estado = d.estado,
                        municipio = d.municipio,
                        direccion = d.direccion,
                        codPostal = d.cod_postal
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
    }
}
