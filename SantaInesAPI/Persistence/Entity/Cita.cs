using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SantaInesAPI.Persistence.Entity
{
    public class Cita
    {
        [Key]
        public Guid id { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public string Status { get; set; } = "Libre";

        [JsonPropertyName("patient")]
        public string? paciente { get; set; }

        public virtual Usuario? Usuario { get; set; }

        public string? doctor { get; set; }

        public virtual Empleado Empleado { get; set; }

        [NotMapped]
        public string Resource { get { return Empleado.username; } }

        //VER CUAL SERÁ EL TEXTO QUE SE MUESTRA
        [JsonPropertyName("text")]
        [NotMapped]
        public string? pacienteNombre { get; set; }

        [NotMapped]
        public string DoctorName { get { return (Empleado.sexo.ToUpper() == "M" ? "Dr. " : "Dra. ") + Empleado.nombre_completo.Split(' ').First() + ' ' + Empleado.apellido_completo.Split(' ').First();} }

    }
}
