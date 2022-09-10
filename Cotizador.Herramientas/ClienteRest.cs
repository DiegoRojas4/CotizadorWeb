using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Cotizador.Herramientas
{
    public class ClienteRest
    {
        private string EndPointUrl;
        public ClienteRest(string endPoint)
        {
            EndPointUrl = endPoint;
        }
        public async Task<U> SimpleGet<U>()
        {
            try
            {
                var serviceResult = default(U);

                var client = new HttpClient();
                client.Timeout = new TimeSpan(hours: 0, minutes: 0, seconds: 60);
                HttpResponseMessage res = await client.GetAsync(EndPointUrl);

                string response = await res.Content.ReadAsStringAsync();

                if (res.IsSuccessStatusCode)
                {
                    serviceResult = JsonConvert.DeserializeObject<U>(response);
                }
                else
                {
                    throw new Exception(string.Concat("Resultado servicio, ", response));
                }

                return serviceResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<U> SimplePost<T, U>(T Request)
        {
            try
            {
                var serviceResult = default(U);

                using (var client = new HttpClient(new HttpClientHandler(), false))
                {
                    client.DefaultRequestHeaders.Clear();
                    client.Timeout = new TimeSpan(hours: 0, minutes: 1, seconds: 60);

                    HttpResponseMessage res = client.PostAsync(EndPointUrl, SerializeObjectToJson(Request)).Result;

                    string response = await res.Content.ReadAsStringAsync();

                    if (res.IsSuccessStatusCode)
                    {
                        serviceResult = JsonConvert.DeserializeObject<U>(response);
                    }
                    else
                    {
                        throw new Exception(string.Concat("Resultado servicio, ", response));
                    }
                }
                return serviceResult;
            }
            catch (TaskCanceledException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                if (ex is TaskCanceledException)
                {
                    if ((ex as TaskCanceledException).CancellationToken == null || (ex as TaskCanceledException).CancellationToken.IsCancellationRequested == false)
                    {
                        ex = new TimeoutException("Timeout occurred");
                    }
                }
                throw ex;
            }
        }

        private StringContent SerializeObjectToJson<T>(T properties)
        {
            var dataJson = JsonConvert.SerializeObject(properties);
            return new StringContent(dataJson, Encoding.UTF8, "application/json");
        }
    }
}
