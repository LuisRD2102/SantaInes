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
                municipio = d.municipio,
                direccion = d.direccion,               
                codPostal = d.cod_postal
                
            };
        }

        public static Direccion DtoToEntity(DireccionDTO d)
        {
            return new Direccion()
            {
                id = d.id,
                municipio = d.municipio,
                direccion = d.direccion,
                cod_postal = d.codPostal
            };
        }
    }
}
