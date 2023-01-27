using SantaInesAPI.BussinessLogic.DTO;
using SantaInesAPI.Persistence.Entity;

namespace SantaInesAPI.BussinessLogic.Mapper
{
    public class CitaMapper
    {
        public static CitaDTO EntityToDTO(Cita c)
        {
            return new CitaDTO()
            {
                id = c.id,
                doctor= c.doctor,
                fecha_hora= c.fecha_hora,
                id_departamento= c.id_departamento,
                paciente = c.paciente   
            };
        }

        public static Cita DtoToEntity(CitaDTO c)
        {
            return new Cita()
            {
                id = c.id,
                doctor = c.doctor,
                fecha_hora = c.fecha_hora,
                id_departamento = c.id_departamento,
                paciente = c.paciente
            };
        }

    }
}
