using SantaInesAPI.BussinessLogic.DTO;
using SantaInesAPI.Persistence.Entity;

namespace SantaInesAPI.Persistence.DAO.Interface
{
    public interface IDepartamentoDAO
    {
        public List<DepartamentoDTO> ConsultarDepartamentoDAO();
        public Task<IEnumerable<Departamento>> ConsultarDepartamentoDP();
        public DepartamentoDTO AgregarDepartamentoDAO(Departamento departamento);
        public DepartamentoDTO ActualizarDepartamentoDAO(Departamento departamento);
        public DepartamentoDTO EliminarDepartamentoDAO(Guid id);
        public DepartamentoDTO ConsultarPorID(Guid id);
    }
}
