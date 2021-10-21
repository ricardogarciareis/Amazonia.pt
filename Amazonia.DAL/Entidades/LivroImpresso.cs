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
    }
}