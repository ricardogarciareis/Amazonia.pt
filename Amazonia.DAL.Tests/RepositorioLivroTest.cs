using Amazonia.DAL.Entidades;
using Amazonia.DAL.Infraestrutura;
using Amazonia.DAL.Repositorios;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Amazonia.DAL.Tests
{
    [TestClass]
    public class RepositorioLivroTest
    {
        [TestMethod]
        public void DeveCriarUmObjetoDoTipoRepositorioLivros()
        {
            //Arrange
            //var repositorio = new RepositorioLivro();
            RepositorioLivro repositorio;

            //Act
            repositorio = new RepositorioLivro();

            //Assert
            Assert.IsNotNull(repositorio);

        }

        [TestMethod]
        public void DeveCriarUmaListaDeLivrosNoRepositorioLivros()
        {
            //Arrange
            RepositorioLivro repositorio;
            List<Livro> livros;
            var minElementos = 1;

            //Act
            repositorio = new RepositorioLivro();
            livros = repositorio.ObterTodos();
            var quantidadeLIvrosNoRepositorio = livros.Count;

            //Assert
            Assert.IsNotNull(repositorio);
            Assert.IsNotNull(livros);
            Assert.IsTrue(quantidadeLIvrosNoRepositorio >= minElementos);
        }

        [Ignore] //TODO: modificar este teste quando a Action do GitHub estiver OK
        [TestMethod]
        public void DeveCriarUmaListaDeLivrosNoRepositorioLivrosComFalha()
        {
            //Arrange
            RepositorioLivro repositorio;
            List<Livro> livros;
            var quantidadeElementos = 4;

            //Act
            repositorio = new RepositorioLivro();
            livros = repositorio.ObterTodos();
            var quantidadeLIvrosNoRepositorio = livros.Count;

            //Assert
            Assert.IsNotNull(repositorio);
            Assert.IsNotNull(livros);
            //Assert.IsTrue(quantidadeLIvrosNoRepositorio == quantidadeElementos);
            Assert.AreEqual(quantidadeLIvrosNoRepositorio, quantidadeElementos);
        }

        [TestMethod]
        public void DeveApagarLivroDaLista()
        {
            //Arrange
            var repo = new RepositorioLivro();
            var livros = repo.ObterTodos();
            var livroAApagar = livros.FirstOrDefault();

            //Act
            var livrosInicialmente = livros.Count;
            repo.Apagar(livroAApagar);
            var livrosDepoisDeApagar = livros.Count;

            //Assert
            Assert.IsTrue(livrosInicialmente > livrosDepoisDeApagar);
        }

#if !DEBUG
        [Ignore]
#endif
        [TestMethod]
        [ExpectedException(typeof(AmazoniaException))]
        public void DeveGerarExceptionQuandoTentaApagarLivroInexistente()
        {
            //Arrange
            var repo = new RepositorioLivro();
            var livros = repo.ObterTodos();
            LivroDigital livroInexistente = new LivroDigital();

            //Act
            var livrosInicialmente = livros.Count;
            repo.Apagar(livroInexistente);
            var livrosDepoisDeApagar = livros.Count;

            //Assert
            Assert.IsTrue(livrosInicialmente > livrosDepoisDeApagar);
        }

    }
}
