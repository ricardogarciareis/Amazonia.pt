using System;
using System.Configuration;
using System.Linq;
using Amazonia.DAL.Modelo;
using Amazonia.DAL.Repositorios;
using Microsoft.EntityFrameworkCore;

namespace Amazonia.ConsoleAPP
{
    class Program
    {
        static void Main(string[] args)
        {
            var ctx = new AmazoniaContexto();


            //CREATE
            //AdicionarClienteExemplo(ctx);
            //AdicionarLivrosExemplo(ctx);


            //var chaveExemploDireto = ConfigurationManager.AppSettings["chaveExemplo"]       Opção 1
            //Console.WriteLine(chaveExemploDireto)
            //var valorObtidoPeloMetodo = AcessoAppConfig.ObterValorDoConfig("chaveExemplo")  Opção 2
            //Console.WriteLine(valorObtidoPeloMetodo)

            //ImprimirValorBaseadoEmConfiguracao();


            //READ
            //var livroEscolhido = ctx.Livros.FirstOrDefault(x => x.Nome.StartsWith("Harry"));
            //Console.WriteLine(livroEscolhido);

            //var primeiroLivroDigitalEncontrado = ctx.AudioLivros.FirstOrDefault(x => x.DuracaoLivroEmMinutos >= 10);
            //Console.WriteLine(primeiroLivroDigitalEncontrado);

            //UPDATE
            //primeiroLivroDigitalEncontrado.DuracaoLivroEmMinutos = 90;
            //ctx.SaveChanges();

            //DELETE
            //var primeiroLivroImpresso = ctx.LivrosImpressos.FirstOrDefault();
            //Console.WriteLine(primeiroLivroImpresso);
            //ctx.LivrosImpressos.Remove(primeiroLivroImpresso);
            //ctx.SaveChanges();

            //var primeiroCliente = ctx.Clientes.FirstOrDefault();
            //ctx.Clientes.Remove(primeiroCliente);
            //ctx.SaveChanges();


            var exemploLeituraComSQL = ctx.Livros.FromSqlRaw("SELECT TOP 10 * FROM LIVROS");
            
            foreach(var item in exemploLeituraComSQL)
            {
                Console.WriteLine(item.Id + " Nome: " + item.Nome);
            }
            

        }

        private static void ImprimirValorBaseadoEmConfiguracao()
        {
            var usarRegranovaStr = ConfigurationManager.AppSettings["regraNovaAtiva"];
            var usarRegraNova = Convert.ToBoolean(usarRegranovaStr);
            if (usarRegraNova)
            {
                ListarClientes();
            }
            else
            {
                ListarLivros();
            }
        }

        private static void AdicionarLivrosExemplo(AmazoniaContexto ctx)
        {
            var livroDigital = new LivroDigital
            {
                Nome = "Harry Potter Digital",
                Autor = "JK",
                Descricao = "Livro Harry Potter",
                FormatoFicheiro = "PDF",
                Idioma = DAL.Idioma.Portugues,
                InformacoesLicenca = "",
                Preco = 100,
                TamanhoEmMB = 10
            };

            var audioLivro = new AudioLivro
            {
                Nome = "Harry Potter Audio",
                Autor = "JK",
                Descricao = "Livro Harry Potter",
                FormatoFicheiro = "MP3",
                Idioma = DAL.Idioma.Portugues,
                Preco = 100,
                DuracaoLivroEmMinutos = 60
            };

            var livroImpresso = new LivroImpresso
            {
                Nome = "Harry Potter Impresso",
                Autor = "JK",
                Descricao = "Livro Harry Potter",
                Idioma = DAL.Idioma.Portugues,
                Preco = 100,
                Altura = 10,
                Largura = 10,
                Profundidade = 2
            };

            ctx.Livros.Add(livroDigital);
            ctx.Livros.Add(audioLivro);
            ctx.Livros.Add(livroImpresso);
            ctx.SaveChanges();
        }

        private static void AdicionarClienteExemplo(AmazoniaContexto ctx)
        {
            ctx.Clientes.Add(new Cliente
            {
                UserName = "joao.silva",
                DataNascimento = new DateTime(1984, 05, 29),
                Nome = "João da Silva",
                NumeroIdentificacaoFiscal = "123456789",
                Password = "senha"
            });
            ctx.SaveChanges();
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
