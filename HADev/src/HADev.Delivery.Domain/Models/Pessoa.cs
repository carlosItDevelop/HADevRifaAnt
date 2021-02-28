using HADev.Delivery.Domain.Entities;
using HADev.Delivery.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HADev.Delivery.Domain.Models
{
    public class Pessoa : EntityBase
    {
        public Pessoa() { Ativo = true; Atualizar = true; }

        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Rg { get; set; }
        public string OrgaoEspedidor { get; set; }
        public string Nome { get; set; }
        public Sexo Sexo { get; set; }
        public EstadoCivil EstadoCivil { get; set; }
        public Guid? GrupoPessoaId { get; set; }
        public virtual GrupoPessoa GrupoPessoa { get; set; }
        public string NomeMae { get; set; }
        public string NomePai { get; set; }
        public bool Cliente { get; set; }
        public bool Fornecedor { get; set; }
        public bool Vendedor { get; set; }
        public TipoPessoa TipoPessoa { get; set; }
        public DateTime DataCadastro { get; set; }
        public Guid? UserCadastroId { get; set; }
        public DateTime DataAlteracao { get; set; }
        public Guid? UserAlteracaoId { get; set; }
        public bool Ativo { get; set; }
        public bool Atualizar { get; set; }
        public string SenhaCDA { get; set; }
        public string Bio { get; set; }

    }
}
