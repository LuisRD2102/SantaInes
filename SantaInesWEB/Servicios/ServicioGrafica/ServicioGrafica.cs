using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SantaInesWEB.Models;
using System.Net.Http;

namespace SantaInesWEB.Servicios.ServicioGrafica
{
    public class ServicioGrafica : IServicioGrafica
    {
        private JObject _json_respuesta;
        private readonly IHttpClientFactory _httpClientFactory;

        public ServicioGrafica(IHttpClientFactory _httpClientFactory)
        {
            this._httpClientFactory = _httpClientFactory;
        }

        public async Task<GraphModel> GraficaGenero()
        {
            GraphModel graph = new GraphModel();

            var cliente = _httpClientFactory.CreateClient("DevConnection");

            try
            {
                var response = await cliente.GetAsync("Dashboard/GetGraficaGenero/");

                if (response.IsSuccessStatusCode)
                {
                    var respuesta = await response.Content.ReadAsStringAsync();
                    JObject json_respuestaUsuario = JObject.Parse(respuesta);

                    string stringDataRespuesta = json_respuestaUsuario["data"].ToString();
                    var resultado = JsonConvert.DeserializeObject<GraphModel>(stringDataRespuesta);
                    graph = resultado;
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
            return graph;
        }
    }
}
