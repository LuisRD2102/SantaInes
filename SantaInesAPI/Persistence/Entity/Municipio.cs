using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Text.Json.Serialization;

namespace SantaInesAPI.Persistence.Entity
{
    public class Municipio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_municipio { get; set; }
        public int id_estado { get; set; }
        public virtual Estado Estado { get; set; }
        public string municipio { get; set; }
        public virtual List<Parroquia> Parroquias { get; set; }
        public virtual List<Direccion> Direccion { get; set; }

    }
}
