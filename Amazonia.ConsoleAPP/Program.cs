using System;
using System.Configuration;
using Amazonia.DAL;
using Amazonia.DAL.Repositorios;
using Amazonia.DAL.Utils;

namespace Amazonia.ConsoleAPP
{
    class Program
    {
        static void Main(string[] args)
        {
            var chaveExemplo = ConfigurationManager.AppSettings["chaveExemplo"];
            var valorObtidoPeloMetodo = Exemplo.ObterValorDoConfig("chaveExemplo");

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
