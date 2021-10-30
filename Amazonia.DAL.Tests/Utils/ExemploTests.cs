using Microsoft.VisualStudio.TestTools.UnitTesting;
using Amazonia.DAL.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazonia.DAL.Utils.Tests
{
    [TestClass()]
    public class ExemploTests
    {
        [TestMethod()]
        public void ObterValorDoConfigTest()
        {
            //Arrange
            var valorEsperado = "batatas... do app.config do DAL.tests";

            //Act
            var valorObtidoPeloMetodo = Exemplo.ObterValorDoConfig("chaveExemplo");

            //Assert
            Assert.AreEqual(valorEsperado, valorObtidoPeloMetodo);
        }
    }
}