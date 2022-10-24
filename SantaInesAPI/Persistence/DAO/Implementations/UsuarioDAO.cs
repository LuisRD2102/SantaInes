using SantaInesAPI.BussinessLogic.DTO;
using SantaInesAPI.BussinessLogic.Mapper;
using SantaInesAPI.Persistence.DAO.Interface;
using SantaInesAPI.Persistence.Database;
using SantaInesAPI.Persistence.Entity;

namespace SantaInesAPI.Persistence.DAO.Implementations
{
    public class UsuarioDAO : IUsuarioDAO
    {
        private readonly MigrationDbContext _context;

        public UsuarioDAO(MigrationDbContext context)
        {
            _context = context;
        }

        public UsuarioDTO ActualizarUsuarioDAO(Usuario usuario)
        {
            try
            {
                _context.Usuario.Update(usuario);
                _context.SaveChanges();

                var data = _context.Usuario.Where(u => u.username == usuario.username).Select(
                    u => new UsuarioDTO
                    {
                        Username = u.username,
                        Password = u.password,
                        Cedula = u.cedula,
                        Nombre_Completo = u.nombre_completo,
                        Apellido_Completo = u.apellido_completo,
                        Fecha_Nacimiento = u.fecha_nacimiento,
                        Sexo = u.sexo,
                        Telefono = u.telefono,
                        Email = u.email
                    }
                );
                return data.First();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " || " + ex.StackTrace);
                throw new Exception("Fallo al actualizar: " + usuario.username, ex);
            }
        }

        public UsuarioDTO AgregarUsuarioDAO(Usuario usuario)
        {
            try
            {
                _context.Usuario.Add(usuario);
                _context.SaveChanges();

                var data = _context.Usuario.Where(u => u.username == usuario.username)
                            .Select(u => new UsuarioDTO
                            {
                                Username = u.username,
                                Password = u.password,
                                Cedula = u.cedula,
                                Nombre_Completo = u.nombre_completo,
                                Apellido_Completo = u.apellido_completo,
                                Fecha_Nacimiento = u.fecha_nacimiento,
                                Sexo = u.sexo,
                                Telefono = u.telefono,
                                Email = u.email
                            });

                return data.First();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " : " + ex.StackTrace);
                throw ex.InnerException!;
            }
        }

        public List<UsuarioDTO> ConsultarUsuarioDAO()
        {
            try
            {
                var lista = _context.Usuario.Select(
                    u => new UsuarioDTO
                    {
                        Username = u.username,
                        Password = u.password,
                        Cedula = u.cedula,
                        Nombre_Completo = u.nombre_completo,
                        Apellido_Completo = u.apellido_completo,
                        Fecha_Nacimiento = u.fecha_nacimiento,
                        Sexo = u.sexo,
                        Telefono = u.telefono,
                        Email = u.email
                    }
                );

                return lista.ToList();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " : " + ex.StackTrace);
                throw ex.InnerException!;
            }
        }

        public UsuarioDTO EliminarUsuarioDAO(String username)
        {
            try
            {
                var usuario = _context.Usuario
                .Where(u => u.username == username).First();

                _context.Usuario.Remove(usuario);
                _context.SaveChanges();

                return UsuarioMapper.EntityToDTO(usuario);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " || " + ex.StackTrace);
                throw new Exception("Fallo al Eliminar por usuario: " + username, ex);
            }
        }
    }
}
