using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SantaInesAPI.Persistence.Entity
{
    public class EmpleadoDTO
    {
        public string username { get; set; }
        public string password { get; set; }
        public int cedula { get; set; }
        public string sexo { get; set; }
        public string nombre_completo { get; set; }
        public string apellido_completo { get; set; }
        public string rol { get; set; }
        public Guid? id_departamento { get; set; }
        public Guid? id_itinerario { get; set; }
    }
}
