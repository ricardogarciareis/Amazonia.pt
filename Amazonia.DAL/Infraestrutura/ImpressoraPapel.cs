using System;

namespace Amazonia.DAL.Infraestrutura
{
    public class ImpressoraPapel : IImpressora
    {
        public void Imprimir()
        {
            Console.WriteLine("Utilizando a impressora em papel");
            //Regras para gerar uma impressão em papel:
        }
    }
}