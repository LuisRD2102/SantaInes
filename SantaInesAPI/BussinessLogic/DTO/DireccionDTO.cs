using SantaInesAPI.Persistence.Entity;

namespace SantaInesAPI.BussinessLogic.DTO
{
    public class DireccionDTO
    {
        public Guid id { get; set; }
        public int? id_estado { get; set; }
        public int? id_municipio { get; set; }
        public int? id_parroquia { get; set; }
        public string direccion { get; set; }
        public string? nb_estado { get; set; }
        public string? nb_municipio { get; set; } 
        public string? nb_parroquia { get; set; }
    }
}
