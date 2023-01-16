﻿using Newtonsoft.Json;
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



    }
}