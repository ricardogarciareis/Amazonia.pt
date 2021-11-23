using System;
using System.Collections.Generic;
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

            PlaygroundLinq(ctx);




            //GuardCondition
            return;

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

        private static void PlaygroundLinq(AmazoniaContexto ctx)
        {
            //SelecaoSimples(ctx);
            //SelecaoComPaginacao(ctx);
            //SelecacoComOrdenacao(ctx);
            //CriacaoNovosClientes(ctx);
            //DadosEspecificosDeClientes(ctx);
            //SQLRaw(ctx);
            //ProjecaoComJuncao(ctx);
            //LazyLoad(ctx);

            ProjecaoDadosEspecificos(ctx);

            //throw new NotImplementedException();
        }


        private static void ProjecaoDadosEspecificos(AmazoniaContexto ctx)
        {
            //COUNT
            var contagemGeral = ctx.Livros.Count();
            //-------------------------------------------------------------------------------------------
            //AGRUPAMENTO
            var contagemAgrupadoPorNome = ctx.Livros.AsEnumerable().GroupBy(x => x.Nome)
                .Select(ex =>
                new
                {
                    NomeLivro = ex.FirstOrDefault().Nome,
                    Contagem = ex.Count()
                });
            foreach (var item in contagemAgrupadoPorNome)
            {
                Console.WriteLine($"Nome: {item.NomeLivro} - Contagem: {item.Contagem}");
            }
            //------------------------------------
            var contagemAgrupadoPorNomeEAutor = ctx.Livros.AsEnumerable().GroupBy(x => 
                new
                {
                    x.Nome,
                    x.Autor
                })
                    .Select(ex =>
                    new
                    {
                        NomeLivro = ex.FirstOrDefault().Nome,
                        NomeAutor = ex.FirstOrDefault().Autor,
                        Contagem = ex.Count()
                    });
            //-------------------------------------------------------------------------------------------
            //SUM
            var somatorioVolumeLivros = ctx.LivrosImpressos.AsEnumerable().GroupBy(x => x.Nome)
                .Select(ex =>
                new
                {
                    NomeLivro = ex.FirstOrDefault().Nome,
                    Somatorio = ex.Sum(x => x.Volume)
                });
            //-------------------------------------------------------------------------------------------
            //AVERAGE , MAX E MIN
            var mediaVolumeLivros = ctx.LivrosImpressos.AsEnumerable().GroupBy(x => x.Nome)
                .Select(ex =>
                new
                {
                    NomeLivro = ex.FirstOrDefault().Nome,
                    Somatorio = ex.Average(x => x.Volume),
                    LivroMaiorVolume = ex.Max(x => x.Volume),
                    LivroMaisLeve = ex.Min(x => x.Peso)
                });
            //-------------------------------------------------------------------------------------------
        }

        private static void LazyLoad(AmazoniaContexto ctx)
        {
            var clientesMoramPorto = ctx.Clientes.Where(x => x.Morada.Localidade == "Porto").ToList();
            //LazyLoad
            var clientesMoramPortoComOutrasMoradas = ctx.Clientes.Include("Morada").Where(x => x.Morada.Localidade == "Porto").ToList();

            foreach (var i in clientesMoramPortoComOutrasMoradas)
            {
                Console.WriteLine("Nome: " + i.Nome);
                Console.WriteLine("Endereço: " + i.Morada.Endereco);
                Console.WriteLine("--------------------------------------------");
            }
        }

        private static void SQLRaw(AmazoniaContexto ctx)
        {
            //BUG:
            var clientesQueMoramPortoSQLRaw = ctx.Clientes
                .FromSqlRaw("SELECT c.Nome, m.Endereco " +
                            "FROM Clientes c " +
                            "LEFT JOIN Moradas m ON c.MoradaId = m.Id " +
                            "WHERE m.Localidade = 'PORTO'").ToList();

            foreach (var i in clientesQueMoramPortoSQLRaw)
            {
                Console.WriteLine("Nome: " + i.Nome);
                Console.WriteLine("Endereço: " + i.Morada.Endereco);
                Console.WriteLine("--------------------------------------------");
            }
        }

        private static void ProjecaoComJuncao(AmazoniaContexto ctx)
        {
            var clientesQueMoramNoPorto = from c in ctx.Clientes
                                          join m in ctx.Moradas
                                          on c.Morada.Id equals m.Id
                                          where m.Localidade == "Porto"
                                          select new
                                          {
                                              c.Nome,
                                              m.Endereco
                                          };

            var clientesQueMoramNoPortoFluentAPI = ctx.Clientes
                .Where(x => x.Morada.Localidade == "Porto")
                .Select(x => new
                {
                    Nome = x.Nome,
                    Endereco = x.Morada.Endereco
                });


            foreach (var i in clientesQueMoramNoPortoFluentAPI)
            {
                Console.WriteLine("Nome: " + i.Nome);
                Console.WriteLine("Endereço: " + i.Endereco);
                Console.WriteLine("--------------------------------------------");
            }
        }

        private static void DadosEspecificosDeClientes(AmazoniaContexto ctx)
        {
            //SELECT * FROM clientes c LEFT JOIN moradas m ON m.id = c.morada.id WHERE m.Distrito = 'Porto'

            var clientesQueMoramNoPorto = ctx.Clientes.Where(x => x.Morada.Distrito == "Porto").ToList();
            //-------------------------------------------------------------------------------------------
            var dadosEspecificos = clientesQueMoramNoPorto.Select(x => new
            {
                x.Nome,
                //x.Morada.Endereco,           não acede
                x.NumeroIdentificacaoFiscal
            });
            foreach (var i in dadosEspecificos)
            {
                Console.WriteLine(i);
            }
            //-------------------------------------------------------------------------------------------
            var dadosEspecificosModificados = clientesQueMoramNoPorto.Select(x => new
            {
                NomeEmMaiusculo = x.Nome.ToUpper(),
                NIF = x.NumeroIdentificacaoFiscal
            });
            foreach (var i in dadosEspecificosModificados)
            {
                Console.WriteLine(i);
            }
            //-------------------------------------------------------------------------------------------
        }

        private static void CriacaoNovosClientes(AmazoniaContexto ctx)
        {
            for (int i = 0; i < 5; i++)
            {
                var clienteNovo = new Cliente
                {
                    DataNascimento = new DateTime(1984, i + 1, i + 1),
                    Nome = "João da Silva" + i,
                    NumeroIdentificacaoFiscal = "123456789",
                    UserName = "joao.silva" + i,
                    Password = "abc,1234",
                    Morada = new Morada
                    {
                        CodigoPostal = "123456" + i,
                        Distrito = "Porto",
                        Localidade = "Porto",
                        Endereco = "Rua das Casas no " + (i + 1),
                        Nome = "Morada Principal"
                    }
                };
                ctx.Clientes.Add(clienteNovo);
            }
            ctx.SaveChanges();
        }

        private static void SelecacoComOrdenacao(AmazoniaContexto ctx)
        {
            var listaNomes = new List<string> { "João", "Mateus", "Marcos", "Lucas", "Maria", "Pedro" };
            var nomesOrdenadosAsc = listaNomes.OrderBy(x => x);
            var nomesOrdenadosDesc = listaNomes.OrderByDescending(x => x);

            //SELECT * FROM livros ORDER BY preco
            var livrosMaisBaratosPrimeiro = ctx.Livros.OrderBy(x => x.ObterPreco);

            //SELECT * FROM livros ORDER BY nome, preco
            var livrosOrderPrecoENome = ctx.Livros.OrderBy(x => x.Nome).ThenByDescending(x => x.ObterPreco);
        }

        private static void SelecaoComPaginacao(AmazoniaContexto ctx)
        {
            //Selecionar primeiro livro e transformar NOME em UPPERCASE
            var primeiroLivro = ctx.Livros.FirstOrDefault(x => x.Idioma == DAL.Idioma.Portugues);
            var primeiroLivroNome = primeiroLivro.Nome.ToUpper();

            //Selecionar primeiros 10 livros (paginação)
            var primeiros10Livros = ctx.Livros.Take(10).Where(x => x.Idioma == DAL.Idioma.Portugues);

            //Selecionar primeiros 10 livros com skip (paginação)
            var primeiros10LivrosEscape10Iniciais = ctx.Livros.Skip(10).Take(10).Where(x => x.Idioma == DAL.Idioma.Portugues);
        }

        private static void SelecaoSimples(AmazoniaContexto ctx)
        {
            //Selecionar um objeto com Linq SELECT
            //Select * From tabela

            var listaResultado = new List<Livro>();
            foreach (var livro in ctx.Livros)
            {
                if (livro.Nome.StartsWith("H"))
                {
                    listaResultado.Add(livro);
                }
            }
            //Substituído por:
            //Linq antigo
            var livrosX = from livro in ctx.Livros
                          where livro.Nome.StartsWith("H")
                          select livro;

            //Com SQL
            //SELECT * FROM livros WHERE nome LIKE 'h%'

            //Linq com FluentAPI
            var livros = ctx.Livros.Where(l => l.Nome.StartsWith("H")).ToList();
            foreach (var livro in livros)
            {
                Console.WriteLine(livro);
            }

            //Com OU
            var senhorDosAneisOuHarryPotter = ctx.Livros.Where(l => l.Nome.StartsWith("h") || l.Nome.StartsWith("l")).ToList();

            //Exemplo Quebra de Linha
            var senhorDosAneisOuHarryPotter2 = ctx.Livros
                .Where(l =>
                    l.Nome.StartsWith("h")
                    || l.Nome.StartsWith("l"))
                .ToList();
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
