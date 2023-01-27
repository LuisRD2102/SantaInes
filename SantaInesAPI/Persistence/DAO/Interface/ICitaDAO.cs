using SantaInesAPI.BussinessLogic.DTO;
using SantaInesAPI.Persistence.Entity;

namespace SantaInesAPI.Persistence.DAO.Interface
{
    public interface ICitaDAO
    {
        public List<CitaDTO> ConsultarCitasDAO();
        public CitaDTO AgregarCitaoDAO(Cita cita);
        public CitaDTO ActualizarCitaDAO(Cita cita);
        public CitaDTO EliminarCitaDAO(Guid id);
    }
}
