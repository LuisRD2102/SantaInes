using System.ComponentModel.DataAnnotations;

namespace SantaInesAPI.Persistence.Entity
{
    public class Direccion
    {
        [Key]
        public Guid id { get; set; }
        public string estado { get; set; }
        public string municipio { get; set; }
        public string calle { get; set; }
        public string edif_casa { get; set; }
        public string num_casa_apto { get; set; }
        public int cod_postal { get; set; }

        public virtual List<Usuario> usuarios { get; set; }
    }
}
