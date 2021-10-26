using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazonia.DAL.Entidades
{
    public class Cliente : Entidade
    {
        //public Cliente()
        //{
            //Identificador = Guid.NewGuid();
        //}
        //public Guid Identificador { get; }
        //public string Nome { get; set; }
        public Morada Morada { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime DataNascimento { get; set; }
        public int Idade => DateTime.Now.Year - DataNascimento.Year;

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("| Nome: " + Nome);
            sb.AppendLine("| Identificador: " + Identificador);
            sb.AppendLine("| Idade: " + Idade);
            sb.Append("+------------------------------------------------------------------+");
            return sb.ToString();
        }
    }
}