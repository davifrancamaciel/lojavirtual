using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SW.Web.Helpers
{
    public class ReferenciaServico
    {
        public ServicoProduto.ProdutoSoapClient servicoProduto;
        public ServicoProdutoPromocao.ProdutoPromocaoSoapClient servicoProdutoPromocao;
        public ServicoPromocao.PromocaoSoapClient servicoPromocao;
        public ServicoTipoDesconto.TipoDescontoSoapClient servicoTipoDesconto;
        public ReferenciaServico()
        {
            servicoProduto = new ServicoProduto.ProdutoSoapClient();
            servicoProdutoPromocao = new ServicoProdutoPromocao.ProdutoPromocaoSoapClient();
            servicoPromocao = new ServicoPromocao.PromocaoSoapClient();
            servicoTipoDesconto = new ServicoTipoDesconto.TipoDescontoSoapClient();
        }
    }
}