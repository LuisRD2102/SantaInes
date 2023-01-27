using Microsoft.EntityFrameworkCore;
using SantaInesAPI.BussinessLogic.DTO;
using SantaInesAPI.BussinessLogic.Mapper;
using SantaInesAPI.Persistence.DAO.Interface;
using SantaInesAPI.Persistence.Database;
using SantaInesAPI.Persistence.Entity;

namespace SantaInesAPI.Persistence.DAO.Implementations
{
    public class CitaDAO : ICitaDAO
    {
        private readonly MigrationDbContext _context;

        public CitaDAO(MigrationDbContext context)
        {
            _context = context;
        }
        public CitaDTO ActualizarCitaDAO(Cita cita)
        {
            try
            {
                _context.Citas.Update(cita);
                _context.SaveChanges();

                var data = _context.Citas.Where(c => c.id == cita.id).Select(
                    c => new CitaDTO
                    {
                        id = c.id,
                        doctor = c.doctor,
                        fecha_hora = c.fecha_hora,
                        id_departamento = c.id_departamento,
                        paciente = c.paciente
                    }
                );
                return data.First();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " || " + ex.StackTrace);
                throw new Exception("Fallo al actualizar: " + cita.id, ex);
            }
        }

        public CitaDTO AgregarCitaDAO(Cita cita)
        {
            try
            {
                _context.Citas.Add(cita);
                _context.SaveChanges();

                var data = _context.Citas.Where(c => c.id == cita.id)
                            .Select(c => new CitaDTO
                            {
                                id = c.id,
                                doctor = c.doctor,
                                fecha_hora = c.fecha_hora,
                                id_departamento = c.id_departamento,
                                paciente = c.paciente

                            });

                return data.First();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " : " + ex.StackTrace);
                throw ex.InnerException!;
            }
        }

        public List<CitaDTO> ConsultarCitasDAO()
        {
            try
            {
                var lista = _context.Citas.Select(
                    c => new CitaDTO
                    {
                        id = c.id,
                        doctor = c.doctor,
                        fecha_hora = c.fecha_hora,
                        id_departamento = c.id_departamento,
                        paciente = c.paciente
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

        public CitaDTO EliminarCitaDAO(Guid id)
        {
            try
            {
                var cita = _context.Citas
                .Where(c => c.id == id).First();

                _context.Citas.Remove(cita);
                _context.SaveChanges();

                return CitaMapper.EntityToDTO(cita);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " || " + ex.StackTrace);
                throw new Exception("Fallo al Eliminar por id: " + id, ex);
            }
        }
    }
}
