using SW.Web.Areas.Administracao.Models;
using SW.Web.Helpers;
using SW.Web.ServicoProdutoPromocao;
using SW.Web.ServicoPromocao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SW.Web.Areas.Administracao.Controllers
{

    public class ProdutoPromocaoController : Controller
    {
        ReferenciaServico referenciaServico;
        public ProdutoPromocaoController()
        {
            referenciaServico = new ReferenciaServico();
        }
        public ActionResult Index()
        {

            var lista = referenciaServico.servicoProdutoPromocao.Listar();

            return View(lista);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastro(ProdutoPromocaoVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    ProdutoPromocao pp = new ProdutoPromocao();

                    pp.Id = model.Id;
                    pp.PromocaoId = model.PromocaoId;
                    pp.ProdutoId = model.ProdutoId;



                    if (pp.Id > 0)
                        referenciaServico.servicoProdutoPromocao.Atualizar(pp);
                    else
                        referenciaServico.servicoProdutoPromocao.Cadastrar(pp);

                    return RedirectToAction("index");
                }
                CarregaDropDowns();
                return View(model);

            }
            catch (Exception)
            {
                throw;
            }

        }


        public JsonResult Editar(int id, bool ativa)
        {
            try
            {
                CarregaDropDowns();

                ProdutoPromocao produtoPromocao = new ProdutoPromocao();
                ProdutoPromocaoVM model = new ProdutoPromocaoVM();


                produtoPromocao = referenciaServico.servicoProdutoPromocao.ListarPorId(id);
                //model.Id = produtoPromocao.Id;
                //model.ProdutoId = produtoPromocao.ProdutoId;
                //model.PromocaoId = produtoPromocao.PromocaoId;
                //model.Ativa = produtoPromocao.Ativa;
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                return Json(false);
            }
        }


        public JsonResult Excluir(int id)
        {
            try
            {

                referenciaServico.servicoProdutoPromocao.Excluir(id);


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

            ViewBag.Produto = referenciaServico.servicoProduto.Listar();
        }
    }
}