using System;

namespace Amazonia.DAL.Infraestrutura
{
    public class ImpressoraPDF : IImpressora
    {
        public void Imprimir()
        {
            Console.WriteLine("Utilizando a impressora PDF");
            //Regras para gerar um pdf:
        }
    }
}