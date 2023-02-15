using SantaInesAPI.BussinessLogic.DTO;
using SantaInesAPI.Persistence.Entity;

namespace SantaInesAPI.Persistence.DAO.Interface
{
    public interface IHistoriaMedicaDAO
    {
        public HistoriaMedicaDTO CrearHistoriaMedica(Guid id);
        public HistoriaMedicaDTO GetHistoriaMedica(Guid id);
        public HistoriaMedicaDTO ActualizarHistoriaMedicaDAO(HistoriaMedica historiaMedic);
    }
}
