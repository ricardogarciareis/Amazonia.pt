using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazonia.BLL
{
    public class Dimensoes
    {
        public float Largura { get; set; } //cm
        public float Altura { get; set; } //cm
        public float Profundidade { get; set; } //cm
        public float Peso { get; set; } //gr


        //Propriedade
        public float Volume => Largura * Altura * Profundidade;

        //Método que faz o mesmo
        //public float ObterVolume(){
        //    return Largura * Altura * Profundidade;
        //}

    }
}