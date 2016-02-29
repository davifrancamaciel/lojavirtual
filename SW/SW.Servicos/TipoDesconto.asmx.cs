using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SW.Servicos
{
    /// <summary>
    /// Summary description for TipoDesconto
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class TipoDesconto : System.Web.Services.WebService
    {

        [WebMethod]
        public List<SW.Domain.Entity.TipoDesconto> Listar()
        {
            try
            {
                return SW.Infra.Repositorio.TipoDescontoDal.Listar();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
