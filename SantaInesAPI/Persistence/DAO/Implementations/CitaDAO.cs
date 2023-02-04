using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Project.Service;
using SantaInesAPI.BussinessLogic.DTO;
using SantaInesAPI.BussinessLogic.Mapper;
using SantaInesAPI.Persistence.DAO.Interface;
using SantaInesAPI.Persistence.Database;
using SantaInesAPI.Persistence.Entity;
using System.Collections;
using System.Net;
using static SantaInesAPI.Controllers.CitaController;

namespace SantaInesAPI.Persistence.DAO.Implementations
{
    public class CitaDAO : ICitaDAO
    {
        private readonly MigrationDbContext _context;

        public CitaDAO(MigrationDbContext context)
        {
            _context = context;
        }
        //    public CitaDTO ActualizarCitaDAO(Cita cita)
        //    {
        //        try
        //        {
        //            _context.Citas.Update(cita);
        //            _context.SaveChanges();

        //            var data = _context.Citas.Where(c => c.id == cita.id).Select(
        //                c => new CitaDTO
        //                {
        //                    id = c.id,
        //                    doctor = c.doctor,
        //                    fecha_hora = c.fecha_hora,
        //                    paciente = c.paciente
        //                }
        //            );
        //            return data.First();
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine(ex.Message + " || " + ex.StackTrace);
        //            throw new Exception("Fallo al actualizar: " + cita.id, ex);
        //        }
        //    }

        public async Task<ActionResult<HttpStatusCode>> AgregarCitaDAO(AppointmentSlotRange range)
        {
            try
            {
                var doctor = await _context.Empleados.Where(u => u.rol == "Doctor" && u.username == range.Resource).FirstAsync();

                var slots = Timeline.GenerateSlots(range.Start, range.End, range.Scale);
                slots.ForEach(slot => {
                    slot.Empleado = doctor;
                    _context.Citas.Add(slot);
                });

                await _context.SaveChangesAsync();

                return HttpStatusCode.NoContent;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " : " + ex.StackTrace);
                throw ex.InnerException!;
            }
        }

        public async Task<IEnumerable<Cita>> ConsultarCitasDAO(DateTime start, DateTime end, string? doctor)
        {
            try
            {
                if (doctor == null)
                {
                    return await _context.Citas.Where(e => !((e.End <= start) || (e.Start >= end))).Include(e => e.Empleado).ToListAsync();
                }
                else
                {
                    return await _context.Citas.Where(e => e.Empleado.username == doctor && !((e.End <= start) || (e.Start >= end))).Include(e => e.Empleado).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " : " + ex.StackTrace);
                throw ex.InnerException!;
            }
        }

        public Cita EliminarCitaDAO(Guid id)
        {
            try
            {
                var cita = _context.Citas
                .Where(c => c.id == id).First();

                _context.Citas.Remove(cita);
                _context.SaveChanges();

                return cita;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " || " + ex.StackTrace);
                throw new Exception("Fallo al Eliminar por id: " + id, ex);
            }
        }
    }
}
