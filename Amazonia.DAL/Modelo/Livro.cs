using Amazonia.DAL.Modelo;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Amazonia.DAL.Modelo
{
    public abstract class Livro : Entidade
    {
        [Required]
        [Range(0, 1000)]
        public decimal Preco { protected get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        [MaxLength(255)]
        public string Autor { get; set; }


        public Idioma Idioma { get; set; }   //Portugues, Espanhol, Ingles, Frances

        [NotMapped]
        public virtual decimal ObterPreco => Preco;

    }
}