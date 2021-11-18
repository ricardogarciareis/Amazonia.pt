using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Amazonia.DAL.Modelo
{
    public class LivroImpresso : Livro
    {
        [Required]
        [Range(1, 100)]
        public float Largura { get; set; } //cm

        [Required]
        [Range(1, 100)]
        public float Altura { get; set; } //cm

        [Required]
        [Range(1, 100)]
        public float Profundidade { get; set; } //cm

        [Required]
        [Range(50, 10000)]
        public float Peso { get; set; } //gr


        //Propriedade
        [NotMapped]
        public float Volume => Largura * Altura * Profundidade;
        public int QuantidadePaginas { get; set; }
        //public Dimensoes Dimensoes { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("| Livro Impresso: " + base.ToString());
            sb.AppendLine("| Quantidade de Páginas: " + QuantidadePaginas);
            //sb.AppendLine("| Dimensões do Livro: " + Dimensoes);
            sb.Append("+------------------------------------------------------------------+");
            return sb.ToString();
        }
    }
}