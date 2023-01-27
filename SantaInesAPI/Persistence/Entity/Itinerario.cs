using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SantaInesAPI.Persistence.Entity
{
    public class Itinerario
    {
        [Key]
        public Guid id { get; set; }
        public string hora_inicio { get; set; }
        public string hora_fin { get; set; }
        public Empleado Empleado { get; set; }

    }
}
