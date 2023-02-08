using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SantaInesAPI.Persistence.Entity;
using SantaInesWEB.Models;
using SantaInesWEB.Servicios.ServicioUsuario;
using System.Text;

namespace SantaInesWEB.Servicios.ServicioUsuario
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

        public async Task<JObject> ValidarUsuarioLogin(string username, string password)
        {
            var cliente = _httpClientFactory.CreateClient("DevConnection");

            try
            {
                var response = await cliente.GetAsync($"Login/LoginUsuario/{username}/{password}");
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

        public async Task<List<UsuarioModel>> MostrarTabla()
        {
            UsuarioModel usuario = new UsuarioModel();

            var cliente = _httpClientFactory.CreateClient("DevConnection");

            try
            {
                var responseUsuario = await cliente.GetAsync("Usuario/ConsultaUsuarios/");

                if (responseUsuario.IsSuccessStatusCode)
                {
                    var respuestaUsuario = await responseUsuario.Content.ReadAsStringAsync();
                    JObject json_respuestaUsuario = JObject.Parse(respuestaUsuario);

                    string stringDataRespuestaUsuario = json_respuestaUsuario["data"].ToString();
                    var resultadoUsuario = JsonConvert.DeserializeObject<List<UsuarioModel>>(stringDataRespuestaUsuario);
                    usuario.usuarios = resultadoUsuario;
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"ERROR de conexión con la API: '{ex.Message}'");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return usuario.usuarios;

        }


    }
}
