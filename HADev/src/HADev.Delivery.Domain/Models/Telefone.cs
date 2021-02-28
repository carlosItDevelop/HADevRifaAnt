using HADev.Delivery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HADev.Delivery.Domain.Models
{
    public class Telefone : EntityBase
    {
        [ForeignKey(name:"Pessoa")]
        public Guid PessoaId { get; set; }
        public string Fone { get; set; }
        public virtual Pessoa Pessoa { get; set; }
    }
}
