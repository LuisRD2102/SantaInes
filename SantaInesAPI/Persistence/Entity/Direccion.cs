using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SantaInesAPI.Persistence.Entity
{
    public class Direccion
    {
        [Key]
        public Guid id { get; set; }
        public int? id_estado { get; set; }
        public virtual Estado? Estado { get; set; }
        public int? id_municipio { get; set; }
        public virtual Municipio? Municipio { get; set; }
        public int? id_parroquia { get; set; }
        public virtual Parroquia? Parroquia { get; set; }
        public string direccion { get; set; }   
        public Usuario Usuario { get; set; }

        [NotMapped]
        public string? nb_estado { get { return Estado?.estado; } }
        [NotMapped]
        public string? nb_municipio { get { return Municipio?.municipio; } }
        [NotMapped]
        public string? nb_parroquia { get { return Parroquia?.parroquia; } }
    }
}
