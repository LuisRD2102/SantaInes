using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SantaInesAPI.Persistence.Entity;
using SantaInesWEB.Models;
using System.Text;

namespace SantaInesWEB.Servicios.ServicioDepartamento
{
    public class ServicioDepartamento : IServicioDepartamento
    {
        private JObject _json_respuesta;
        private readonly IHttpClientFactory _httpClientFactory;

        public ServicioDepartamento(IHttpClientFactory _httpClientFactory)
        {
            this._httpClientFactory = _httpClientFactory;
        }

        public async Task<List<DepartamentoModel>> MostrarTabla()
        {
            DepartamentoModel departamento = new DepartamentoModel();

            var cliente = _httpClientFactory.CreateClient("DevConnection");

            try
            {
                var responseDept = await cliente.GetAsync("Departamento/ConsultaDepartamentos/");

                if (responseDept.IsSuccessStatusCode)
                {
                    var respuestaDept = await responseDept.Content.ReadAsStringAsync();
                    JObject json_respuestaDept = JObject.Parse(respuestaDept);

                    string stringDataRespuestaDept = json_respuestaDept["data"].ToString();
                    var resultadoDept = JsonConvert.DeserializeObject<List<DepartamentoModel>>(stringDataRespuestaDept);
                    departamento.departamentos = resultadoDept;
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
            return departamento.departamentos;

        }

        public async Task<JObject> RegistrarDepartamento(DepartamentoModel dept)
        {
            var cliente = _httpClientFactory.CreateClient("DevConnection");

            var content = new StringContent(JsonConvert.SerializeObject(dept), Encoding.UTF8, "application/json");

            try
            {
                var response = await cliente.PostAsync("Departamento/CrearDepartamento/", content);
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

        public async Task<JObject> EditarDepartamento(DepartamentoModel dept)
        {
            var cliente = _httpClientFactory.CreateClient("DevConnection");

            var content = new StringContent(JsonConvert.SerializeObject(dept), Encoding.UTF8, "application/json");

            try
            {
                var response = await cliente.PutAsync("Departamento/ActualizarDepartamento", content);
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

        public async Task<DepartamentoModel> MostrarInfoDepartamento(Guid id)
        {
            DepartamentoModel departamento = new DepartamentoModel();

            var cliente = _httpClientFactory.CreateClient("DevConnection");

            try
            {
                var responseDept = await cliente.GetAsync($"Departamento/ConsultarDepartamentoPorID/{id}");

                if (responseDept.IsSuccessStatusCode)
                {
                    var respuestaDept = await responseDept.Content.ReadAsStringAsync();
                    JObject json_respuestaDept = JObject.Parse(respuestaDept);

                    string stringDataRespuestaDept = json_respuestaDept["data"].ToString();
                    var resultadoDept = JsonConvert.DeserializeObject<DepartamentoModel>(stringDataRespuestaDept);
                    departamento = resultadoDept;
                }
            }
            catch (Exception ex)
            {
                throw ex.InnerException!;
            }
            return departamento;
        }

        public async Task<JObject> EliminarDepartamento(Guid id)
        {
            var cliente = _httpClientFactory.CreateClient("DevConnection");
            var response = await cliente.DeleteAsync($"Departamento/EliminarDepartamento/{id}");

            var respuesta = await response.Content.ReadAsStringAsync();
            JObject json_respuesta = JObject.Parse(respuesta);

            return json_respuesta;
        }



    }
}
