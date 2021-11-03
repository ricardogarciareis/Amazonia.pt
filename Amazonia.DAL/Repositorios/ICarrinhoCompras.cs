using Amazonia.DAL.Desconto;

namespace Amazonia.DAL.Repositorios
{
    interface ICarrinhoCompras
    {
        decimal CalcularPreco();

        #region AplicarDesconto
        //Comentado só para guardar histórico
        //Este método aplicava desconto de igual forma ao carrinho de compras (ver CarrinhoCompras.cs)
        //decimal AplicarDesconto(decimal valorDesconto);  

        //INJEÇÃO DE DEPENDÊNCIA
        decimal AplicarDesconto(IDesconto tipoDeDesconto);  //São criadas regras específicas para o objeto (ver CarrinhoCompras.cs)
        #endregion
    }
}


