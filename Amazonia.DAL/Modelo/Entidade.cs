using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazonia.DAL.Modelo
{
    public abstract class Entidade
    {
        //[Key] Desnecessário que otámos por utilizar o mecanismo de Convenção CoC
        //[Required] Desnecessário que otámos por utilizar o mecanismo de Convenção CoC
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Nome { get; set; }

        public override string ToString() => $"Nome: {Nome} => Identificador: {Id}";
    }
}
