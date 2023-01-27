using Microsoft.EntityFrameworkCore;
using SantaInesAPI.BussinessLogic.DTO;
using SantaInesAPI.BussinessLogic.Mapper;
using SantaInesAPI.Persistence.DAO.Interface;
using SantaInesAPI.Persistence.Database;
using SantaInesAPI.Persistence.Entity;

namespace SantaInesAPI.Persistence.DAO.Implementations
{
    public class ItinerarioDAO : IItinerarioDAO
    {
        private readonly MigrationDbContext _context;

        public ItinerarioDAO(MigrationDbContext context)
        {
            _context = context;
        }
        public ItinerarioDTO ActualizarItinerarioDAO(Itinerario itinerario)
        {
            try
            {
                _context.Itinerarios.Update(itinerario);
                _context.SaveChanges();

                var data = _context.Itinerarios.Where(c => c.id == itinerario.id).Select(
                    i => new ItinerarioDTO
                    {
                        id = i.id,
                        hora_fin = i.hora_fin,
                        hora_inicio = i.hora_inicio
                    }
                );
                return data.First();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " || " + ex.StackTrace);
                throw new Exception("Fallo al actualizar: " + itinerario.id, ex);
            }
        }

        public ItinerarioDTO AgregarItinerarioDAO(Itinerario itinerario)
        {
            try
            {
                _context.Itinerarios.Add(itinerario);
                _context.SaveChanges();

                var data = _context.Itinerarios.Where(c => c.id == itinerario.id)
                            .Select(i => new ItinerarioDTO
                            {
                                id = i.id,
                                hora_fin = i.hora_fin,
                                hora_inicio = i.hora_inicio

                            });

                return data.First();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " : " + ex.StackTrace);
                throw ex.InnerException!;
            }
        }

        public List<ItinerarioDTO> ConsultarItinerariosDAO()
        {
            try
            {
                var lista = _context.Itinerarios.Select(
                    i => new ItinerarioDTO
                    {
                        id = i.id,
                        hora_fin = i.hora_fin,
                        hora_inicio = i.hora_inicio
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

        public ItinerarioDTO EliminarItinerarioDAO(Guid id)
        {
            try
            {
                var itinerario = _context.Itinerarios
                .Where(c => c.id == id).First();

                _context.Itinerarios.Remove(itinerario);
                _context.SaveChanges();

                return ItinerarioMapper.EntityToDTO(itinerario);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " || " + ex.StackTrace);
                throw new Exception("Fallo al Eliminar por id: " + id, ex);
            }
        }
    }
}
