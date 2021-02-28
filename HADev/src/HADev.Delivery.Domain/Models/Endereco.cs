using HADev.Delivery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HADev.Delivery.Domain.Models
{
    public class Endereco : EntityBase
    {
        [ForeignKey(name: "Pessoa")]
        public Guid PessoaId { get; set; }
        public string Descricao { get; set; }
        public string Responsavel { get; set; }
        public string CEP { get; set; }
        public string Longradouro { get; set; }
        public string Numero { get; set; }
        public string Referencia { get; set; }

        public int EstadoId { get; set; }

        public int CidadeId { get; set; }

        public int BairroId { get; set; }

        public virtual Estado Estado { get; set; }
        public virtual Cidade Cidade { get; set; }
        public virtual Bairro Bairro { get; set; }
        public virtual Pessoa Pessoa { get; set; }


    }
}
