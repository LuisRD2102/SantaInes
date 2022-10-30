using Microsoft.AspNetCore.Mvc;
using SantaInesWEB.DTO;
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

        public async Task<IActionResult> RegistroExitoso(UsuarioDTO user)
        {
            try
            {
                //cambiar, EL GUID SE GENERARA AUTOMATICO
                user.id_direccion = Guid.Parse("9b0ef5e7-d35f-477c-9c16-446b028d70f4");
                HttpClient client = new HttpClient();
                var _client = await client.PostAsJsonAsync<UsuarioDTO>("https://localhost:7270/Usuario/CrearUsuario", user);
                return View("Registro");
            }
            catch (Exception ex)
            {
                throw ex.InnerException!;
            }
        }
    }
}
