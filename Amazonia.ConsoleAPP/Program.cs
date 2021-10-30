using System;
using System.Configuration;
using Amazonia.DAL;
using Amazonia.DAL.Repositorios;

namespace Amazonia.ConsoleAPP
{
    class Program
    {
        static void Main(string[] args)
        {
            //ListarClientes();
            //ListarLivros();

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
            //var listaClientes = repo.ObterTodosQueComecemPor("J");
            //var listaClientes = repo.ObterTodosQueTenhamPeloMenos18Anos();
            //var listaClientes = repo.ObterNomeDeTodosQueTenhamPeloMenos18AnosENomeComecePor("M");
            
            foreach (var item in listaClientes){
                Console.WriteLine(item);
            }

            /*
            var joao = repo.ObterPorNome("Joao");
            Console.WriteLine($"Database contém {listaClientes.Count} clientes");

            repo.Apagar(joao);

            foreach (var item in listaClientes){
                Console.WriteLine(item);
            }
            Console.WriteLine($"Database contém {listaClientes.Count} clientes");


            var maria = repo.ObterPorNome("Maria");
            repo.Atualizar(maria.Nome, "Maria da Silva");

            foreach (var item in listaClientes){
                Console.WriteLine(item);
            }
            */

            // Console.WriteLine("Criação de novos clientes na DataBase");
            // do{
            //     var novoCliente = new Cliente();
            //     Console.Write("Informe o nome: ");
            //     novoCliente.Nome = Console.ReadLine();
            //     repo.Criar(novoCliente);
            //     Console.WriteLine($"{novoCliente.Nome} criado");
            // }while(Console.ReadKey().Key != ConsoleKey.Tab);

            // var listaClientesNovosEAntigos = repo.ObterTodos();
            // foreach (var item in listaClientesNovosEAntigos)
            // {
            //     Console.WriteLine(item);
            // }
        }
    }
}
