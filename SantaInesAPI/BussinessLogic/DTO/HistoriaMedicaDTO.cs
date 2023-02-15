using SantaInesAPI.Persistence.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace SantaInesAPI.BussinessLogic.DTO
{
    public class HistoriaMedicaDTO
    {
        public Guid idHistoria { get; set; }
        public float? peso { get; set; }
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
