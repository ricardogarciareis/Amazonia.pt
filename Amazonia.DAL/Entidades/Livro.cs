using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazonia.DAL.Entidades
{
    public abstract class Livro : Entidade
    {
        public decimal Preco { protected get; set; }
        public string Descricao { get; set; }
        public string Autor { get; set; }

        public Idioma Idioma { get; set; } //Só em português, espanhol, inglês

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