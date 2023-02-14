using SantaInesWEB.Models;

namespace SantaInesWEB.Servicios.ServicioHistoriaMedica
{
    public interface IServicioHistoriaMedica
    {
        Task<UsuarioModel> MostrarInfoHM(Guid id);
    }
}
