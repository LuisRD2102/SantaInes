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



    }
}
