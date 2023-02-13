using SantaInesAPI.BussinessLogic.DTO;

namespace SantaInesAPI.Persistence.DAO.Interface
{
    public interface IDashboardDAO
    {
        public DashboardDTO GraficaGenero(int mes);
        public DashboardDTO GraficaDepartamentoPorCitas(int mes);
        public DashboardDTO GraficaTopDoctores(int mes);
        public DashboardDTO GraficaPacientesRangoEdad();
        public DashboardNumberDTO CantidadCitasPendientes(int mes);
        public DashboardNumberDTO CantidadCitasConfirmadas(int mes);
        public DashboardNumberDTO CantidadPacientes();
        public DashboardNumberDTO CantidadDoctores();
    }
}
