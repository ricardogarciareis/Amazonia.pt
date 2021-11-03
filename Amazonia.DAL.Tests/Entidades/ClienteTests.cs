using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Amazonia.DAL.Entidades.Tests
{
    [TestClass()]
    public class ClienteTests  //Classe criada a partir do botão direito no método NifEstaValido() da classe Cliente (Create Unit Tests)
    {
        [TestMethod()]
        public void NifEstaInvalidoTest()
        {
            //Arrange
            var cliente = new Cliente();
            cliente.NumeroIdentificacaoFiscal = "269234951";
            
            //Act
            var nifInvalido = !cliente.NifEstaValido();

            //Assert
            Assert.IsTrue(nifInvalido);
        }

        [TestMethod()]
        public void NifEstaValidoTest()
        {
            //Arrange
            var cliente = new Cliente();
            cliente.NumeroIdentificacaoFiscal = "269234950";

            //Act
            var nifValido = cliente.NifEstaValido();

            //Assert
            Assert.IsTrue(nifValido);
        }

        [TestMethod()]
        public void DeveInvalidarNifMaiorDoQue9Digitos()
        {
            //Arrange
            var cliente = new Cliente();
            cliente.NumeroIdentificacaoFiscal = "2692349500";
            
            //Act
            var nifInvalido = !cliente.NifEstaValido();

            //Assert
            Assert.IsTrue(nifInvalido);
        }

        [TestMethod()]
        public void DeveInvalidarNifMenorDoQue9Digitos()
        {
            //Arrange
            var cliente = new Cliente();
            cliente.NumeroIdentificacaoFiscal = "26923495";

            //Act
            var nifInvalido = !cliente.NifEstaValido();

            //Assert
            Assert.IsTrue(nifInvalido);
        }

        [TestMethod()]
        public void DeveInvalidarNifNumerosIguais()
        {
            //Arrange
            var cliente = new Cliente();
            cliente.NumeroIdentificacaoFiscal = "111111111";

            //Act
            var nifInvalido = !cliente.NifEstaValido();

            //Assert
            Assert.IsTrue(nifInvalido);
        }


    }
}

//TDD Cycle
//Test
//Driven
//Development
//https://pt.wikipedia.org/wiki/Test-driven_development
//Primeiro faz um teste falhar, depois corrige (fazendo-o funcionar), por fim melhora o teste
//1 - Escrever um teste que vai falhar
//2 - Escrever apenas o suficiente para que o teste passe
//3 - Melhorar o código sem alterar o seu comportamento
//Voltar ao 1