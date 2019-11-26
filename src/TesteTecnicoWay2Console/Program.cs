using System;
using TesteTecnicoWay2Console.Services;

namespace TesteTecnicoWay2Console
{
    class Program
    {
        private static string LerPalavra()
        {
            Console.Write("-> Escolha uma palavra: ");

            return Console.ReadLine();
        }

        static void Main(string[] args)
        {
            var palavra = LerPalavra();

            while (!string.IsNullOrEmpty(palavra))
            {
                Console.WriteLine($"Buscando o índice da palavra \"{palavra}\"...");

                var buscadorPalavraService = new BuscadorPalavraService(new ApiService(), palavra, 1000);

                var (indice, totalDePandasMortos) = buscadorPalavraService.Buscar();

                if (indice >= 0)
                {
                    Console.WriteLine($"* O índice da palavra \"{palavra}\" é: {indice}.");
                }
                else
                {
                    Console.WriteLine($"* A palavra \"{palavra}\" não existe no dicionário.");
                }

                Console.WriteLine($"* O total de pandas mortos para a palavra \"{palavra}\" é: {totalDePandasMortos}\n");
                palavra = LerPalavra();
            }
        }
    }
}
