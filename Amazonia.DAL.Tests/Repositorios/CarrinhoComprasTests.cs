using Microsoft.VisualStudio.TestTools.UnitTesting;
using Amazonia.DAL.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazonia.DAL.Entidades;

namespace Amazonia.DAL.Repositorios.Tests
{
    [TestClass()]
    public class CarrinhoComprasTests
    {
        [TestMethod()]
        public void CalcularPrecoCarrinhoLivrosImpressosTest()
        {
            //Arrange
            var livrosFake = new List<Livro>();
            livrosFake.Add(new LivroImpresso { Preco = 10, Nome = "Impresso 01" });
            livrosFake.Add(new LivroImpresso { Preco = 20, Nome = "Impresso 02" });
            livrosFake.Add(new LivroImpresso { Preco = 30, Nome = "Impresso 03" });

            var clienteFake = new Cliente();
            var carrinho = new CarrinhoCompras();

            var valorEsperado = 60M;

            //Act
            carrinho.Cliente = clienteFake;
            carrinho.Livros = livrosFake;
            var valorObtido = carrinho.CalcularPreco();

            //Assert           
            Assert.AreEqual(valorEsperado, valorObtido);
        }

        [TestMethod()]
        public void CalcularPrecoCarrinhoLivrosDigitaisTest()
        {
            //Arrange
            var livrosFake = new List<Livro>();
            livrosFake.Add(new LivroDigital { Preco = 10, Nome = "Digital 01" });
            livrosFake.Add(new LivroDigital { Preco = 20, Nome = "Digital 02" });
            livrosFake.Add(new LivroDigital { Preco = 30, Nome = "Digital 03" });

            var clienteFake = new Cliente();
            var carrinho = new CarrinhoCompras();

            var valorEsperado = 54M;

            //Act
            carrinho.Cliente = clienteFake;
            carrinho.Livros = livrosFake;
            var valorObtido = carrinho.CalcularPreco();

            //Assert           
            Assert.AreEqual(valorEsperado, valorObtido);
        }

        [TestMethod()]
        public void CalcularPrecoCarrinhoLivrosDigitaisEImpressosTest()
        {
            //Arrange
            var livrosFake = new List<Livro>();
            livrosFake.Add(new LivroDigital { Preco = 10, Nome = "Digital 01" });
            livrosFake.Add(new LivroDigital { Preco = 20, Nome = "Digital 02" });
            livrosFake.Add(new LivroDigital { Preco = 30, Nome = "Digital 03" });
            livrosFake.Add(new LivroImpresso { Preco = 10, Nome = "Impresso 01" });
            livrosFake.Add(new LivroImpresso { Preco = 20, Nome = "Impresso 02" });
            livrosFake.Add(new LivroImpresso { Preco = 30, Nome = "Impresso 03" });

            var clienteFake = new Cliente();
            var carrinho = new CarrinhoCompras();

            var valorEsperado = 114M; //54 + 60 = 114

            //Act
            carrinho.Cliente = clienteFake;
            carrinho.Livros = livrosFake;
            var valorObtido = carrinho.CalcularPreco();

            //Assert           
            Assert.AreEqual(valorEsperado, valorObtido);
        }

        [TestMethod()]
        public void AplicarDescontoTest()
        {
            //Arrange
            var livrosFake = new List<Livro>();
            livrosFake.Add(new LivroImpresso { Preco = 10, Nome = "Impresso 01" });
            livrosFake.Add(new LivroImpresso { Preco = 20, Nome = "Impresso 02" });
            livrosFake.Add(new LivroImpresso { Preco = 30, Nome = "Impresso 03" });

            var clienteFake = new Cliente();
            var carrinho = new CarrinhoCompras();

            var valorEsperado = 30M;
            var valorDesconto = 50;
            carrinho.Livros = livrosFake;

            //Act
            var valorObtidoAposDesconto = carrinho.AplicarDesconto(valorDesconto);

            //Assert           
            Assert.AreEqual(valorEsperado, valorObtidoAposDesconto);
        }

        [TestMethod()]
        public void CalcularPrecoCarrinhoLivrosPeriodicos()
        {
            //Arrange
            var livrosFake = new List<Livro>();
            livrosFake.Add(new LivroPeriodico { Preco = 10, 
                                                Nome = "Periódico 01",
                                                DataLancamento = Convert.ToDateTime("2021-09-30") });
            var clienteFake = new Cliente();
            var carrinho = new CarrinhoCompras();
            var valorEsperado = 5M;

            //Act
            carrinho.Cliente = clienteFake;
            carrinho.Livros = livrosFake;
            var valorObtido = carrinho.CalcularPreco();

            //Assert           
            Assert.AreEqual(valorEsperado, valorObtido);
        }
    }
}