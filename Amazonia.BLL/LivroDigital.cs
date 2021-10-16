using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazonia.BLL
{
    class LivroDigital : Livro
    {
        public int TamanhoEmMB { get; set; }
        public string FormatoFicheiro { get; set; } //pdf, doc, epub....
        public string InformacoesLicenca { get; set; }


    }
}