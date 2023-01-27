using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SantaInesAPI.Persistence.Entity
{
    public class Direccion
    {
        [Key]
        public Guid id { get; set; }
        public string municipio { get; set; }
        public string direccion { get; set; }
        public int cod_postal { get; set; }        
        public Usuario Usuario { get; set; }
    }
}
