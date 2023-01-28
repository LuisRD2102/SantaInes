using System.ComponentModel.DataAnnotations;

namespace SantaInesWEB.Models
{
    public class EmpleadoModel
    {
        [Required(ErrorMessage = "Introduzca un usuario")]
        [StringLength(10, MinimumLength = 5, ErrorMessage = "El usuario debe de tener entre 5 a 10 caracteres")]
        public string username { get; set; }


        [Required(ErrorMessage = "Introduzca contraseña")]
        public string password { get; set; }


        [Required(ErrorMessage = "Introduzca su cédula")]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "La cédula debe contener 8 dígitos")]
        public int cedula { get; set; }


        [Required(ErrorMessage = "Introduzca sus nombre(s)")]
        public string nombre_completo { get; set; }


        [Required(ErrorMessage = "Introduzca sus apellido(s)")]
        public string apellido_completo { get; set; }


        [Required(ErrorMessage = "Seleccione el rol")]
        public string rol { get; set; }


        public List<EmpleadoModel> empleados { get; set; }
    }
}
