using SantaInesWEB.Models;

namespace SantaInesWEB.Servicios.ServicioHistoriaMedica
{
    public interface IServicioHistoriaMedica
    {
        Task<HistoriaMedicaModel> MostrarInfoHM(Guid id);
    }
}
