using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HADev.Delivery.Domain.Models
{
    public class Visita
    {

        [Key]
        public int VisitaId { get; set; }

        [Display(Name = "Eleitor")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        public int EleitorId { get; set; }

        [Display(Name = "Data da Visita")]
        [Required(ErrorMessage = " O Campo {0} é Obrigatório!")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataVisita { get; set; }

        [Display(Name = "Observação")]
        [DataType(DataType.MultilineText)]
        public string Obs { get; set; }

        public virtual Eleitor Eleitor { get; set; }
    }
}
