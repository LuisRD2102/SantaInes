using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SantaInesAPI.Persistence.Entity;
using SantaInesWEB.Models;
using SantaInesWEB.Servicios.ServicioUsuario;
using System.Text;

namespace SantaInesWEB.Servicios.ServicioEmpleado
{
	public class ServicioEmpleado : IServicioEmpleado
	{
		private JObject _json_respuesta;
		private readonly IHttpClientFactory _httpClientFactory;

		public ServicioEmpleado(IHttpClientFactory _httpClientFactory)
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

        public async Task<JObject> ValidarEmpleadoLogin(string username, string password)
        {
            var cliente = _httpClientFactory.CreateClient("DevConnection");

            try
            {
                var response = await cliente.GetAsync($"Login/LoginEmpleado/{username}/{password}");
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

        public async Task<Tuple<List<EmpleadoModel>, List<DepartamentoModel>>> MostrarTabla()
        {
            var cliente = _httpClientFactory.CreateClient("DevConnection");

            List<DepartamentoModel> listaDepartamento = new List<DepartamentoModel>();
            List<EmpleadoModel> listaEmpleado = new List<EmpleadoModel>();

            try
            {
                var responseDept = await cliente.GetAsync("Departamento/ConsultaDepartamentos/");
                var responseEmpleado = await cliente.GetAsync("Empleado/ConsultaEmpleados/");

                if (responseDept.IsSuccessStatusCode && responseEmpleado.IsSuccessStatusCode)
                {
                    var respuestaDept = await responseDept.Content.ReadAsStringAsync();
                    JObject json_respuestaDept = JObject.Parse(respuestaDept);

                    var respuestaEmpleado = await responseEmpleado.Content.ReadAsStringAsync();
                    JObject json_respuestaEmpleado = JObject.Parse(respuestaEmpleado);


                    //Obtengo la data del json respuesta Departamento
                    string stringDataRespuestaDept = json_respuestaDept["data"].ToString();
                    var resultadoDept = JsonConvert.DeserializeObject<List<DepartamentoModel>>(stringDataRespuestaDept);

                    //Obtengo la data del json respuesta Empleado
                    string stringDataRespuestaEmpleado = json_respuestaEmpleado["data"].ToString();
                    var resultadoEmpleado = JsonConvert.DeserializeObject<List<EmpleadoModel>>(stringDataRespuestaEmpleado);


                    listaDepartamento = resultadoDept;
                    listaEmpleado = resultadoEmpleado;
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

            var tupla = new Tuple<List<EmpleadoModel>, List<DepartamentoModel>>(listaEmpleado, listaDepartamento);

            return tupla;

        }

        public async Task<JObject> RegistrarEmpleado(EmpleadoModel empleado)
        {
            var cliente = _httpClientFactory.CreateClient("DevConnection");

            var content = new StringContent(JsonConvert.SerializeObject(empleado), Encoding.UTF8, "application/json");
            
            try
            {
                var response = await cliente.PostAsync("Empleado/CrearEmpleado/", content);
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
