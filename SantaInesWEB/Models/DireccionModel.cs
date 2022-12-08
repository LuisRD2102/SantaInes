using System.ComponentModel.DataAnnotations;

namespace SantaInesWEB.Models
{
	public class DireccionModel
	{
        public Guid id { get; set; }

        public string estado { get; set; }
    
        public string municipio { get; set; }

        public string direccion { get; set; }

      
        public int cod_postal { get; set; }
    }
}
