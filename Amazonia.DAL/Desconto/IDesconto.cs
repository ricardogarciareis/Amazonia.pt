namespace Amazonia.DAL.Desconto
{
    public interface IDesconto
    {
        //decimal PercentualDesconto { get; set; }

        decimal Aplicar(decimal valorSemDesconto);
    }
}
