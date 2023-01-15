namespace SantaInesWEB.Models
{
    public class EmpleadoModel
    {
        public string username { get; set; }
        public string password { get; set; }
        public int cedula { get; set; }
        public string nombre_completo { get; set; }
        public string apellido_completo { get; set; }
        public string rol { get; set; }
        public List<EmpleadoModel> empleados { get; set; }
    }
}
