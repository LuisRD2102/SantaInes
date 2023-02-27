using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Text.Json.Serialization;

namespace SantaInesAPI.Persistence.Entity
{
    public class Parroquia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_parroquia { get; set; }
        public int id_municipio { get; set; }
        public virtual Municipio Municipio { get; set; }
        public string parroquia { get; set; }
        public virtual List<Direccion> Direccion { get; set; }

    }
}
