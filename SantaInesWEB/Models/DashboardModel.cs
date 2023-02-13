namespace SantaInesWEB.Models
{
    public class DashboardModel
    {
        public int? mes { get; set; }
        public GraphModel graficaGenero { get; set; }
        public GraphModel graficaTopDoctores { get; set; }
        public GraphModel graficaRangoEdad { get; set; }
        public GraphModel graficaDepartamentos { get; set; }
    }
}
