using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Amazonia.DAL.Modelo
{
    public class AudioLivro : Livro
    {
        [Required]
        [MinLength(3), MaxLength(5)]
        public string FormatoFicheiro { get; set; }

        [Range(1, 6000)]
        public int? DuracaoLivroEmMinutos { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("| Audio Livro: " + base.ToString());
            sb.AppendLine("| Duração do Livro em Minutos: " + DuracaoLivroEmMinutos);
            sb.AppendLine("| Formato do Ficheiro: " + FormatoFicheiro);
            sb.Append("+------------------------------------------------------------------+");
            return  sb.ToString();
        }
    }
}