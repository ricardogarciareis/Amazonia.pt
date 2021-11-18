using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Amazonia.DAL.Modelo
{
    public class LivroDigital : Livro
    {
        public int TamanhoEmMB { get; set; }

        [Required]
        [MinLength(3), MaxLength(5)]
        public string FormatoFicheiro { get; set; } //pdf, doc, epub....

        public string InformacoesLicenca { get; set; }

        //public override decimal ObterPreco()
        //{
        //    return base.ObterPreco() * 0.9M;
        //}

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("| Livro Digital: " + base.ToString());
            sb.AppendLine("| Informações de Licença: " + InformacoesLicenca);
            sb.AppendLine("| Tamanho de Ficheiro em MB: " + TamanhoEmMB);
            sb.AppendLine("| Formato de Ficheiro: " + FormatoFicheiro);
            sb.Append("+------------------------------------------------------------------+");
            return sb.ToString();
        }


    }
}