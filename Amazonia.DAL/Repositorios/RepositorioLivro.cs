using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazonia.DAL;
using Amazonia.DAL.Entidades;

namespace Amazonia.DAL.Repositorios
{
    public class RepositorioLivro : IRepositorio<Livro>
    {
        private List<Livro> ListaLivros;
        public RepositorioLivro()
        {
            ListaLivros = new List<Livro>();
            
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
            ListaLivros.Remove(obj);
        }

    }
}