using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace SantaInesAPI.Persistence.Entity
{
    public class Empleado
    {
        [Key]
        [JsonPropertyName("id")]
        public string username { get; set; }
        public string password { get; set; }
        public int cedula { get; set; }
        public string sexo { get; set; }
        [JsonPropertyName("name")]
        public string nombre_completo { get; set; }
        public string apellido_completo { get; set; }
        public string rol { get; set; }
        public Guid? id_departamento { get; set; }
        [NotMapped]
        public virtual Departamento Departamento { get; set; }
        [NotMapped]
        public virtual List<Cita> Citas { get; set; }
    }
}
