using System;

namespace TesteTecnicoWay2Console.Services
{
    public class BuscadorPalavraService
    {
        private readonly IApiService _apiService;
        private readonly string _palavra;
        private readonly int _indiceMaximoInicial;

        private int _totalPandasMortos = 0;

        public BuscadorPalavraService(IApiService apiService, string palavra, int indiceMaximoInicial)
        {
            _apiService = apiService;

            _palavra = palavra;
            _indiceMaximoInicial = indiceMaximoInicial;
        }

        private int CompararPalavra(string palavraApi)
        {
            return string.Compare(_palavra, palavraApi, StringComparison.Ordinal);
        }

        private (int Minimo, int Maximo) EncontrarRange(int min, int max)
        {
            var palavraApi = _apiService.BuscarPalavraPorIndice(max);

            _totalPandasMortos++;

            if (CompararPalavra(palavraApi) == 0)
            {
                return (-1, max);
            }

            if (!string.IsNullOrEmpty(palavraApi) && CompararPalavra(palavraApi) > 0)
            {
                var proximaBusca = min == 0 ? max + max : min + max;

                return EncontrarRange(max, proximaBusca);
            }

            return (min, max);
        }

        private int AplicarBuscaBinaria(int indiceMinimo, int indiceMaximo)
        {
            if (indiceMinimo >= (indiceMaximo - 1))
                return -1;

            var indiceMedio = (indiceMinimo + indiceMaximo) / 2;

            var palavraApi = _apiService.BuscarPalavraPorIndice(indiceMedio);
            _totalPandasMortos++;

            var comparacaoPalavra = !string.IsNullOrEmpty(palavraApi)
                ? CompararPalavra(palavraApi)
                : -1;

            if (comparacaoPalavra < 0)
                return AplicarBuscaBinaria(indiceMinimo, indiceMedio);

            if (comparacaoPalavra > 0)
                return AplicarBuscaBinaria(indiceMedio, indiceMaximo);

            return indiceMedio;
        }

        public (int Indice, int PandasMortos) Buscar()
        {
            var (Minimo, Maximo) = EncontrarRange(0, _indiceMaximoInicial);

            if (Minimo == -1)
            {
                return (Maximo, _totalPandasMortos);
            }

            return (AplicarBuscaBinaria(Minimo, Maximo), _totalPandasMortos);
        }
    }
}
