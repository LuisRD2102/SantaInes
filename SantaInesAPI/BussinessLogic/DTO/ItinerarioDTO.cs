using SantaInesAPI.Persistence.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace SantaInesAPI.BussinessLogic.DTO
{
    public class ItinerarioDTO
    {
        public Guid id { get; set; }
        public DateTime hora_inicio { get; set; }
        public DateTime hora_fin { get; set; }

    }
}
