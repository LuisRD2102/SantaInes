using System.ComponentModel.DataAnnotations;

namespace SantaInesWEB.Models
{
	public class DireccionModel
	{
        public Guid id { get; set; }

		[Required(ErrorMessage = "Introduzca el municipio")]
		public string municipio { get; set; }

		[Required(ErrorMessage = "Introduzca la dirección")]
		public string direccion { get; set; }

    }
}
