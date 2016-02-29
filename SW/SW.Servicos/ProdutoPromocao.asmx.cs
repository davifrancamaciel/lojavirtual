using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SW.Servicos
{
    /// <summary>
    /// Summary description for ProdutoPromocao
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ProdutoPromocao : System.Web.Services.WebService
    {

        [WebMethod]
        public List<SW.Domain.Entity.ProdutoPromocao> Listar()
        {
            try
            {
                return SW.Infra.Repositorio.ProdutoPromocaoDal.Listar();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [WebMethod]
        public SW.Domain.Entity.ProdutoPromocao ListarPorId(int id)
        {
            try
            {
                return SW.Infra.Repositorio.ProdutoPromocaoDal.ListarPorId(id);
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
                SW.Infra.Repositorio.ProdutoPromocaoDal.Excluir(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [WebMethod]
        public void ExcluirPorIdProduto(int id)
        {
            try
            {
                SW.Infra.Repositorio.ProdutoPromocaoDal.ExcluirPorIdProduto(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public void Cadastrar(SW.Domain.Entity.ProdutoPromocao produtoPromocao)
        {
            try
            {
                SW.Infra.Repositorio.ProdutoPromocaoDal.Cadastrar(produtoPromocao);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public void Atualizar(SW.Domain.Entity.ProdutoPromocao produtoPromocao)
        {
            try
            {
                SW.Infra.Repositorio.ProdutoPromocaoDal.Atualizar(produtoPromocao);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
