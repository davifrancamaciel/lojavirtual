using SW.Presentation.Areas.Administracao.Models;
using SW.Presentation.Helpers;
using SW.Presentation.ServicoPromocao;
using System;
using System.Web.Mvc;

namespace SW.Presentation.Areas.Administracao.Controllers
{
    public class PromocaoController : Controller
    {


        ReferenciaServico referenciaServico;
        public PromocaoController()
        {
            referenciaServico = new ReferenciaServico();
        }
        
        public ActionResult Index()
        {
            var lista = referenciaServico.servicoPromocao.Listar();

            return View(lista);
        }


        public ActionResult Cadastro()
        {
            try
            {
                CarregaTipoDesconto();
            }
            catch (Exception)
            { throw; }

            return View(new PromocaoVM());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastro(PromocaoVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    
                    Promocao promocao = new Promocao();

                    promocao.Id = model.Id;
                    promocao.Titulo = model.Titulo;
                    promocao.Valor = model.Valor;
                    promocao.TipoDescontoId = model.TipoDescontoId;
                    promocao.Quantidade = model.Quantidade;

                    if (promocao.Id > 0)                    
                        referenciaServico.servicoPromocao.Atualizar(promocao);                    
                    else                    
                       referenciaServico.servicoPromocao.Cadastrar(promocao);
                    
                    return RedirectToAction("index");
                }
                CarregaTipoDesconto();
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
                CarregaTipoDesconto();

                Promocao promocao = new Promocao();
                PromocaoVM model = new PromocaoVM();

                promocao = referenciaServico.servicoPromocao.ListarPorId(id);
                model.Id = promocao.Id;
                model.Titulo = promocao.Titulo;
                model.Valor = promocao.Valor;
                model.TipoDescontoId = promocao.TipoDescontoId;
                model.Quantidade = promocao.Quantidade;

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

                referenciaServico.servicoPromocao.Excluir(id);

                return Json(true, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                return Json(false);
            }
        }
        public void CarregaTipoDesconto()
        {

            ViewBag.TipoDesconto = referenciaServico.servicoTipoDesconto.Listar();
        }

    }
}