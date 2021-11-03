using Amazonia.DAL.Desconto;

namespace Amazonia.DAL.Repositorios
{
    interface ICarrinhoCompras
    {
        decimal CalcularPreco();

        #region AplicarDesconto
        //Comentado s� para guardar hist�rico
        //Este m�todo aplicava desconto de igual forma ao carrinho de compras (ver CarrinhoCompras.cs)
        //decimal AplicarDesconto(decimal valorDesconto);  

        //INJE��O DE DEPEND�NCIA
        decimal AplicarDesconto(IDesconto tipoDeDesconto);  //S�o criadas regras espec�ficas para o objeto (ver CarrinhoCompras.cs)
        #endregion
    }
}


