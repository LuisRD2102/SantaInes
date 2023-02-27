using SantaInesAPI.BussinessLogic.DTO;
using SantaInesAPI.Persistence.Entity;

namespace SantaInesAPI.BussinessLogic.Mapper
{
    public class EstadoMapper
    {
        public static EstadoDTO EntityToDTO(Estado d)
        {
            return new EstadoDTO()
            {
                id_estado= d.id_estado,
                estado = d.estado 
            };
        }

        public static Estado DtoToEntity(EstadoDTO d)
        {
            return new Estado()
            {
                id_estado = d.id_estado,
                estado = d.estado
            };
        }
    }
}
