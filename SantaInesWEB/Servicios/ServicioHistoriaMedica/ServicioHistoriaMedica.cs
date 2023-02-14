using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using SantaInesWEB.Models;
using System.Net.Http;

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
        public async Task<UsuarioModel> MostrarInfoHM(Guid id)
        {
            UsuarioModel historiaMedica = new UsuarioModel(); //Cambiar modelo

            var cliente = _httpClientFactory.CreateClient("DevConnection");

            try
            {
                var response = await cliente.GetAsync($"HistoriaMedica/ConsultarUsuarioPorUsername/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var respuesta = await response.Content.ReadAsStringAsync();
                    JObject json_respuesta = JObject.Parse(respuesta);

                    string stringDataRespuesta = json_respuesta["data"].ToString();
                    var resultado = JsonConvert.DeserializeObject<UsuarioModel>(stringDataRespuesta);
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
