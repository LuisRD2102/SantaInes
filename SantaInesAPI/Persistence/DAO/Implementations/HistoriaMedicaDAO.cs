using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.DayPilot_Handler;
using SantaInesAPI.BussinessLogic.DTO;
using SantaInesAPI.BussinessLogic.Mapper;
using SantaInesAPI.Migrations;
using SantaInesAPI.Persistence.DAO.Interface;
using SantaInesAPI.Persistence.Database;
using SantaInesAPI.Persistence.Entity;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using System.Net;

namespace SantaInesAPI.Persistence.DAO.Implementations
{
    public class HistoriaMedicaDAO : IHistoriaMedicaDAO
    {
        private readonly MigrationDbContext _context;

        public HistoriaMedicaDAO(MigrationDbContext context)
        {
            _context = context;
        }

        public HistoriaMedicaDTO CrearHistoriaMedica(Guid id)
        {
            try
            {
                HistoriaMedica hm = new HistoriaMedica();
                hm.idHistoria = id;
                _context.HistoriaMedicas.Add(hm);
                _context.SaveChanges();

                var data = _context.HistoriaMedicas.Where(u => u.idHistoria == hm.idHistoria).First();
                return HistoriaMedicaMapper.EntityToDTO(data);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " : " + ex.StackTrace);
                throw ex.InnerException!;
            }
        }

        public HistoriaMedicaDTO GetHistoriaMedica(Guid id)
        {
            try
            {
                var hm = _context.HistoriaMedicas
               .Where(d => d.idHistoria == id).First();
                return HistoriaMedicaMapper.EntityToDTO(hm);
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("No se encuentra la historia medica" + " " + id, ex);
            }
        }

        public HistoriaMedicaDTO ActualizarHistoriaMedicaDAO(HistoriaMedica historiaMedica)
        {
            try
            {
                _context.HistoriaMedicas.Update(historiaMedica);
                _context.SaveChanges();

                var data = _context.HistoriaMedicas.Where(u => u.idHistoria == historiaMedica.idHistoria).First();
                return HistoriaMedicaMapper.EntityToDTO(data);

            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("No se encuentra la historia medica", ex);
            }
        }
    }
}
