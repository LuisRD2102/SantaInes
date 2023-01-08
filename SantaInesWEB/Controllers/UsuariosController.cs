using Microsoft.AspNetCore.Mvc;
using SantaInesWEB.Models;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SantaInesWEB.Controllers
{
    public class UsuariosController : Controller
    {
        public async Task<IActionResult> GestionUsuarios()
        {
            try
            {
                List<UsuarioModel> listUsuarios = new List<UsuarioModel>();
                HttpClient client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7270/Usuario/ConsultaUsuarios");
                var _client = await client.SendAsync(request);
                if (_client.IsSuccessStatusCode)
                {
                    var responseStream = await _client.Content.ReadAsStreamAsync();
                    listUsuarios = await JsonSerializer.DeserializeAsync<List<UsuarioModel>>(responseStream);
                }
                return View(listUsuarios);
            }
            catch (Exception ex)
            {
                throw ex.InnerException!;
            }
        }
    }
}
