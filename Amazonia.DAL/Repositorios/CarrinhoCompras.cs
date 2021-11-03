using Amazonia.DAL.Desconto;
using Amazonia.DAL.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace Amazonia.DAL.Repositorios
{
    public class CarrinhoCompras : ICarrinhoCompras
    {
        public Cliente Cliente { get; set; }
        public List<Livro> Livros { get; set; }   //ctrl+F12 em cima da classe Livro


        public decimal CalcularPreco()
        {
            var valorCalculado = Livros.Sum(x => x.ObterPreco());

            return valorCalculado;
        }

        #region AplicarDesconto
        //Comentado apenas para guardar o exemplo
        //Este método aplicava desconto de igual forma ao carrinho de compras (substituído pelo método abaixo)
        //public decimal AplicarDesconto(decimal valorDesconto)
        //{
        //    var fatorDesconto = (100 - valorDesconto) / 100
        //    var valorCalculado = Livros.Sum(x => x.ObterPreco())
        //    var valorComDesconto = valorCalculado * fatorDesconto
        //    return valorComDesconto
        //}

        //Implementado a partir da interface ICarrinhoCompras:
        public decimal AplicarDesconto(IDesconto tipoDeDesconto)  //Aplicar desconto através da injeção da interface (INJEÇÃO DE DEPENDÊNCIA)
        {
            var valorCalculado = Livros.Sum(x => x.ObterPreco());            //Trouxe o somatório dos valores totais dos livros com descontos particulares
            var valorComDesconto = tipoDeDesconto.Aplicar(valorCalculado);
            //Foi possível aceder aos métodos definidos na interface IDesconto e implementados nas
            //classes derivadas (DescontoPercentual e DescontoCombinado)
            //Se o tipoDeDesconto passado for DescontoPercentual então utiliza o método da classe DescontoPercentual.cs
            //Se o tipoDeDesconto passado for DescontoCombinado  então utiliza o método da classe DescontoCombinado.cs
            return valorComDesconto;
        }
        #endregion

    }
}
