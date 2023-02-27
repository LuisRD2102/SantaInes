using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Text.Json.Serialization;

namespace SantaInesAPI.Persistence.Entity
{
    public class Estado
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_estado { get; set; }
        public string estado { get; set; }
        public virtual List<Municipio> Municipios { get; set; }
        public virtual List<Direccion> Direccion { get; set; }
    }
}
