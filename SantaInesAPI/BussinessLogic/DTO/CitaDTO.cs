using SantaInesAPI.Persistence.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SantaInesAPI.BussinessLogic.DTO
{
    public class CitaDTO
    {
        public Guid id { get; set; }
        public DateTime fecha_hora { get; set; }
        public string paciente { get; set; }
        public string doctor { get; set; }
        public Guid id_departamento { get; set; }

    }
}
