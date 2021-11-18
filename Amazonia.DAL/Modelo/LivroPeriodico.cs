using System;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Text;

namespace Amazonia.DAL.Modelo
{
    // 02/11/2021
    public class LivroPeriodico : Livro   //31:40 02.11.2021 f1
    {
        [Required]
        public DateTime DataLancamento { get; set; }
        
        public LivroPeriodico()
        {
            if(DataLancamento == new DateTime())   //Isto previne situações em que o livro é criado sem data de lançamento
            {
                DataLancamento = DateTime.Today;
            }
        }

        //public override decimal ObterPreco()  //O método virtual provém da classe Livro do ficheiro Livro.cs
        //{
        //    var ativarDesconto = Convert.ToBoolean(ConfigurationManager.AppSettings["ativarDesconto"]);

        //    TimeSpan intervaloTempo = DateTime.Today - DataLancamento;
        //    int diasAposLancamento = intervaloTempo.Days;

        //    if (ativarDesconto)
        //    {
        //        var primeiroPeriodoDesconto = Convert.ToInt32(ConfigurationManager.AppSettings["primeiroPeriodoDesconto"]);
        //        var segundoPeriodoDesconto = Convert.ToInt32(ConfigurationManager.AppSettings["segundoPeriodoDesconto"]);
        //        var primeiroNivelDesconto = Convert.ToDecimal(ConfigurationManager.AppSettings["primeiroNivelDesconto"]);
        //        var segundoNivelDesconto = Convert.ToDecimal(ConfigurationManager.AppSettings["segundoNivelDesconto"]);
                
        //        if (diasAposLancamento < primeiroPeriodoDesconto)
        //        {
        //            return base.ObterPreco();
        //        }
        //        else if(diasAposLancamento >= primeiroPeriodoDesconto && diasAposLancamento < segundoPeriodoDesconto)
        //        {
        //            return base.ObterPreco() * (1 - primeiroNivelDesconto / 100);
        //        }
        //        else
        //        {
        //            return base.ObterPreco() * (1 - segundoNivelDesconto / 100);
        //        }
        //    }
        //    else
        //    {
        //        return base.ObterPreco();
        //    }
        //}

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
