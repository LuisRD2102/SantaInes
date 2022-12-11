using System.ComponentModel.DataAnnotations;

namespace SantaInesWEB.Models
{
	public class UsuarioModel
	{
        [Required(ErrorMessage = "Introduzca un usuario")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "El nombre debe de tener entre 5 a 30 caracteres")]
        public string username { get; set; }
        public string password { get; set; }
        public int cedula { get; set; }
        public string nombre_Completo { get; set; }
        public string apellido_Completo { get; set; }
        public DateTime fecha_Nacimiento { get; set; }
        public string sexo { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public Guid id_direccion { get; set; }
    }
}
