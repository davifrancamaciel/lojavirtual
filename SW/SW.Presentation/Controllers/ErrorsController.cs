using System;
using System.Web.Mvc;

namespace SW.Presentation.Controllers
{
    public class ErrorsController : Controller
    {
        // GET: Errors
        public ActionResult Http404(Exception exception)
        {
            Response.StatusCode = 404;
            Response.ContentType = "text/html";
            return View(exception);
        }

        public ActionResult Http500(Exception exception)
        {
            Response.StatusCode = 500;
            Response.ContentType = "text/html";
            return View(exception);
        }
    }
}