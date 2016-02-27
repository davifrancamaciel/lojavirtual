using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SW.Web.Areas.Administracao.Models
{
    public class ProdutoVM
    {
        [Display(Name = "ID Produto:")]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [Display(Name = "Nome:")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo Preco é obrigatório.")]
        [Display(Name = "Preco:")]
        public double Preco { get; set; }

        public DateTime DataCadastro { get; set; }

        [Display(Name = "Promocao:")]
        public int PromocaoId { get; set; }
        public int ProdutoPromocaoId { get; set; }

        [Display(Name = "Ativa:")]
        public bool Ativa { get; set; }
    }
}