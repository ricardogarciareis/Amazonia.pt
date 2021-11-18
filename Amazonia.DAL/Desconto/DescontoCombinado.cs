using Amazonia.DAL.Modelo;
using System.Collections.Generic;
using System.Linq;

namespace Amazonia.DAL.Desconto
{
    public class DescontoCombinado : IDesconto
    {
        public decimal PercentualDesconto { get; set; }    //Desconto aplicado
        public int QtdMinimaLivrosDigitais { get; set; }         //Qtd. de livros do tipo Digital no Carrinho
        public int QtdMinimaLivrosImpressos { get; set; }        //Qtd. de livros do tipo Impresso no Carrinho
        public List<Livro> LivrosNoCarrinho { get; set; }  //Lista de Livros no carrinho de Compras

        /// <summary>
        /// Desconto combinado = se tiver pelo menos 2 livros do tipo digital E tiver pelo menos 1 livro impresso => aplicar x% de desconto
        /// </summary>

        public decimal Aplicar(decimal valorSemDesconto)
        {
            var qtdLivrosImpressos = LivrosNoCarrinho.Where(x => x.GetType() == typeof(LivroImpresso)).Count();  //Reflexion *
            var qtdLivrosDigitais = LivrosNoCarrinho.Where(x => x.GetType() == typeof(LivroDigital)).Count();

            if (qtdLivrosDigitais < QtdMinimaLivrosDigitais || qtdLivrosImpressos < QtdMinimaLivrosImpressos)
            {
                PercentualDesconto = 0;
            }          
            return valorSemDesconto * (1 - PercentualDesconto / 100);
        }
    }
}

// *O Reflexion permite em tempo de execução (runtime) verificar as caraterísticas dos objetos