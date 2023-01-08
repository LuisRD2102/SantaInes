using Microsoft.AspNetCore.Mvc;
using SantaInesWEB.Models;
using System.Reflection.PortableExecutable;
using System.Text.Json;

namespace SantaInesWEB.Controllers
{
    public class RegistroController : Controller
    {
        public IActionResult Registro()
        {
            return View();
        }

        public async Task<IActionResult> RegistroExitoso([Bind(Prefix = "Item1")] UsuarioModel user, [Bind(Prefix = "Item2")] DireccionModel dir)
        {
            try
            {
                var id = Guid.NewGuid();
                dir.id = id;
                user.id_direccion = id;
                HttpClient client = new HttpClient();
                var _direccion = await client.PostAsJsonAsync<DireccionModel>("https://localhost:7270/Direccion/CrearDireccion", dir);
                var _client = await client.PostAsJsonAsync<UsuarioModel>("https://localhost:7270/Usuario/CrearUsuario", user);
                return View("Registro");
            }
            catch (Exception ex)
            {
                throw ex.InnerException!;
            }
        }
    }
}
