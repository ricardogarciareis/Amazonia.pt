namespace Amazonia.DAL
{
    public class Dimensoes
    {
        public float Largura { get; set; } //cm
        public float Altura { get; set; } //cm
        public float Profundidade { get; set; } //cm
        public float Peso { get; set; } //gr


        //Propriedade
        public float Volume => Largura * Altura * Profundidade;

    }
}