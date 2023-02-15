using System.ComponentModel.DataAnnotations;

namespace SantaInesWEB.Models
{
    public class HistoriaMedicaModel
    {
        public Guid idHistoria { get; set; }
        public float? peso { get; set; }
        [DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = true)]
        public float? altura { get; set; }
        public string? tipoSangre { get; set; }
        public string? antPeronales { get; set; }
        public string? antFamiliares { get; set; }
        public string? alergias { get; set; }
        public string? tratHabitual { get; set; }
        public string? intQuirurgica { get; set; }
        public string? patologia { get; set; }

    }
}
