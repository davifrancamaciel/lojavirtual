using SW.Domain.Entity;
using SW.Infra.DataContexts;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
namespace SW.Infra.Repositorio
{
    public static class ProdutoDal
    {
        public static int Cadastrar(Produto produto)
        {
            using (SWDataContext contexto = new SWDataContext())
            {
                contexto.Produtos.Add(produto); //todos os registros...
                contexto.SaveChanges();
            }
            return produto.Id;
        }
        public static int Atualizar(Produto produto)
        {
            using (SWDataContext contexto = new SWDataContext())
            {
                contexto.Entry(produto).State = EntityState.Modified;

                contexto.SaveChanges();
            }
            return produto.Id;
        }
        public static List<Produto> Listar()
        {
            try
            {

                using (SWDataContext contexto = new SWDataContext())
                {

                    var produtoPromocoes = contexto.ProdutosPromocoes
                    .Include(p => p.Promocao)
                    .Include(p => p.Produto)
                    .ToList();

                    var produtos = contexto.Produtos
                        .Include(p => p.ProdutoPromocao)
                        .ToList();

                    List<Produto> lista = new List<Produto>();
                    foreach (var item in produtos)
                    {
                        Produto produto = new Produto();
                        produto.ProdutoPromocao = new ProdutoPromocao();
                        produto.ProdutoPromocao.Promocao = new Promocao();

                        produto.Id = item.Id;
                        produto.Nome = item.Nome;
                        produto.Preco = item.Preco;
                        produto.DataCadastro = item.DataCadastro;
                        
                        var promocao = produtoPromocoes.ToList().Where(x => x.ProdutoId == item.Id).SingleOrDefault();
                        if (promocao != null)
                        {
                            produto.ProdutoPromocao.Id = promocao.Id;
                            produto.ProdutoPromocao.PromocaoId = promocao.PromocaoId;
                            produto.ProdutoPromocao.Ativa = promocao.Ativa;
                            produto.ProdutoPromocao.ProdutoId = promocao.ProdutoId;
                            produto.ProdutoPromocao.Promocao.Titulo = promocao.Promocao.Titulo;
                            produto.ProdutoPromocao.Promocao.Quantidade = promocao.Promocao.Quantidade;
                        }

                        lista.Add(produto);
                    }

                    produtos = lista;

                    return produtos; //todos os registros...
                }
            }
            catch
            {
                throw;
            }
        }
        public static Produto ListarPorId(int id)
        {
            try
            {
                using (SWDataContext contexto = new SWDataContext())
                {
                    return contexto.Produtos.Find(id); //todos os registros...
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
                Produto produto = contexto.Produtos.Find(id);
                contexto.Produtos.Remove(produto);

                contexto.SaveChanges();
            }
        }
    }
}
