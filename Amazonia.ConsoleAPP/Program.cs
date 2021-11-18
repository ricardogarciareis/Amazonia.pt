using System;
using System.Configuration;
using Amazonia.DAL.Modelo;
using Amazonia.DAL.Repositorios;

namespace Amazonia.ConsoleAPP
{
    class Program
    {
        static void Main(string[] args)
        {
            var ctx = new AmazoniaContexto();
            ctx.Clientes.Add(new Cliente
            {
                UserName = "joao.silva",
                DataNascimento = new DateTime(1984, 05, 29),
                Nome = "João da Silva",
                NumeroIdentificacaoFiscal = "123456789",
                Password = "senha"
            });
            ctx.SaveChanges();


            //var chaveExemploDireto = ConfigurationManager.AppSettings["chaveExemplo"]       Opção 1
            //Console.WriteLine(chaveExemploDireto)
            //var valorObtidoPeloMetodo = AcessoAppConfig.ObterValorDoConfig("chaveExemplo")  Opção 2
            //Console.WriteLine(valorObtidoPeloMetodo)


            var usarRegranovaStr = ConfigurationManager.AppSettings["regraNovaAtiva"];
            var usarRegraNova = Convert.ToBoolean(usarRegranovaStr);
            if(usarRegraNova){
                ListarClientes();
            }
            else
            {
                ListarLivros();
            }

        }

        public static void ListarLivros()
        {
            Console.WriteLine("+------------------------------------------------------------------+");
            Console.WriteLine("|              CONSULTA DA BASE DE DADOS DOS LIVROS                |");
            Console.WriteLine("+------------------------------------------------------------------+");
            var repo = new RepositorioLivro();

            var listaLivros = repo.ObterTodos();

            foreach (var item in listaLivros){
                Console.WriteLine(item);
            }
        }

        public static void ListarClientes()
        {
            Console.WriteLine("+------------------------------------------------------------------+");
            Console.WriteLine("|             CONSULTA DA BASE DE DADOS DOS CLIENTES               |");
            Console.WriteLine("+------------------------------------------------------------------+");

            var repo = new RepositorioCliente();

            var listaClientes = repo.ObterTodos();
            
            foreach (var item in listaClientes){
                Console.WriteLine(item);
            }

        }
    }
}
