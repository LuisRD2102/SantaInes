using SantaInesAPI.BussinessLogic.DTO;
using SantaInesAPI.Persistence.Entity;

namespace SantaInesAPI.Persistence.DAO.Interface
{
    public interface IUsuarioDAO
    {
        public List<UsuarioDTO> ConsultarUsuarioDAO(string? rol,string? username);
        public UsuarioDTO AgregarUsuarioDAO(Usuario usuario);
        public UsuarioDTO ActualizarUsuarioDAO(Usuario usuario);
        public UsuarioDTO EliminarUsuarioDAO(String usuario);
        public UsuarioDTO ConsultarPorUsername(string username);
        public UsuarioDTO VerificarDatosLogin(string username, string pass);
    }
}
