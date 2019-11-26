using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TesteTecnicoWay2Console.Services;

namespace TesteTecnicoWay2Tests
{
    public class ApiServiceMock : IApiService
    {
        private readonly Dictionary<int, string> _dicionario;

        public ApiServiceMock()
        {
            _dicionario = JsonConvert.DeserializeObject<IEnumerable<KeyValuePair<int, string>>>(File.ReadAllText(@"palavras.json"))
                .ToDictionary(x => x.Key, x => x.Value);
        }

        public string BuscarPalavraPorIndice(int indice)
        {
            return _dicionario.GetValueOrDefault(indice, null);
        }
    }
}
