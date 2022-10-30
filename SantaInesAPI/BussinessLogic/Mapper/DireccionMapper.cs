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
                Id = d.id,
                Estado = d.estado,
                Municipio = d.municipio,
                Calle = d.calle,
                EdifCasa = d.edif_casa,
                NumCasaApto = d.num_casa_apto,
                CodPostal = d.cod_postal
            };
        }

        public static Direccion DtoToEntity(DireccionDTO d)
        {
            return new Direccion()
            {
                id = Guid.NewGuid(),
                estado = d.Estado,
                municipio = d.Municipio,
                calle = d.Calle,
                edif_casa = d.EdifCasa,
                num_casa_apto = d.NumCasaApto,
                cod_postal = d.CodPostal
            };
        }
    }
}
