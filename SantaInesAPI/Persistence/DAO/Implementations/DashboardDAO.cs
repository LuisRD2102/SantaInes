using Microsoft.EntityFrameworkCore;
using SantaInesAPI.BussinessLogic.DTO;
using SantaInesAPI.Persistence.DAO.Interface;
using SantaInesAPI.Persistence.Database;

namespace SantaInesAPI.Persistence.DAO.Implementations
{
    public class DashboardDAO : IDashboardDAO
    {
        private readonly MigrationDbContext _context;

        public DashboardDAO(MigrationDbContext context)
        {
            _context = context;
        }

        public DashboardDTO GraficaGenero()
        {
            try
            {
                DashboardDTO dto = new DashboardDTO();
                dto.labels = new string[] { "Hombre", "Mujeres"};
                var dataTemp = new int[2];
                var mesActual = DateTime.Now.Month;
                dataTemp[0] = _context.Citas.Where(c => c.Start.Month == mesActual && c.Usuario.sexo == Char.ToString('M') && c.Status=="Confirmada").Include(u => u.Usuario).Count();
                dataTemp[1] = _context.Citas.Where(c => c.Start.Month == mesActual && c.Usuario.sexo == Char.ToString('F') && c.Status == "Confirmada").Include(u => u.Usuario).Count();
                dto.data = dataTemp;
                return dto;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " : " + ex.StackTrace);
                throw ex.InnerException!;
            }
        }

    }
}
