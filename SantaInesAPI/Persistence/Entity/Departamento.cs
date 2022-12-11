namespace SantaInesAPI.Persistence.Entity
{
    public class Departamento
    {
        public Guid id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public virtual List<Usuario> usuarios { get; set; }
    }
}
