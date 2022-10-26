using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SantaInesAPI.BussinessLogic.DTO
{
    public class UsuarioDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int Cedula { get; set; }
        public string Nombre_Completo { get; set; }
        public string Apellido_Completo { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public string Sexo { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public Guid Id_direccion { get; set; }
    }
}
