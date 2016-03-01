using SW.Presentation.Helpers;
using SW.Presentation.Models;
using SW.Presentation.ServicoProduto;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;

namespace SW.Presentation.Controllers
{
    public class CestaController : Controller
    {
        ReferenciaServico referenciaServico;
        public CestaController()
        {
            referenciaServico = new ReferenciaServico();
        }


        public ActionResult Index()
        {
            return View();
        }
        //Método para adicionar 1 novo produto na cesta de compras
        [HttpGet] //indicar que o dado é resgatado por URL
        public ActionResult AdicionarProduto(int id)
        {
            try
            {

                Produto produto = new Produto();                              

                produto = referenciaServico.servicoProduto.ListarPorId(id);

                produto.ProdutoPromocao = new ProdutoPromocao();
                produto.ProdutoPromocao.Promocao = new Promocao();

                var promocao = referenciaServico.servicoProdutoPromocao.Listar().Where(x => x.ProdutoId == produto.Id && x.Ativa == true).FirstOrDefault();
                if (promocao != null)
                {
                    produto.ProdutoPromocao.Promocao.Titulo = promocao.Promocao.Titulo;
                }

                //criar um item para a cesta de compras
                ItemCesta item = new ItemCesta();

                item.Produto = produto; //relacionando o item ao produto

                item.Quantidade = 1; //quantidade inicial...

                //Verificar se existe uma cesta de compras já em sessão
                CestaCompra cesta = new CestaCompra(); //inicializando o objeto
                cesta.Itens = new List<ItemCesta>(); //inicializando a lista

                if (Session["cesta"] != null) //verificando se já existe uma cesta em sessão
                {
                    cesta = (CestaCompra)Session["cesta"]; //resgatando o conteudo da sessão
                }

                //adicionar o item na cesta...
                cesta.AddItem(item);
                //gravar em sessão
                Session.Add("cesta", cesta);
            }
            catch (Exception e)
            {
                ViewBag.Mensagem = e.Message;
            }

            return RedirectToAction("Index"); //nome da página...
        }

        [HttpGet]
        public ActionResult Incrementar(int id)
        {
            CestaCompra cesta = (CestaCompra)Session["cesta"];
            cesta.AumentarQuantidade(id);
            Session.Add("cesta", cesta);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Decrementar(int id)
        {
            CestaCompra cesta = (CestaCompra)Session["cesta"];
            cesta.ReduzirQuantidade(id);
            Session.Add("cesta", cesta);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Remover(int id)
        {
            CestaCompra cesta = (CestaCompra)Session["cesta"];
            cesta.Remover(id);
            Session.Add("cesta", cesta);

            return RedirectToAction("Index");
        }
    }
}