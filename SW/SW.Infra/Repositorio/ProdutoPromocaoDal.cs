using SW.Domain.Entity;
using SW.Infra.DataContexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW.Infra.Repositorio
{
    public class ProdutoPromocaoDal
    {
        public static void Cadastrar(ProdutoPromocao produtoPromocao)
        {
            using (SWDataContext contexto = new SWDataContext())
            {
                contexto.ProdutosPromocoes.Add(produtoPromocao); //todos os registros...
                contexto.SaveChanges();
            }
        }
        public static void Atualizar(ProdutoPromocao produtoPromocao)
        {
            using (SWDataContext contexto = new SWDataContext())
            {
                contexto.Entry(produtoPromocao).State = EntityState.Modified;

                contexto.SaveChanges();
            }
        }
        public static List<ProdutoPromocao> Listar()
        {
            try
            {
                using (SWDataContext contexto = new SWDataContext())
                {

                    var produtoPromocoes = contexto.ProdutosPromocoes
                    .Include(p => p.Promocao)
                    .Include(p => p.Produto)
                    .ToList();
                    return produtoPromocoes;
                }
            }

            catch
            {
                throw;
            }
        }
        public static ProdutoPromocao ListarPorId(int id)
        {
            try
            {
                using (SWDataContext contexto = new SWDataContext())
                {
                    var produtoPromocao = contexto.ProdutosPromocoes
                    .Include(p => p.Promocao)
                    .Include(p => p.Produto)
                    .ToList().Where(x=>x.Id==id).FirstOrDefault();
                    
                    return produtoPromocao;
                }
            }
            catch
            {
                throw;
            }
        }
        public static void Excluir(int id)
        {
            using (SWDataContext contexto = new SWDataContext())
            {
                ProdutoPromocao produtoPromocao = contexto.ProdutosPromocoes.Find(id);

                contexto.ProdutosPromocoes.Remove(produtoPromocao);

                contexto.SaveChanges();
            }
        }
        public static void ExcluirPorIdProduto(int id)
        {
            using (SWDataContext contexto = new SWDataContext())
            {
                ProdutoPromocao produtoPromocao = contexto.ProdutosPromocoes.ToList().Where(x => x.ProdutoId == id).FirstOrDefault();

                contexto.ProdutosPromocoes.Remove(produtoPromocao);

                contexto.SaveChanges();
            }
        }
    }
}
