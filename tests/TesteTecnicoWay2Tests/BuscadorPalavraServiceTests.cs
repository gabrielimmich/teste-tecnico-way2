using System;
using TesteTecnicoWay2Console.Services;
using Xunit;

namespace TesteTecnicoWay2Tests
{
    public class BuscadorPalavraServiceTests
    {
        [Theory]
        [InlineData("Assuero", 109)]
        [InlineData("Baruque", 140)]
        [InlineData("Catarina", 212)]
        [InlineData("Dagoberto", 248)]
        [InlineData("Dido", 277)]
        [InlineData("El�gio", 325)]
        [InlineData("Ester", 362)]
        [InlineData("Lisandro", 499)]
        [InlineData("Desd�mona", 272)]
        public void DeveBuscarPalavrasExistentes(string palavra, int indiceAssert)
        {
            var buscadorService = new BuscadorPalavraService(new ApiServiceMock(), palavra, 10);

            var (indice, _) = buscadorService.Buscar();

            Assert.Equal(indiceAssert, indice);
        }

        [Theory]
        [InlineData("Cristina2", -1)]
        public void DeveRetornarMenos1EmPalavrasInexistentes(string palavra, int indiceAssert)
        {
            var buscadorService = new BuscadorPalavraService(new ApiServiceMock(), palavra, 10);

            var (indice, _) = buscadorService.Buscar();

            Assert.Equal(indiceAssert, indice);
        }

        [Theory]
        [InlineData("David", 14)]
        [InlineData("Desd�mona", 14)]
        [InlineData("doze", 17)]
        [InlineData("Baleares", 6)]
        [InlineData("En�ias", 8)]
        public void DeveRetornarNumeroPandasMortos(string palavra, int quantidadePandasMortos)
        {
            var buscadorService = new BuscadorPalavraService(new ApiServiceMock(), palavra, 10);

            var (_, totalPandasMortos) = buscadorService.Buscar();

            Assert.Equal(quantidadePandasMortos, totalPandasMortos);
        }
    }
}
