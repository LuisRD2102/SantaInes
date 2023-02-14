using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Text.Json.Serialization;

namespace SantaInesAPI.Persistence.Entity
{
    public class Usuario
    {
        [Key]
        public string username { get; set; }
        public string password { get; set; }
        public int cedula { get; set; }
        public string nombre_completo { get; set; }
        public string apellido_completo { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public string sexo { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public Guid id_direccion { get; set; }
        public virtual Direccion Direccion { get; set; }
        public virtual List<Cita> Citas { get; set; }
        public Guid idHistoria { get; set; }
        public virtual HistoriaMedica HistoriaMedica { get; set; }

        [JsonPropertyName("edadPaciente")]
        [NotMapped]
        public int edad { get {
                DateTime now = DateTime.Today;
                int age = now.Year - fecha_nacimiento.Year;
                if (now < fecha_nacimiento.AddYears(age))
                    age--;
                return age;
            } }

    }
}
