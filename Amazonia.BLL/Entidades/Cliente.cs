using System;
using System.Linq;
using System.Text;

namespace Amazonia.DAL.Entidades
{
    public class Cliente
    {

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
            //this.ToString()
        }

        /// <summary>
        /// Exibe os dados do cliente
        /// </summary>
        /// <returns></returns>

        // *Create Unit Tests:
        // Framework p/ Testes: MSTestv2
        //   Projeto de Testes: Amazonia.DAL.Tests
        // A classe ClienteTests.cs foi criada


    }
}