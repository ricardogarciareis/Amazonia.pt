using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Amazonia.DAL.Entidades;
using Amazonia.DAL.Desconto;
using System.Configuration;

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



        //------------------------- TESTES PARA UTILIZAÇÃO DO APP.CONFIG -------------------------
        //02/11/2021 f1
        [TestMethod()]
        public void DeveCalcularPrecoCarrinhoLivrosPeriodicosForaPeriodoDeDescontos()
        {
            //Arrange
            var livrosFake = new List<Livro>();
            livrosFake.Add(new LivroPeriodico
            {
                Preco = 10,
                Nome = "Periódico 01",
                DataLancamento = DateTime.Today.AddDays(-30)
            });
            var clienteFake = new Cliente();
            var carrinho = new CarrinhoCompras();
            var valorEsperado = 10M;

            //Act
            carrinho.Cliente = clienteFake;
            carrinho.Livros = livrosFake;
            var valorObtido = carrinho.CalcularPreco();

            //Assert           
            Assert.AreEqual(valorEsperado, valorObtido);
        }

        [TestMethod()]
        public void DeveCalcularPrecoCarrinhoLivrosPeriodicosParaPrimeiroPeriodoDeDescontos()
        {
            //Arrange
            var livrosFake = new List<Livro>();
            livrosFake.Add(new LivroPeriodico
            {
                Preco = 10,
                Nome = "Periódico 01",
                DataLancamento = DateTime.Today.AddDays(-31)
            });
            var clienteFake = new Cliente();
            var carrinho = new CarrinhoCompras();
            var valorEsperado = 9M;

            //Act
            carrinho.Cliente = clienteFake;
            carrinho.Livros = livrosFake;
            var valorObtido = carrinho.CalcularPreco();

            //Assert           
            Assert.AreEqual(valorEsperado, valorObtido);
        }

        [TestMethod()]
        public void DeveCalcularPrecoCarrinhoLivrosPeriodicosParaSegundoPeriodoDeDescontos()
        {
            //Arrange
            var livrosFake = new List<Livro>();
            livrosFake.Add(new LivroPeriodico
            {
                Preco = 10,
                Nome = "Periódico 01",
                DataLancamento = DateTime.Today.AddDays(-60)
            });
            var clienteFake = new Cliente();
            var carrinho = new CarrinhoCompras();
            var valorEsperado = 8M;

            //Act
            carrinho.Cliente = clienteFake;
            carrinho.Livros = livrosFake;
            var valorObtido = carrinho.CalcularPreco();

            //Assert           
            Assert.AreEqual(valorEsperado, valorObtido);
        }



        //----------------- TESTES PARA INTRODUÇÃO À INJEÇÃO DE DEPENDÊNCIA ---------------------

        [TestMethod()]
        [Ignore] //Atenção ao Ignore (a substituição do método AplicarDesconto() no ICarrinhoCompras e CarrinhoCompras invalidou este teste)
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
            //var valorDesconto = 50;
            carrinho.Livros = livrosFake;

            //Act
            var valorObtidoAposDesconto = carrinho.AplicarDesconto(null); //valorDesconto

            //Assert           
            Assert.AreEqual(valorEsperado, valorObtidoAposDesconto);
        }


        //Testes da Injeção de Dependência 02/11/2021 37:40 f2:
        
        [TestMethod()]
        public void AplicarDescontoExemploDescontoPercentualTest()
        {
            //Arrange
            var livrosFake = new List<Livro>
            {
                new LivroImpresso { Preco = 60, Nome = "Impresso 01" },
                new LivroImpresso { Preco = 40, Nome = "Impresso 02" }
            };
            var carrinho = new CarrinhoCompras();
            carrinho.Livros = livrosFake;
            var valorEsperado = 80M;
            
            var desconto = new DescontoPercentual()   //Proveniente da Injeção de Dependência (var = IDesconto)
            {
                PercentualDesconto = 20
            };
            //Act
            var valorObtidoAposDesconto = carrinho.AplicarDesconto(desconto);

            //Assert           
            Assert.AreEqual(valorEsperado, valorObtidoAposDesconto);
        }
        
        [TestMethod()]
        public void AplicarDescontoExemploDescontoPercentualEDescontoCombinadoParaComparacaoTest()
        {
            //Arrange
            var livrosFake = new List<Livro>
            {
                new LivroImpresso { Preco = 60, Nome = "Impresso 01" },
                new LivroImpresso { Preco = 40, Nome = "Impresso 02" }
            };
            var carrinho = new CarrinhoCompras();
            carrinho.Livros = livrosFake;
            var valorEsperadoPercentual = 80M;
            var valorEsperadoCombinado = 100M;

            var descontoPercentual = new DescontoPercentual
            {
                PercentualDesconto = 20
            };
            //Act 1
            var valorObtidoDescontoPercentual = carrinho.AplicarDesconto(descontoPercentual);
            
            var descontoCombinado = new DescontoCombinado
            {
                PercentualDesconto = 20,
                LivrosNoCarrinho = livrosFake,
                QtdMinimaLivrosDigitais = 1,
                QtdMinimaLivrosImpressos = 2  //Só existem 2 livros impressos na lista, logo, o desconto combinado é 0%
            };
            //Act 2
            var valorObtidoDescontoCombinado = carrinho.AplicarDesconto(descontoCombinado);


            //Assert 1           
            Assert.AreEqual(valorEsperadoPercentual, valorObtidoDescontoPercentual);

            //Assert 2
            Assert.AreEqual(valorEsperadoCombinado, valorObtidoDescontoCombinado);
        }


        
        [TestMethod()]
        public void AplicarDescontoExemploDescontoPercentualEDescontoCombinadoComBaseNoConfigTest()
        {
            //Arrange
            var livrosFake = new List<Livro>
            {
                new LivroImpresso { Preco = 60, Nome = "Impresso 01" },
                new LivroImpresso { Preco = 40, Nome = "Impresso 02" },
                new LivroDigital { Preco = 100, Nome = "Digital 01" }
            };
            var carrinho = new CarrinhoCompras();
            carrinho.Livros = livrosFake;
            
            IDesconto desconto;

            //var condicao = false;     //INTRODUÇÃO À INVERSÃO DE DEPENDÊNCIA (DEPENDENCY INJECTION)
            var condicao = ConfigurationManager.AppSettings["RegraDescontoValida"] == "Percentual";
            if (condicao)                
            {
                desconto = new DescontoPercentual
                {
                    PercentualDesconto = 10
                };
            }
            else
            {
                desconto = new DescontoCombinado
                {
                    PercentualDesconto = 20,
                    LivrosNoCarrinho = livrosFake,
                    QtdMinimaLivrosDigitais = 1,
                    QtdMinimaLivrosImpressos = 2
                };
            }
            //Act
            var valorObtido = carrinho.AplicarDesconto(desconto);

            //Assert
            if (condicao)
            {
                Assert.AreEqual(171M, valorObtido);
            }
            else
            {
                Assert.AreEqual(152M, valorObtido);
            }
            
        }
        //------------------------------------------------------------------------------------------


    }
}