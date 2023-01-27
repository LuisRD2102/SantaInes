using SantaInesAPI.BussinessLogic.DTO;
using SantaInesAPI.Persistence.Entity;

namespace SantaInesAPI.BussinessLogic.Mapper
{
    public class EmpleadoMapper
    {
        public static EmpleadoDTO EntityToDTO(Empleado e)
        {
            return new EmpleadoDTO()
            {
                username = e.username,
                password = e.password,
                cedula = e.cedula,
                nombre_completo = e.nombre_completo,
                apellido_completo = e.apellido_completo,
                rol = e.rol,
                id_departamento = e.id_departamento,
                id_itinerario = e.id_itinerario
            };
        }

        public static Empleado DtoToEntity(EmpleadoDTO e)
        {
            return new Empleado()
            {
                username = e.username,
                password = e.password,
                cedula = e.cedula,
                nombre_completo = e.nombre_completo,
                apellido_completo = e.apellido_completo,
                rol = e.rol,
                id_departamento = e.id_departamento,
                id_itinerario = e.id_itinerario
            };
        }

    }
}
