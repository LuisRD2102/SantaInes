using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SantaInesAPI.Persistence.Entity;
using SantaInesWEB.Models;
using SantaInesWEB.Servicios.ServicioRegistro;
using System.Text;

namespace SantaInesWEB.Servicios.ServicioRegistro
{
	public class ServicioUsuario : IServicioUsuario
	{
		private JObject _json_respuesta;
		private readonly IHttpClientFactory _httpClientFactory;

		public ServicioUsuario(IHttpClientFactory _httpClientFactory)
		{
			this._httpClientFactory = _httpClientFactory;
		}

		public async Task<JObject> RegistrarUsuario(UsuarioModel user)
		{
			var cliente = _httpClientFactory.CreateClient("DevConnection");

			var content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

			try
			{
				var response = await cliente.PostAsync("Usuario/CrearUsuario/", content);
				var respuesta = await response.Content.ReadAsStringAsync();
				JObject _json_respuesta = JObject.Parse(respuesta);

				return _json_respuesta;
			}
			catch (HttpRequestException ex)
			{
				Console.WriteLine($"ERROR de conexión con la API: '{ex.Message}'");
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}

			return _json_respuesta;

		}


	}
}
