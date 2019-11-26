using System;
using TesteTecnicoWay2Console.Services;

namespace TesteTecnicoWay2Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("-> Escolha uma palavra: ");
            var palavra = Console.ReadLine();

            while (!string.IsNullOrEmpty(palavra))
            {
                Console.WriteLine($"Buscando o índice da palavra \"{palavra}\"...");

                var buscadorPalavraService = new BuscadorPalavraService(new ApiService(), palavra, 1000);

                var (indice, totalDePandasMortos) = buscadorPalavraService.Buscar();

                Console.WriteLine($"* O índice da palavra \"{palavra}\" é: {indice}");
                Console.WriteLine($"* O total de pandas mortos para a palavra \"{palavra}\" é: {totalDePandasMortos}\n");

                Console.Write("-> Escolha uma palavra: ");
                palavra = Console.ReadLine();
            }
        }
    }
}
