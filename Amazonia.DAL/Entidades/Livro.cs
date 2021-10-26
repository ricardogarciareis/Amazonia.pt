using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazonia.DAL.Entidades
{
    public abstract class Livro : Entidade
    //public class Livro : Entidade
    {
        //public string Nome { get; set; }
        //public string TipoPublicacao { get; set; }
        public decimal Preco { get; set; }
        public string Descricao { get; set; }
        public string Autor { get; set; }

        //public string Idioma { get; set; } //Só em português, espanhol, inglês
        public Idioma Idioma { get; set; }

        public virtual decimal ObterPreco(){
            return Preco;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(Nome);
            sb.Append("| Identificador: " + Identificador);
            return sb.ToString();
        }
    }
}