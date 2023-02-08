using Microsoft.AspNetCore.Mvc;
using SantaInesWEB.Models;
using SantaInesWEB.Servicios.ServicioDepartamento;
using SantaInesWEB.Servicios.ServicioUsuario;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SantaInesWEB.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IServicioUsuario _servicioApiUsuario;

        public UsuariosController(IServicioUsuario servicioApiUsuario)
        {
            _servicioApiUsuario = servicioApiUsuario;
        }

        public async Task<IActionResult> GestionUsuarios()
        {
            try
            {
                return View(await _servicioApiUsuario.MostrarTabla());

                //List<UsuarioModel> listUsuarios = new List<UsuarioModel>();
                //HttpClient client = new HttpClient();
                //var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7270/Usuario/ConsultaUsuarios");
                //var _client = await client.SendAsync(request);
                //if (_client.IsSuccessStatusCode)
                //{
                //    var responseStream = await _client.Content.ReadAsStreamAsync();
                //    listUsuarios = await JsonSerializer.DeserializeAsync<List<UsuarioModel>>(responseStream);
                //}
                //return View(listUsuarios);
            }
            catch (Exception ex)
            {
                throw ex.InnerException!;
            }
        }
    }
}
