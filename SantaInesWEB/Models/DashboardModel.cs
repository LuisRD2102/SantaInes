namespace SantaInesWEB.Models
{
    public class DashboardModel
    {
        public int? mes { get; set; }
        public GraphModel graficaGenero { get; set; }
        public GraphModel graficaTopDoctores { get; set; }
        public GraphModel graficaRangoEdad { get; set; }
        public GraphModel graficaDepartamentos { get; set; }
        public StatsModel CantidadCitasPendientes { get; set; }
        public StatsModel CantidadCitasConfirmadas { get; set; }
        public StatsModel CantidadPacientes { get; set; }
        public StatsModel CantidadDoctores { get; set; }
    }
}
