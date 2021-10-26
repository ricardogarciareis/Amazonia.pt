using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazonia.DAL.Entidades
{
    public class AudioLivro : Livro
    {
        public string FormatoFicheiro { get; set; }
        public int DuracaoLivro { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("| Audio Livro: " + base.ToString());
            sb.AppendLine("| Duração do Livro em Minutos: " + DuracaoLivro);
            sb.AppendLine("| Formato do Ficheiro: " + FormatoFicheiro);
            sb.Append("+------------------------------------------------------------------+");
            return  sb.ToString();
        }
    }
}