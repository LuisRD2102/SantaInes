using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace SantaInesWEB.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Introduzca un usuario")]
        [StringLength(10,MinimumLength =5,ErrorMessage ="El usuario debe de tener entre 5 a 10 caracteres")]
        public string username { get; set; }


        [Required(ErrorMessage = "Introduzca contraseña")]
        public string password { get; set; }


        [Required(ErrorMessage = "Repita la contraseña")]
        [Compare("password", ErrorMessage ="Las contraseñas no coinciden")]
        public string password2 { get; set; }


        [Required(ErrorMessage = "Introduzca su cédula")]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "La cédula debe contener 8 dígitos")]
        public int cedula { get; set; }


        [Required(ErrorMessage = "Introduzca sus nombre(s)")]
        public string nombre_Completo { get; set; }


        [Required(ErrorMessage = "Introduzca sus apellido(s)")]
        public string apellido_Completo { get; set; }


        [Required(ErrorMessage = "Introduzca su fecha de nacimiento")]
        public SqlDateTime fecha_Nacimiento { get; set; }


        [Required(ErrorMessage = "Introduzca su género")]
        [RegularExpression("[MF]", ErrorMessage = "Seleccione M o F")]
        public string sexo { get; set; }


        [Required(ErrorMessage = "Introduzca teléfono")]
        public string telefono { get; set; }



        [Required(ErrorMessage = "Introduzca un correo")]
        [EmailAddress(ErrorMessage ="Introduzca un correo válido")]
        public string email { get; set; }

    }
}
