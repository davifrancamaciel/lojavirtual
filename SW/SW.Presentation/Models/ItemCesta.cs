using SW.Presentation.Helpers;
using SW.Presentation.ServicoProduto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SW.Presentation.Models
{



    public class ItemCesta
    {
        ReferenciaServico referenciaServico;
        public ItemCesta()
        {
            referenciaServico = new ReferenciaServico();
        }
        public Produto Produto { get; set; }

        public int Quantidade { get; set; }

        public double ValorTotal
        {
            get { return Produto.Preco * Quantidade; }
        }
        public double ValorTotal2
        {
            get { return Totalizar(Produto.Id) * Quantidade; }
        }
        public int Totalizar(int id)
        {
            var produto = referenciaServico.servicoProduto.ListarPorId(id);

            return 1;
        }
    }
}