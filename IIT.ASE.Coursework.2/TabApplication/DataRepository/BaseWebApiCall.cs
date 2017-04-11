using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace TabApplication.DataRepository
{
    public class BaseWebApiCall
    {
        //create the HttpClient object. When API Url changes only need to change here
        public HttpClient CreateHttpClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://iitstagecraftremotewebapi.azurewebsites.net"); //http://localhost:35903
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }    
    }
    
}
