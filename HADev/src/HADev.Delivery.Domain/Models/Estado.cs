using HADev.Delivery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HADev.Delivery.Domain.Models
{
    public class Estado
    {
        [Key]
        public int EstadoId { get; set; }

        [Display(Name = "Nome do Estado")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [StringLength(200, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        [Display(Name = "UF do Estado")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [StringLength(2, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 1)]
        public string UF { get; set; }

        public virtual ICollection<Cidade> cidade { get; set; }
        public virtual ICollection<Bairro> bairro { get; set; }
        public virtual ICollection<Eleitor> Eleitor { get; set; }
        public List<Endereco> Enderecos { get; set; }
        //public virtual ICollection<Candidato> candidato { get; set; }
    }
}
