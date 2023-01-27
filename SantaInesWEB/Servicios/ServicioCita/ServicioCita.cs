using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SantaInesAPI.Persistence.Entity;
using SantaInesWEB.Models;
using SantaInesWEB.Servicios.ServicioUsuario;
using System.Text;

namespace SantaInesWEB.Servicios.ServicioUsuario
{
    public class ServicioCita : IServicioCita
    {
        private JObject _json_respuesta;
        private readonly IHttpClientFactory _httpClientFactory;

        public ServicioCita(IHttpClientFactory _httpClientFactory)
        {
            this._httpClientFactory = _httpClientFactory;
        }

        public async Task<List<CitaModel>> MostrarCitas()
        {
            List<CitaModel> citas = new List<CitaModel>();

            var cliente = _httpClientFactory.CreateClient("DevConnection");

            try
            {
                var responseDept = await cliente.GetAsync("Citas/ConsultaCitas/");

                if (responseDept.IsSuccessStatusCode)
                {
                    var respuestaDept = await responseDept.Content.ReadAsStringAsync();
                    JObject json_respuestaDept = JObject.Parse(respuestaDept);

                    string stringDataRespuestaDept = json_respuestaDept["data"].ToString();
                    citas = JsonConvert.DeserializeObject<List<CitaModel>>(stringDataRespuestaDept);
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
            return citas;

        }


    }
}
