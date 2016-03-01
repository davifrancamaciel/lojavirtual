using SW.Presentation.Helpers;
using System;
using System.Web.Mvc;

namespace SW.Presentation.Areas.Administracao.Controllers
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
        
    }
}