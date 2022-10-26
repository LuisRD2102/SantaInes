using SantaInesAPI.BussinessLogic.DTO;
using SantaInesAPI.Persistence.Entity;

namespace SantaInesAPI.BussinessLogic.Mapper
{
    public class UsuarioMapper
    {
        public static UsuarioDTO EntityToDTO(Usuario u)
        {
            return new UsuarioDTO()
            {
                Username = u.username,
                Password = u.password,
                Cedula = u.cedula,
                Nombre_Completo = u.nombre_completo,
                Apellido_Completo = u.apellido_completo,
                Fecha_Nacimiento = u.fecha_nacimiento,
                Sexo = u.sexo,
                Telefono = u.telefono,
                Email = u.email,
                Id_direccion = u.id_direccion
            };
        }

        public static Usuario DtoToEntity(UsuarioDTO u)
        {
            return new Usuario()
            {
                username = u.Username,
                password = u.Password,
                cedula = u.Cedula,
                nombre_completo = u.Nombre_Completo,
                apellido_completo = u.Apellido_Completo,
                fecha_nacimiento = u.Fecha_Nacimiento,
                sexo = u.Sexo,
                telefono = u.Telefono,
                email = u.Email,
                id_direccion = u.Id_direccion
            };
        }

    }
}
