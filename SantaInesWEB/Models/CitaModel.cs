using System.ComponentModel.DataAnnotations;

namespace SantaInesWEB.Models
{
	public class CitaModel
    {
        public Guid id { get; set; }
        public DateTime fecha_hora { get; set; }
        public string paciente { get; set; }
        public string doctor { get; set; }
    }
}
