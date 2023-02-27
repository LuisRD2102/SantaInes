using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace SantaInesWEB.Models
{
	public class UsuarioModel
	{
		[Required(ErrorMessage = "Introduzca su cédula")]
		[Range(1000000,99999999, ErrorMessage = "Cédula inválida")]
		public int cedula { get; set; }

		[Required(ErrorMessage = "Introduzca un usuario")]
		[StringLength(30, MinimumLength = 5, ErrorMessage = "El usuario debe de tener entre 5 a 30 caracteres")]
		public string username { get; set; }

		[Required(ErrorMessage = "Introduzca contraseña")]
		[StringLength(int.MaxValue,MinimumLength = 5, ErrorMessage = "La contraseña debe de tener al menos 5 caracteres")]
		public string password { get; set; }

		[Required(ErrorMessage = "Repita la contraseña")]
		[Compare("password", ErrorMessage = "Las contraseñas no coinciden")]
		public string password2 { get; set; }		

		[Required(ErrorMessage = "Introduzca sus nombre(s)")]
		public string nombre_Completo { get; set; }

		[Required(ErrorMessage = "Introduzca sus apellido(s)")]
		public string apellido_Completo { get; set; }

		[Required(ErrorMessage = "Introduzca su fecha de nacimiento")]
		[DataType(DataType.Date)]
		public DateTime fecha_Nacimiento { get; set; }

		[Required(ErrorMessage = "Seleccione su sexo")]
		public string sexo { get; set; }

		[Required(ErrorMessage = "Introduzca teléfono")]
		public string telefono { get; set; }

		[Required(ErrorMessage = "Introduzca un correo")]
		[EmailAddress(ErrorMessage = "Introduzca un correo válido")]
		public string email { get; set; }
        public Guid id_direccion { get; set; }
        public List<UsuarioModel> usuarios { get; set; }
        public Guid idHistoria { get; set; }

    }
}
