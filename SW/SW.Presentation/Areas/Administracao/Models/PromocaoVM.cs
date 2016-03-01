using System.ComponentModel.DataAnnotations;

namespace SW.Presentation.Areas.Administracao.Models
{
    public class PromocaoVM
    {
        [Display(Name = "Promocao ID:")]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo Titulo é obrigatório.")]
        [Display(Name = "Titulo:")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O campo Valor Tipo Desconto é obrigatório.")]
        [Display(Name = "Valor Tipo Desconto:")]
        public double Valor { get; set; }

        [Required(ErrorMessage = "O campo Tipo Desconto é obrigatório.")]
        [Display(Name = "Tipo Desconto:")]
        public int TipoDescontoId { get; set; }

        [Required(ErrorMessage = "O campo Quantidade limite é obrigatório.")]
        [Display(Name = "Quantidade limite:")]
        public int Quantidade { get; set; }
    }
}