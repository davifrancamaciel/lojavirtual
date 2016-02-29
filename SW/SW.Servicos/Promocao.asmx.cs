using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SW.Servicos
{
    /// <summary>
    /// Summary description for Promocao
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Promocao : System.Web.Services.WebService
    {

        [WebMethod]
        public List<SW.Domain.Entity.Promocao> Listar()
        {
            try
            {
                return SW.Infra.Repositorio.PromocaoDal.Listar();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [WebMethod]
        public SW.Domain.Entity.Promocao ListarPorId(int id)
        {
            try
            {
                return SW.Infra.Repositorio.PromocaoDal.ListarPorId(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public void Excluir(int id)
        {
            try
            {
                SW.Infra.Repositorio.PromocaoDal.Excluir(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public void Cadastrar(SW.Domain.Entity.Promocao promocao)
        {
            try
            {
                SW.Infra.Repositorio.PromocaoDal.Cadastrar(promocao);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public void Atualizar(SW.Domain.Entity.Promocao promocao)
        {
            try
            {
                SW.Infra.Repositorio.PromocaoDal.Atualizar(promocao);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
