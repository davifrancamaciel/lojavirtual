﻿using SW.Web.ServicoProduto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using SW.Web.Helpers;

namespace SW.Web.Controllers
{
    public class ProdutosController : Controller
    {
        ReferenciaServico referenciaServico;
        public ProdutosController()
        {
            referenciaServico = new ReferenciaServico();
        }
        public ActionResult Index(string q, int? pagina, int? pt)
        {
            if (q == null)
                q = "";
            int paginaTamanho = (pt ?? 6);
            int paginaNumero = (pagina ?? 1);
            
            
            List<Produto> lista = new List<Produto>();
            lista = referenciaServico.servicoProduto.Listar().ToList();


            var e = this.RouteData.Values;            
            string actionName = (string)e["action"];

            ViewBag.Action = actionName;
            ViewBag.Pagina = pagina;
            ViewBag.PaginaTamanho = pt;

            ViewBag.Query = q;

            return View(lista.ToPagedList(paginaNumero, paginaTamanho));
        }
    }
}