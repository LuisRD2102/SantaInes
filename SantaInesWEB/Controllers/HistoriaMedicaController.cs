using Microsoft.AspNetCore.Mvc;
using SantaInesAPI.Persistence.Entity;
using SantaInesWEB.Models;
using SantaInesWEB.Servicios.ServicioHistoriaMedica;
using SantaInesWEB.Servicios.ServicioUsuario;
using SantaInesWEB.Servicios.ServicioDireccion;

namespace SantaInesWEB.Controllers
{
    public class HistoriaMedicaController : Controller
    {
        private readonly IServicioHistoriaMedica _servicioHM;
        private readonly IServicioUsuario _servicioUsuario;
        private readonly IServicioDireccion _servicioApiDireccion;

        public HistoriaMedicaController(IServicioHistoriaMedica servicioHM, IServicioUsuario servicioUsuario, IServicioDireccion servicioDireccion)
        {
            _servicioHM = servicioHM;
            _servicioUsuario = servicioUsuario;
            _servicioApiDireccion = servicioDireccion;
        }
        public async Task<IActionResult> EditarHistoriaMedica(string username)
        {
            try
            {
                UsuarioModel usuario = new UsuarioModel();
                HistoriaMedicaModel historia = new HistoriaMedicaModel();
                DireccionModel direccion = new DireccionModel();

                usuario = await _servicioUsuario.MostrarInfoUsuario(username);
                historia = await _servicioHM.MostrarInfoHM(usuario.idHistoria);
                direccion = await _servicioApiDireccion.MostrarInfoDireccion(usuario.id_direccion);

                var tupla = new Tuple<UsuarioModel, DireccionModel , HistoriaMedicaModel>(usuario, direccion, historia);
                return View(tupla);
            }
            catch (Exception ex)
            {
                throw ex.InnerException!;
            }
        }

    }
}
