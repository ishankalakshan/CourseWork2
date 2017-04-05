using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace TabApplication.DataRepository
{
    public class BaseWebApiCall
    {
        public HttpClient CreateHttpClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:35903"); //http://iitstagecraftremotewebapi.azurewebsites.net
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }    
    }
    
}
