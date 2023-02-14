using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Text.Json.Serialization;

namespace SantaInesAPI.Persistence.Entity
{
    public class HistoriaMedica
    {
        [Key]
        public Guid idHistoria { get; set; }
        public float? peso { get; set; }
        public float? altura { get; set; }
        public string? tipoSangre { get; set; }
        public string? antPeronales { get; set; }
        public string? andtFamiliares { get; set; }
        public string? alergias { get; set; }
        public string? tratHabitual { get; set; }
        public string? intQuirurgica { get; set; }
        public string? patologia { get; set; }
        public Usuario Usuario { get; set; }
    }
}
