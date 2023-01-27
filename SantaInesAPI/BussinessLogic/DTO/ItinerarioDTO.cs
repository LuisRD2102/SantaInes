using SantaInesAPI.Persistence.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SantaInesAPI.BussinessLogic.DTO
{
    public class ItinerarioDTO
    {
        public Guid id { get; set; }
        public string hora_inicio { get; set; }
        public string hora_fin { get; set; }

    }
}
