using SantaInesAPI.BussinessLogic.DTO;
using SantaInesAPI.Persistence.Entity;

namespace SantaInesAPI.BussinessLogic.Mapper
{
    public class MunicipioMapper
    {
        public static MunicipioDTO EntityToDTO(Municipio d)
        {
            return new MunicipioDTO()
            {
                id_municipio = d.id_municipio,
                id_estado = d.id_estado,
                municipio = d.municipio
            };
        }

        public static Municipio DtoToEntity(MunicipioDTO d)
        {
            return new Municipio()
            {
                id_municipio = d.id_municipio,
                id_estado = d.id_estado,
                municipio = d.municipio
            };
        }
    }
}
