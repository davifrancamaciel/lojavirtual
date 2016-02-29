using SW.Presentation.Models;
using SW.Presentation.ServicoProduto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SW.Presentation.Controllers
{
    public class CestaController : Controller
    {
        // GET: Cesta
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
                ProdutoSoapClient servicoProduto = new ProdutoSoapClient();
                Produto produto = servicoProduto.ListarPorId(id);
                
                
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