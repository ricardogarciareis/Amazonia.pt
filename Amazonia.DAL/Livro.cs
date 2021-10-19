using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazonia.DAL
{
    public abstract class Livro
    {
        public string Nome { get; set; }
        //public string TipoPublicacao { get; set; }
        public decimal Preco { get; set; }
        public string Descricao { get; set; }
        public string Autor { get; set; }

        //public string Idioma { get; set; } //Só em português, espanhol, inglês
        public Idioma Idioma { get; set; }
    }
}