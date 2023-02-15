using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SantaInesWEB.Models;

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
    }
}
