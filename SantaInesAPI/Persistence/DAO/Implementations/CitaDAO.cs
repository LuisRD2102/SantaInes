using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.DayPilot_Handler;
using SantaInesAPI.Persistence.DAO.Interface;
using SantaInesAPI.Persistence.Database;
using SantaInesAPI.Persistence.Entity;
using System.Net;

namespace SantaInesAPI.Persistence.DAO.Implementations
{
    public class CitaDAO : ICitaDAO
    {
        private readonly MigrationDbContext _context;

        public CitaDAO(MigrationDbContext context)
        {
            _context = context;
        }
        
        public async Task<ActionResult<HttpStatusCode>> AgregarCita(AppointmentSlotRange range)
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

        public async Task<IEnumerable<Cita>> ConsultarCitasLibres(DateTime start, DateTime end, string patient)
        {
            try
            {
                return await _context.Citas.Where(e => (e.Status == "free" || (e.Status != "free" && e.paciente == patient)) && !((e.End <= start) || (e.Start >= end))).Include(e => e.Empleado).ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " : " + ex.StackTrace);
                throw ex.InnerException!;
            }
        }

        public async Task<IEnumerable<Cita>> ConsultarCitas(DateTime start, DateTime end, string? doctor)
        {
            try
            {
                if (doctor == null)
                {
                    return await _context.Citas.Where(e => !((e.End <= start) || (e.Start >= end))).Include(e => e.Empleado).Where(e => e.Empleado.rol == "Doctor").ToListAsync();
                }
                else
                {
                    return await _context.Citas.Where(e => e.Empleado.username == doctor && !((e.End <= start) || (e.Start >= end))).Include(e => e.Empleado).Where(e => e.Empleado.rol == "Doctor").ToListAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " : " + ex.StackTrace);
                throw ex.InnerException!;
            }
        }

        public Cita EliminarCita(Guid id)
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

        public async Task<ActionResult<HttpStatusCode>> ActualizarCita(Guid id, AppointmentSlotRequest slotRequest)
        {
            try
            {

                var appointmentSlot = await _context.Citas.FindAsync(id);
                if (appointmentSlot == null)
                {
                    return HttpStatusCode.NoContent;
                }
                appointmentSlot.paciente = slotRequest.Patient;
                appointmentSlot.Status = "waiting";
                appointmentSlot.Usuario = await _context.Usuario.FindAsync(appointmentSlot.paciente);
                _context.Citas.Update(appointmentSlot);
                await _context.SaveChangesAsync();
                //Console.WriteLine(await _context.Citas.FindAsync(id));
                return HttpStatusCode.NoContent;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " : " + ex.StackTrace);
                throw ex.InnerException!;
            }
        }

        public async Task<ActionResult<HttpStatusCode>> ActualizarSlotCita(Guid id, AppointmentSlotUpdate update)
        {
            try
            {
                var appointmentSlot = await _context.Citas.FindAsync(id);
                if (appointmentSlot == null)
                {
                    return HttpStatusCode.NotFound;
                }

                appointmentSlot.Start = update.Start;
                appointmentSlot.End = update.End;

                if (update.Name != null)
                {
                    appointmentSlot.paciente = update.Name;
                }
                if (update.Status != null)
                {
                    appointmentSlot.Status = update.Status;
                }

                _context.Citas.Update(appointmentSlot);
                await _context.SaveChangesAsync();

                return HttpStatusCode.NoContent;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " : " + ex.StackTrace);
                throw ex.InnerException!;
            }
        }


    }
}
