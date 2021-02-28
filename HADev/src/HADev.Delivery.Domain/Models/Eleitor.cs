

using HADev.Delivery.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.Text;

namespace HADev.Delivery.Domain.Models
{
    public class Eleitor
    {

        [Key]
        public int EleitorId { get; set; }

        [Display(Name = "Eleitor")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [StringLength(200, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 7)]
        public string Nome { get; set; }

        [Display(Name = "Titulo")]
        public string Titulo { get; set; }

        [Display(Name = "Apelído")]
        public string Apelido { get; set; }

        ////[Required(ErrorMessage = "Grau de Parentesco")]
        //[Display(Name = "Grau de Parentesco")]
        //public Grau Grau { get; set; }

        [Display(Name = "Estado")]
        public int EstadoId { get; set; }

        [Display(Name = "Cidade")]
        public int CidadeId { get; set; }

        [Display(Name = "Bairro")]
        [Required(ErrorMessage = " O Campo {0} é Obrigatório!")]
        public int BairroId { get; set; }

        [Display(Name = "Endereço")]
        [Required(ErrorMessage = " O Campo {0} é Obrigatório!")]
        [StringLength(200, ErrorMessage = " O Campo {0} pode ter no máximo {1} e minimo {2} caracteres ", MinimumLength = 2)]
        public string Endereco { get; set; }

        [Display(Name = "Número")]
        [StringLength(20, ErrorMessage = " O Campo {0} pode ter no máximo {1} e minimo {2} caracteres ", MinimumLength = 2)]
        public string Numero { get; set; }

        [Display(Name = "Complemento")]
        public string Complemento { get; set; }

        [Display(Name = "Telefone")]
        [Required(ErrorMessage = " O Campo {0} é Obrigatório!")]
        [StringLength(20, ErrorMessage = " O Campo {0} pode ter no máximo {1} e minimo {2} caracteres ", MinimumLength = 7)]
        public string Celular { get; set; }


        [Display(Name = "Telefone")]
        public string Telefone { get; set; }



        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public Sexo Sexo { get; set; }

        [Display(Name = "CEP")]
        public string Cep { get; set; }

        [Display(Name = "Data de Cadastro")]
        public DateTime DataCadastro { get; set; }

       
        public Enums.EstadoCivil EstadoCivil { get; set; }

        [Required(ErrorMessage = " O Campo {0} é Obrigatório!")]
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataNascimento { get; set; }

        [Display(Name = "Observação")]
        [DataType(DataType.MultilineText)]
        //[StringLength(2000, ErrorMessage = " O Campo {0} pode ter no máximo {1} carateres")]
        public string Obs { get; set; }

        public virtual Estado Estado { get; set; }
        public virtual Cidade Cidade { get; set; }
        public virtual Bairro Bairro { get; set; }
        public virtual ICollection<Visita> Visita { get; set; }


    }
}
