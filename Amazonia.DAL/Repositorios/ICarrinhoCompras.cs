using System.Collections.Generic;
using Amazonia.DAL.Entidades;

namespace Amazonia.DAL.Repositorios
{
    interface ICarrinhoCompras
    {
        decimal CalcularPreco();

        decimal AplicarDesconto(decimal valorDesconto);  //TODO: Criar regra Desconto
    }
}
