using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazonia.DAL;
using Amazonia.DAL.Entidades;
using Amazonia.DAL.Infraestrutura;

namespace Amazonia.DAL.Repositorios
{
    public class RepositorioCliente : IRepositorio<Cliente>
    {
        private List<Cliente> ListaClientes;
        public RepositorioCliente()
        {
            ListaClientes = new List<Cliente>();
            var joao = new Cliente();
            joao.Nome = "Joao";
            joao.DataNascimento = new DateTime(1984,05,29);

            var maria = new Cliente{ Nome="Maria", DataNascimento= new DateTime(1950,01,01)};
            var marta = new Cliente{ Nome="Marta", DataNascimento= new DateTime(2021,01,02)};
            
            ListaClientes.Add(joao);
            ListaClientes.Add(maria);
            ListaClientes.Add(marta);
        }
        public void Criar(Cliente obj)
        {
            ListaClientes.Add(obj);
        }

        public Cliente ObterPorNome(string Nome)
        {
            var resultado = ListaClientes
                            .Where(x => x.Nome == Nome)
                            .OrderByDescending(x => x.Idade)
                            .FirstOrDefault();
            return resultado;
        }

        public List<Cliente> ObterTodos()
        {
            return ListaClientes;
        }

        public Cliente Atualizar(string nomeAntigo, string nomeNovo)
        {
            var clienteTemporario = ObterPorNome(nomeAntigo);
            clienteTemporario.Nome = nomeNovo;
            return clienteTemporario;
        }

        public void Apagar(Cliente obj)
        {
            ListaClientes.Remove(obj);
        }

        public void GerarRelatorio(IImpressora impressora)  //TODO: COmpletar a implementação do método Imprimir
        {
            impressora.Imprimir();
        }
    }
}