using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Configuration;

namespace Amazonia.DAL.Utils.Tests
{
    [TestClass()]
    public class AcessoAppConfigTests
    {
        [TestMethod()]
        public void ObterValorDoConfigTest()
        {
            //Arrange
            var diasString = ConfigurationManager.AppSettings["diasLancamento"];
            var diasInteiro = Convert.ToInt32(ConfigurationManager.AppSettings["diasLancamento"]);
            var diasDecimal = Convert.ToDecimal(ConfigurationManager.AppSettings["diasLancamento"]);

            //Act

            //Assert
            Assert.AreEqual(diasString, "31");
            Assert.AreEqual(diasInteiro, 31);
            Assert.AreEqual(diasDecimal, 31M);
        }
    }
}