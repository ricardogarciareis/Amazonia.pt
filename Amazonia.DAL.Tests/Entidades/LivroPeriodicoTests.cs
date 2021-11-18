using Amazonia.DAL.Modelo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Amazonia.DAL.Entidades.Tests
{
    [TestClass()]
    public class LivroPeriodicoTests
    {
        [TestMethod()]
        public void DeveObterParametrosPorConfiguracaoForaDoPeriodoDeDescontosTest()
        {
            //Arrange
            var livroExemplo = new LivroPeriodico   //Para ficar neste formato cliquei no new e na lâmpada
            {
                Preco = 100,
                DataLancamento = DateTime.Today
            };

            //Act
            //var precoObtido = livroExemplo.ObterPreco();

            //Assert
            //Assert.AreEqual(precoObtido, 100);
        }

        [TestMethod()]
        public void DeveObterParametrosPorConfiguracaoParaPrimeiroPeriodoDeDescontosTest()
        {
            //Arrange
            var livroExemplo = new LivroPeriodico
            {
                Preco = 100,
                DataLancamento = DateTime.Today.AddDays(-31)
            };

            //Act
            //var precoObtido = livroExemplo.ObterPreco();

            //Assert
            //Assert.AreEqual(precoObtido, 90);
        }

        [TestMethod()]
        public void DeveObterParametrosPorConfiguracaoParaSegundoPeriodoDeDescontosTest()
        {
            //Arrange
            var livroExemplo = new LivroPeriodico
            {
                Preco = 100,
                DataLancamento = DateTime.Today.AddDays(-60)
            };

            //Act
            //var precoObtido = livroExemplo.ObterPreco();

            //Assert
            //Assert.AreEqual(precoObtido, 80);
        }
    }
}