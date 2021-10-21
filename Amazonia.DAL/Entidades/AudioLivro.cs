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

    }
}