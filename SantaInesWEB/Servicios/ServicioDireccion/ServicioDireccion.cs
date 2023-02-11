using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SantaInesAPI.Persistence.Entity;
using SantaInesWEB.Models;
using System.Text;

namespace SantaInesWEB.Servicios.ServicioDireccion
{
    public class ServicioDireccion : IServicioDireccion
    {
        private JObject _json_respuesta;
        private readonly IHttpClientFactory _httpClientFactory;

        public ServicioDireccion(IHttpClientFactory _httpClientFactory)
        {
            this._httpClientFactory = _httpClientFactory;
        }

        public async Task<JObject> RegistrarDireccion(DireccionModel direccion)
        {
            var cliente = _httpClientFactory.CreateClient("DevConnection");

            var content = new StringContent(JsonConvert.SerializeObject(direccion), Encoding.UTF8, "application/json");

            try
            {
                var response = await cliente.PostAsync("Direccion/CrearDireccion/", content);
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

        public async Task<DireccionModel> MostrarInfoDireccion(Guid id)
        {
            DireccionModel direccion = new DireccionModel();

            var cliente = _httpClientFactory.CreateClient("DevConnection");

            try
            {
                var responseDireccion = await cliente.GetAsync($"Direccion/ConsultarDireccionPorID/{id}");

                if (responseDireccion.IsSuccessStatusCode)
                {
                    var respuestaDireccion = await responseDireccion.Content.ReadAsStringAsync();
                    JObject json_respuestaDireccion = JObject.Parse(respuestaDireccion);

                    string stringDataRespuestaDireccion = json_respuestaDireccion["data"].ToString();
                    var resultadoDireccion = JsonConvert.DeserializeObject<DireccionModel>(stringDataRespuestaDireccion);
                    direccion = resultadoDireccion;
                }
            }
            catch (Exception ex)
            {
                throw ex.InnerException!;
            }
            return direccion;
        }

        public async Task<JObject> EditarDireccion(DireccionModel direccion)
        {
            var cliente = _httpClientFactory.CreateClient("DevConnection");

            var content = new StringContent(JsonConvert.SerializeObject(direccion), Encoding.UTF8, "application/json");

            try
            {
                var response = await cliente.PutAsync("Direccion/ActualizarDireccion", content);
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
