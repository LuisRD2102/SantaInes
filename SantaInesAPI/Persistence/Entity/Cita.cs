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

        public string? patient { get; set; }

        public virtual Usuario? Usuario { get; set; }

        public string? doctor { get; set; }

        public virtual Empleado Empleado { get; set; }

        [NotMapped]
        public string Resource { get { return Empleado.username; } }

        [JsonPropertyName("text")]
        [NotMapped]
        public string? infoCita { get { return Usuario!=null ? "Cita: "+ Status + "<br/>" + "Paciente: " +Usuario?.nombre_completo.Split(' ').First() + " " + Usuario?.apellido_completo.Split(' ').First() + "<br/>" + "C.I: " + Usuario?.cedula : "Libre"; } }
        
        [JsonPropertyName("pacienteNombre")]
        [NotMapped]
        public string? pacienteNombre { get { return Usuario != null ? Usuario?.nombre_completo + " " + Usuario?.apellido_completo : null; } }

        [NotMapped]
        public string DoctorName { get { return (Empleado.sexo.ToUpper() == "M" ? "Dr. " : "Dra. ") + Empleado.nombre_completo.Split(' ').First() + ' ' + Empleado.apellido_completo.Split(' ').First();} }

    }
}
