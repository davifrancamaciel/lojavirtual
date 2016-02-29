using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SW.Servicos
{
    /// <summary>
    /// Summary description for Produto
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Produto : System.Web.Services.WebService
    {

        [WebMethod]
        public List<SW.Domain.Entity.Produto> Listar()
        {
            try
            {
                return SW.Infra.Repositorio.ProdutoDal.Listar();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [WebMethod]
        public SW.Domain.Entity.Produto ListarPorId(int id)
        {
            try
            {
                return SW.Infra.Repositorio.ProdutoDal.ListarPorId(id);
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
                SW.Infra.Repositorio.ProdutoDal.Excluir(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public int Cadastrar(SW.Domain.Entity.Produto produto)
        {
            try
            {
                return SW.Infra.Repositorio.ProdutoDal.Cadastrar(produto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public int Atualizar(SW.Domain.Entity.Produto produto)
        {
            try
            {
                return SW.Infra.Repositorio.ProdutoDal.Atualizar(produto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
