using SantaInesAPI.BussinessLogic.DTO;
using SantaInesAPI.Persistence.Entity;

namespace SantaInesAPI.BussinessLogic.Mapper
{
    public class ParroquiaMapper
    {
        public static ParroquiaDTO EntityToDTO(Parroquia d)
        {
            return new ParroquiaDTO()
            {
                id_parroquia = d.id_parroquia,
                id_municipio = d.id_municipio,
                parroquia = d.parroquia
            };
        }

        public static Parroquia DtoToEntity(ParroquiaDTO d)
        {
            return new Parroquia()
            {
                id_parroquia = d.id_parroquia,
                id_municipio = d.id_municipio,
                parroquia = d.parroquia
            };
        }
    }
}
