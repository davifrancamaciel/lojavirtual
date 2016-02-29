using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SW.Presentation.Areas.Administracao.Models
{
    public class PromocaoVM
    {
        [Display(Name = "Promocao ID:")]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo Titulo é obrigatório.")]
        [Display(Name = "Titulo:")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O campo Valor é obrigatório.")]
        [Display(Name = "Valor:")]
        public double Valor { get; set; }

        [Required(ErrorMessage = "O campo Tipo Desconto é obrigatório.")]
        [Display(Name = "Tipo Desconto:")]
        public int TipoDescontoId { get; set; }

        [Required(ErrorMessage = "O campo Quantidade é obrigatório.")]
        [Display(Name = "Quantidade:")]
        public int Quantidade { get; set; }
    }
}