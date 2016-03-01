
namespace SW.Presentation.Areas.Administracao.Models
{
    public class ProdutoPromocaoVM
    {
        
        public int Id { get; set; }        
        public int ProdutoId { get; set; }        
        public int PromocaoId { get; set; }
        public bool Ativa { get; set; }
        public ProdutoVM ProdutoVM { get; set; }
        public PromocaoVM PromocaoVM { get; set; }
    }
}