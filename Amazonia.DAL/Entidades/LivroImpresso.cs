using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazonia.DAL.Entidades
{
    public class LivroImpresso : Livro
    {
        public int QuantidadePaginas { get; set; }
        public Dimensoes Dimensoes { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("| Livro Impresso: " + base.ToString());
            sb.AppendLine("| Quantidade de Páginas: " + QuantidadePaginas);
            sb.AppendLine("| Dimensões do Livro: " + Dimensoes);
            sb.Append("+------------------------------------------------------------------+");
            return sb.ToString();
        }
    }
}