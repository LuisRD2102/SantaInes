using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
}
}
