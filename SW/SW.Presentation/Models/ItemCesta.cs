using SW.Presentation.Helpers;
using SW.Presentation.ServicoProduto;
using System;
using System.Linq;

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
            get { return Totalizar(Produto.Id, Quantidade); }
        }
        public double Totalizar(int id, int quantidade)
        {
            var produto = referenciaServico.servicoProduto.ListarPorId(id);
            var promocao = referenciaServico.servicoProdutoPromocao.Listar().Where(x => x.ProdutoId == id && x.Ativa == true).FirstOrDefault();

            if (promocao != null)
            {
                switch (promocao.Promocao.TipoDesconto.Desconto)
                {
                    case "Porcentagem":
                        double percentual = promocao.Promocao.Valor / 100;

                        if ((quantidade % promocao.Promocao.Quantidade) == 0)
                        {
                            produto.Preco = produto.Preco - (percentual * produto.Preco);
                            return produto.Preco * quantidade;
                        }
                        else
                        {
                            int qtd = (quantidade / promocao.Promocao.Quantidade) * promocao.Promocao.Quantidade;
                            int resto = quantidade % promocao.Promocao.Quantidade;
                            double preco;//, preco2;
                            //preco = (produto.Preco - (percentual * produto.Preco)) * qtd;
                            //preco2 = produto.Preco * resto;
                            //produto.Preco = preco + preco2;
                            preco = ((produto.Preco - (percentual * produto.Preco)) * qtd) + produto.Preco * resto;

                            produto.Preco = preco;

                            return produto.Preco;
                        }
                        break;
                    case "Valor Final":

                        if ((quantidade % promocao.Promocao.Quantidade) == 0)
                        {
                            int qtd = quantidade / promocao.Promocao.Quantidade;
                            return produto.Preco = promocao.Promocao.Valor * qtd;
                        }
                        else
                        {
                            if (quantidade > promocao.Promocao.Quantidade)
                            {
                                int qtd = quantidade / promocao.Promocao.Quantidade;
                                int resto = quantidade % promocao.Promocao.Quantidade;
                                //double preco, preco2;
                                //preco = promocao.Promocao.Valor * qtd;
                                //preco2 = produto.Preco * resto;

                                //return produto.Preco = preco + preco2;
                                return produto.Preco = (promocao.Promocao.Valor * qtd) + (produto.Preco * resto);
                            }
                            else
                            {
                                return produto.Preco * quantidade;
                            }
                        }
                        break;
                    default:
                        return produto.Preco * quantidade;
                        break;
                }
            }
            else
            {
                return produto.Preco * quantidade;
            }
           
        }
    }
}