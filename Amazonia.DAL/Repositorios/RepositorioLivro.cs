using System;
using System.Collections.Generic;
using System.Linq;
using Amazonia.DAL.Entidades;
using Amazonia.DAL.Infraestrutura;

namespace Amazonia.DAL.Repositorios
{
    public class RepositorioLivro : IRepositorio<Livro>
    {
        private readonly List<Livro> ListaLivros;
        public RepositorioLivro()
        {
            ListaLivros = new List<Livro>();

            var lotrImp = new LivroImpresso
            {
                Nome = "Harry Potter",
                Autor = "JK",
                QuantidadePaginas = 264
            }; 
            ListaLivros.Add(lotrImp);

            var lotrAud = new AudioLivro
            {
                Nome = "O Senhor dos Anéis",
                Autor = "J.R.R. Tolkien",
                DuracaoLivro = 6,
                FormatoFicheiro = "MP3"
            }; 
            ListaLivros.Add(lotrAud);

            var lotrEBook = new LivroDigital
            {
                Nome = "O Senhor dos Anéis",
                Autor = "J.R.R. Tolkien",
                InformacoesLicenca = "Gratuíta",
                TamanhoEmMB = 5,
                FormatoFicheiro = "pdf"
            };
            ListaLivros.Add(lotrEBook);

            var lotrPeriod = new LivroPeriodico
            {
                Nome = "Jornal O Dia",
                Autor = "Jornalista José Peixoto",
                DataLancamento = Convert.ToDateTime("2021-10-01")
            };
            ListaLivros.Add(lotrPeriod);    
        }
        public void Criar(Livro obj)
        {
            ListaLivros.Add(obj);
        }

        public Livro ObterPorNome(string Nome)
        {
            var resultado = ListaLivros
                            .Where(x => x.Nome == Nome)
                            .FirstOrDefault();
            return resultado;
        }

        public List<Livro> ObterTodos()
        {
            return ListaLivros;
        }

        public Livro Atualizar(string nomeAntigo, string nomeNovo)
        {
            var livroTemporario = ObterPorNome(nomeAntigo);
            livroTemporario.Nome = nomeNovo;
            return livroTemporario;
        }

        public void Apagar(Livro obj)
        {
            if(ListaLivros.Remove(obj) == false)
            {
                throw new AmazoniaException("Falha ao apagar Livro"); 
            }
                //ListaLivros.Remove(obj);
        }

    }
}