using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace TesteTecnicoWay2Console.Services
{
    public class ApiService : IApiService
    {
        private readonly RestClient _client;

        public ApiService()
        {
            _client = new RestClient("https://way2dictionary.azurewebsites.net/api");
        }

        public string BuscarPalavraPorIndice(int indice)
        {
            var request = new RestRequest("/values/{id}", Method.GET);
            request.AddUrlSegment("id", indice);

            var response = _client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                return null;
            }

            var content = JsonConvert.DeserializeObject<string>(response.Content);

            if (content == "oops ʕ•͡ᴥ•ʔ")
            {
                return null;
            }

            return content;
        }
    }
}
