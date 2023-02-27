using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Text.Json.Serialization;

namespace SantaInesAPI.BussinessLogic.DTO
{
    public class EstadoDTO
    {
        public int id_estado { get; set; }
        public string estado { get; set; }
    }
}
