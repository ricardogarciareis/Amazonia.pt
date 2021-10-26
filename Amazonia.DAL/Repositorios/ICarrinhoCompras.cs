using System.Collections.Generic;
using Amazonia.DAL.Entidades;

namespace Amazonia.DAL.Repositorios
{
    interface ICarrinhoCompras
    {
        decimal CalcularPreco(List<Livro> livros);

        decimal AplicarDesconto(int valorDesconto);  //TODO: Criar regra Desconto
    }
}
