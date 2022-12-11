using SantaInesAPI.BussinessLogic.DTO;
using SantaInesAPI.Persistence.Entity;

namespace SantaInesAPI.BussinessLogic.Mapper
{
    public class DepartamentoMapper
    {
        public static DepartamentoDTO EntityToDTO(Departamento d)
        {
            return new DepartamentoDTO()
            {
                id = Guid.NewGuid(),
                nombre = d.nombre,
                descripcion = d.descripcion
                
            };
        }

        public static Departamento DtoToEntity(DepartamentoDTO d)
        {
            return new Departamento()
            {
                id = Guid.NewGuid(),
                nombre = d.nombre,
                descripcion = d.descripcion
                
            };
        }

        public static Departamento DtoToEntity_Update(DepartamentoDTO d)
        {
            return new Departamento()
            {
                id = d.id,
                nombre = d.nombre,
                descripcion = d.descripcion

            };
        }
    }
}
