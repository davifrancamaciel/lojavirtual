using SW.Presentation.Areas.Administracao.Models;
using System;
using System.Linq;
using System.Web.Mvc;
using PagedList;

using SW.Presentation.Helpers;

namespace SW.Presentation.Areas.Administracao.Controllers
{
    public class ProdutoController : Controller
    {
        ReferenciaServico referenciaServico;
        public ProdutoController()
        {
            referenciaServico = new ReferenciaServico();
        }

        public ActionResult Index(string q, int? pagina, int? pt)
        {
            if (q == null)
                q = "";
            int paginaTamanho = (pt ?? 10);
            int paginaNumero = (pagina ?? 1);


            var lista = referenciaServico.servicoProduto.Listar().Where(x => x.Nome.ToLower().Contains(q.ToLower()));


            var e = this.RouteData.Values;
            string actionName = (string)e["action"];

            ViewBag.Action = actionName;
            ViewBag.Pagina = pagina;
            ViewBag.PaginaTamanho = pt;
            ViewBag.Query = q;

            return View(lista.ToPagedList(paginaNumero, paginaTamanho));
        }


        public ActionResult Cadastro()
        {
            try
            {
                CarregaDropDowns();
            }
            catch (Exception)
            {

                throw;
            }

            return View(new ProdutoVM());
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastro(ProdutoVM model)
        {
            try
            {
                CarregaDropDowns();
                if (ModelState.IsValid)
                {

                    ServicoProduto.Produto produto = new ServicoProduto.Produto();

                    produto.Id = model.Id;
                    produto.Nome = model.Nome;
                    produto.Preco = model.Preco;

                    if (produto.Id > 0)
                    {

                        produto.DataCadastro = model.DataCadastro;
                        produto.Id = referenciaServico.servicoProduto.Atualizar(produto);
                    }
                    else
                    {
                        produto.DataCadastro = DateTime.Now;
                        produto.Id = referenciaServico.servicoProduto.Cadastrar(produto);
                    }
                    if (!string.IsNullOrEmpty(Request.Form["promocao"]))
                    {

                        ServicoProdutoPromocao.ProdutoPromocao produtoPromocao = new ServicoProdutoPromocao.ProdutoPromocao();

                        produtoPromocao.Id = model.ProdutoPromocaoId;
                        produtoPromocao.PromocaoId = Convert.ToInt32(Request.Form["promocao"]); ;
                        produtoPromocao.ProdutoId = produto.Id;
                        produtoPromocao.Ativa = model.Ativa;
                        if (produtoPromocao.Id > 0)
                        {
                            referenciaServico.servicoProdutoPromocao.Atualizar(produtoPromocao);
                        }
                        else
                        {
                            referenciaServico.servicoProdutoPromocao.Cadastrar(produtoPromocao);
                        }
                    }
                    else
                    {
                        if (produto.Id > 0)
                            referenciaServico.servicoProdutoPromocao.ExcluirPorIdProduto(produto.Id);
                    }

                    return RedirectToAction("index");
                }

                return View(model);

            }
            catch (Exception)
            {
                throw;
            }

        }


        public ActionResult Editar(int id)
        {
            try
            {
                CarregaDropDowns();

                ServicoProduto.Produto produto = new ServicoProduto.Produto();
                ProdutoVM model = new ProdutoVM();

                produto = referenciaServico.servicoProduto.ListarPorId(id);
                var produtoPromocao = referenciaServico.servicoProdutoPromocao.Listar().Where(x => x.ProdutoId == produto.Id).SingleOrDefault();

                model.Id = produto.Id;
                model.Nome = produto.Nome;
                model.Preco = produto.Preco;
                model.DataCadastro = produto.DataCadastro;
                if (produtoPromocao != null)
                {
                    model.PromocaoId = produtoPromocao.PromocaoId;
                    model.ProdutoPromocaoId = produtoPromocao.Id;
                    model.Ativa = produtoPromocao.Ativa;
                }


                return View(model);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public JsonResult Excluir(int id)
        {
            try
            {

                referenciaServico.servicoProduto.Excluir(id);

                return Json(true, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                return Json(false);
            }
        }


        public void CarregaDropDowns()
        {

            ViewBag.Promocao = referenciaServico.servicoPromocao.Listar();
        }

       
    }
}
