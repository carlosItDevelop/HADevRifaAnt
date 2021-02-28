using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HADev.Delivery.Domain.Models
{
    public class Cidade
    {
        [Key]
        public int CidadeId { get; set; }

        [Display(Name = "Nome do estado")]
        //[Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [Range(1, double.MaxValue, ErrorMessage = "Selecione um estado")]
        //[StringLength(200, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 7)]
        public int EstadoId { get; set; }

        [Display(Name = "Nome da cidade")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [StringLength(200, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        public virtual Estado Estado { get; set; }
        public virtual ICollection<Bairro> bairro { get; set; }
        public virtual ICollection<Eleitor> Eleitor { get; set; }
        public List<Endereco> Enderecos { get; set; }
    }
}
