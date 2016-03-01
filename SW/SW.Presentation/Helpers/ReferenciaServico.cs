
namespace SW.Presentation.Helpers
{
    public class ReferenciaServico
    {
        public SW.Presentation.ServicoProduto.ProdutoSoapClient servicoProduto;
        public SW.Presentation.ServicoProdutoPromocao.ProdutoPromocaoSoapClient servicoProdutoPromocao;
        public SW.Presentation.ServicoPromocao.PromocaoSoapClient servicoPromocao;
        public SW.Presentation.ServicoTipoDesconto.TipoDescontoSoapClient servicoTipoDesconto;
        public ReferenciaServico()
        {
            servicoProduto = new SW.Presentation.ServicoProduto.ProdutoSoapClient();
            servicoProdutoPromocao = new SW.Presentation.ServicoProdutoPromocao.ProdutoPromocaoSoapClient();
            servicoPromocao = new SW.Presentation.ServicoPromocao.PromocaoSoapClient();
            servicoTipoDesconto = new SW.Presentation.ServicoTipoDesconto.TipoDescontoSoapClient();
        }
    }
}