using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SantaInesAPI.Persistence.Entity
{
    public class Cita
    {
        [Key]
        public Guid id { get; set; }
        public DateTime fecha_hora { get; set; }
        public string paciente { get; set; }
        public virtual Usuario Usuario { get; set; }
        public string doctor { get; set; }
        public virtual Empleado Empleado { get; set; }
        public Guid id_departamento { get; set; }
        public virtual Departamento Departamento { get; set; }  

    }
}
