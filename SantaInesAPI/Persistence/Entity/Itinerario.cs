using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace SantaInesAPI.Persistence.Entity
{
    public class Itinerario
    {
        [Key]
        public Guid id { get; set; }
        public DateTime hora_inicio { get; set; }
        public DateTime hora_fin { get; set; }
        public Empleado Empleado { get; set; }

    }
}
