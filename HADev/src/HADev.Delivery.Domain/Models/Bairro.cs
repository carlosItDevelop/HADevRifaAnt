using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HADev.Delivery.Domain.Models
{
    public class Bairro
    {
        [Key]
        public int BairroId { get; set; }

        [Display(Name = "Nome do Estado")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [Range(1, double.MaxValue, ErrorMessage = "Selecione um estado")]
        //[StringLength(200, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 7)]
        public int EstadoId { get; set; }

        [Display(Name = "Nome da cidade")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [Range(1, double.MaxValue, ErrorMessage = "Selecione uma cidade")]
        //[StringLength(200, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 7)]
        public int CidadeId { get; set; }

        [Display(Name = "Nome do bairro")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [StringLength(200, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        [Display(Name = "CEP")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        public string Cep { get; set; }

        public virtual Estado Estado { get; set; }
        public virtual Cidade Cidade { get; set; }
        public virtual ICollection<Eleitor> Eleitor { get; set; }
        public List<Endereco> Enderecos { get; set; }
        
        //public virtual ICollection<Parceiros> parceiro { get; set; }
        //public virtual ICollection<ContasReceber> ContasReceber { get; set; }
    }
}
