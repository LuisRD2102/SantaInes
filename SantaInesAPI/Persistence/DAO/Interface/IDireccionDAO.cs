using SantaInesAPI.BussinessLogic.DTO;
using SantaInesAPI.Persistence.Entity;

namespace SantaInesAPI.Persistence.DAO.Interface
{
    public interface IDireccionDAO
    {
        public List<DireccionDTO> ConsultarDireccionDAO();
        public DireccionDTO AgregarDireccionDAO(Direccion direccion);
        public DireccionDTO ActualizarDireccionDAO(Direccion direccion);
        public DireccionDTO EliminarDireccionDAO(Guid id);
    }
}
