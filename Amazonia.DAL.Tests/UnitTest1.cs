using Amazonia.DAL.Entidades;
using Amazonia.DAL.Repositorios;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Amazonia.DAL.Tests
{
    [TestClass]
    public class UnitTest1
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

    }
}
