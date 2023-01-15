namespace SantaInesWEB.Models
{
    public class DepartamentoModel
    {
        public Guid id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public List<DepartamentoModel> departamentos { get; set; }
    }
}
