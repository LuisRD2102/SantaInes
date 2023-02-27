using System.ComponentModel.DataAnnotations;

namespace SantaInesWEB.Models
{
	public class DireccionModel
	{
        public Guid id { get; set; }
		[Required(ErrorMessage = "Seleccione el estado")]
		public int id_estado { get; set; }
		[Required(ErrorMessage = "Seleccione el municipio")]
		public int id_municipio { get; set; }
		[Required(ErrorMessage = "Seleccione la parroquia")]
		public int id_parroquia { get; set; }
		public string? direccion { get; set; }
        public string? nb_estado { get; set; }
        public string? nb_municipio { get; set; }
        public string? nb_parroquia { get; set; }

    }
}
