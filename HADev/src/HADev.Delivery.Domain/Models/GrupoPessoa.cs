using HADev.Delivery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HADev.Delivery.Domain.Models
{
    public class GrupoPessoa : EntityBase
    {

        [Display(Name = "Grupo de Pessoa")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [StringLength(200, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        public virtual ICollection<Pessoa> pessoa { get; set; }

    }
}
