using SantaInesAPI.BussinessLogic.DTO;
using SantaInesAPI.BussinessLogic.Mapper;
using SantaInesAPI.Migrations;
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
                        username = u.username,
                        password = u.password,
                        cedula = u.cedula,
                        nombre_completo = u.nombre_completo,
                        apellido_completo = u.apellido_completo,
                        fecha_Nacimiento = u.fecha_nacimiento,
                        sexo = u.sexo,
                        telefono = u.telefono,
                        email = u.email,
                        id_direccion=u.id_direccion
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
                if (!(ExisteCedula(usuario))) {
                    _context.Usuario.Add(usuario);
                    _context.SaveChanges();
                }               

                var data = _context.Usuario.Where(u => u.username == usuario.username)
                            .Select(u => new UsuarioDTO
                            {
                                username = u.username,
                                password = u.password,
                                cedula = u.cedula,
                                nombre_completo = u.nombre_completo,
                                apellido_completo = u.apellido_completo,
                                fecha_Nacimiento = u.fecha_nacimiento,
                                sexo = u.sexo,
                                telefono = u.telefono,
                                email = u.email,
                                id_direccion = u.id_direccion
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
                        username = u.username,
                        password = u.password,
                        cedula = u.cedula,
                        nombre_completo = u.nombre_completo,
                        apellido_completo = u.apellido_completo,
                        fecha_Nacimiento = u.fecha_nacimiento,
                        sexo = u.sexo,
                        telefono = u.telefono,
                        email = u.email,
                        id_direccion = u.id_direccion
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

                Guid idDireccion = usuario.id_direccion;
                _context.Usuario.Remove(usuario);
                _context.SaveChanges();

                var direccionAsoc = _context.Direccion
                .Where(d => d.id == idDireccion).First();
                _context.Direccion.Remove(direccionAsoc);
                _context.SaveChanges();

                return UsuarioMapper.EntityToDTO(usuario);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " || " + ex.StackTrace);
                throw new Exception("Fallo al Eliminar por usuario: " + username, ex);
            }
        }

        public bool ExisteCedula(Usuario usuario)
        {
            bool existe = false;

            try
            {
                var nuevoUsuario = _context.Usuario.Where(d => d.cedula.Equals(usuario.cedula));
                if (nuevoUsuario.Count() != 0)
                    existe = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " || " + ex.StackTrace);
                throw new Exception("Usuario no encontrado: " + usuario, ex);
            }
            return existe;
        }

        public UsuarioDTO VerificarDatosLogin(string username, string pass)
        {
            try
            {
                var user = _context.Usuario.Where(u => u.username == username && u.password == pass).First();
                return UsuarioMapper.EntityToDTO(user);
            }
            catch (Exception ex)
            {
				Console.WriteLine(ex.Message + " || " + ex.StackTrace);
				throw new Exception("Usuario o contraseña incorrectos", ex);
			}
        }
    }
}
