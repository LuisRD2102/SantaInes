using SantaInesAPI.BussinessLogic.DTO;
using SantaInesAPI.Persistence.Entity;

namespace SantaInesAPI.Persistence.DAO.Interface
{
    public interface IItinerarioDAO
    {
        public List<ItinerarioDTO> ConsultarItinerariosDAO();
        public ItinerarioDTO AgregarItinerarioDAO(Itinerario itinerario);
        public ItinerarioDTO ActualizarItinerarioDAO(Itinerario itinerario);
        public ItinerarioDTO EliminarItinerarioDAO(Guid id);
    }
}
