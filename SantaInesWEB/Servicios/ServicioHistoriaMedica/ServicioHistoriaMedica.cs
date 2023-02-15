using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SantaInesWEB.Models;
using System.Text;

namespace SantaInesWEB.Servicios.ServicioHistoriaMedica
{
    public class ServicioHistoriaMedica : IServicioHistoriaMedica
    {
        private JObject _json_respuesta;
		private readonly IHttpClientFactory _httpClientFactory;

        public ServicioHistoriaMedica(IHttpClientFactory _httpClientFactory)
        {
            this._httpClientFactory = _httpClientFactory;
        }
        public async Task<HistoriaMedicaModel> MostrarInfoHM(Guid id)
        {
            HistoriaMedicaModel historiaMedica = new HistoriaMedicaModel();

            var cliente = _httpClientFactory.CreateClient("DevConnection");

            try
            {
                var response = await cliente.GetAsync($"HistoriaMedica/ConsultarHM/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var respuesta = await response.Content.ReadAsStringAsync();
                    JObject json_respuesta = JObject.Parse(respuesta);

                    string stringDataRespuesta = json_respuesta["data"].ToString();
                    var resultado = JsonConvert.DeserializeObject<HistoriaMedicaModel>(stringDataRespuesta);
                    historiaMedica = resultado;
                }
            }
            catch (Exception ex)
            {
                throw ex.InnerException!;
            }
            return historiaMedica;
        }

        public async Task<JObject> EditarHistoriaMedica(HistoriaMedicaModel historiaMedica)
        {
            var cliente = _httpClientFactory.CreateClient("DevConnection");

            var content = new StringContent(JsonConvert.SerializeObject(historiaMedica), Encoding.UTF8, "application/json");

            try
            {
                var response = await cliente.PutAsync("HistoriaMedica/ActualizarHistoriaMedica", content);
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
