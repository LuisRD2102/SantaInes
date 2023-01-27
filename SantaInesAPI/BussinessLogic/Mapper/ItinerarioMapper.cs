using SantaInesAPI.BussinessLogic.DTO;
using SantaInesAPI.Persistence.Entity;

namespace SantaInesAPI.BussinessLogic.Mapper
{
    public class ItinerarioMapper
    {
        public static ItinerarioDTO EntityToDTO(Itinerario i)
        {
            return new ItinerarioDTO()
            {
                id=i.id,
                hora_fin=i.hora_fin,
                hora_inicio=i.hora_inicio
            };
        }

        public static Itinerario DtoToEntity(ItinerarioDTO i)
        {
            return new Itinerario()
            {
                id = i.id,
                hora_fin = i.hora_fin,
                hora_inicio = i.hora_inicio
            };
        }

    }
}
