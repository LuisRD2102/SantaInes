using SantaInesAPI.BussinessLogic.DTO;
using SantaInesAPI.Persistence.Entity;

namespace SantaInesAPI.BussinessLogic.Mapper
{
    public class DireccionMapper
    {
        public static DireccionDTO EntityToDTO(Direccion d)
        {
            return new DireccionDTO()
            {
                id = d.id,
                id_estado = d.id_estado,
                id_municipio = d.id_municipio,
                id_parroquia = d.id_parroquia,
                direccion = d.direccion,
                nb_estado = d.nb_estado,
                nb_municipio = d.nb_municipio,
                nb_parroquia = d.nb_parroquia
            };
        }

        public static Direccion DtoToEntity(DireccionDTO d)
        {
            return new Direccion()
            {
                id = d.id,
                id_estado = d.id_estado,
                id_municipio = d.id_municipio,
                id_parroquia = d.id_parroquia,
                direccion = d.direccion
            };
        }
    }
}
