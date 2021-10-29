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
        public string NumeroIdentificacaoFiscal { get; set; }
        public bool NifEstaValido()  //Botão direito em cima do nome do método e Create Unit Tests * 
        {
            if(NumeroIdentificacaoFiscal.Length != 9)
            {
                return false;
            }

            if(NumeroIdentificacaoFiscal.ToArray().ToList().Distinct().ToList().Count == 1)
            {
                return false;
            }

            var fatorMultiplicacao = 2;
            var produtoSomatorio = 0;
            for(int i = NumeroIdentificacaoFiscal.Length - 2; i >= 0; i--)
            {
                var elemento = Convert.ToInt32(NumeroIdentificacaoFiscal[i].ToString());
                var produto = elemento * fatorMultiplicacao;
                produtoSomatorio += produto;
                fatorMultiplicacao++;
            }
            var restoDivisaoPor11 = produtoSomatorio % 11;
            if((restoDivisaoPor11 == 0 || restoDivisaoPor11 == 1) && Convert.ToInt32(NumeroIdentificacaoFiscal[8].ToString()) == 0)
            {
                return true;
            }
            else
            {
                return (11 - restoDivisaoPor11) == Convert.ToInt32(NumeroIdentificacaoFiscal[8].ToString());
            }





            //return false; inicial
            return true;
        }
        // *Create Unit Tests:
        // Framework p/ Testes: MSTestv2
        //   Projeto de Testes: Amazonia.DAL.Tests
        // A classe ClienteTests.cs foi criada

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