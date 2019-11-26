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

        private (int Minimo, int Maximo) EncontrarRange()
        {
            var min = 0;
            var max = _indiceMaximoInicial;

            var palavraApi = _apiService.BuscarPalavraPorIndice(max);
            _totalPandasMortos++;

            while (CompararPalavra(palavraApi) > 0)
            {
                int temp = min == 0 ? max : min;
                min = max;
                max += temp;

                palavraApi = _apiService.BuscarPalavraPorIndice(max);
                _totalPandasMortos++;

                if (string.IsNullOrEmpty(palavraApi))
                {
                    break;
                }
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
            var (Minimo, Maximo) = EncontrarRange();

            return (AplicarBuscaBinaria(Minimo, Maximo), _totalPandasMortos);
        }
    }
}
