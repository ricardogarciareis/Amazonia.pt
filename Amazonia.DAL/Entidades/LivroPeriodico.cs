using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazonia.DAL.Repositorios;
using Amazonia.DAL.Utils;

namespace Amazonia.DAL.Entidades
{
    public class LivroPeriodico : Livro
    {
        
        public DateTime DataLancamento { get; set; }

        public override decimal ObterPreco()
        {
            var dias = Convert.ToInt32(ConfigurationManager.AppSettings["diasLancamento"]);
            //var dias = Convert.ToInt32(Exemplo.ObterValorDoConfig("diasLancamento"));

            var desconto = Convert.ToInt32(ConfigurationManager.AppSettings["descontoDiasLancamento"]);
            //var desconto = Convert.ToInt32(Exemplo.ObterValorDoConfig("descontoDiasLancamento"));

            DateTime hoje = DateTime.Now;
            TimeSpan intervaloTempo = hoje - DataLancamento;
            int diasAposLancamento = intervaloTempo.Days;
            //if(diasAposLancamento > 31)
            if(diasAposLancamento > dias)
            {
                //return base.ObterPreco() * 0.5M;
                return base.ObterPreco() * (desconto/100);
            }
            else
            {
                return base.ObterPreco();
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("| Livro Digital: " + base.ToString());
            sb.AppendLine("| Data de Lançamento: " + DataLancamento);
            sb.Append("+------------------------------------------------------------------+");
            return sb.ToString();
        }
    }
}
