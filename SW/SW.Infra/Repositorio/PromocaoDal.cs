using SW.Domain.Entity;
using SW.Infra.DataContexts;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SW.Infra.Repositorio
{
    public static class PromocaoDal
    {
        public static void Cadastrar(Promocao promocao)
        {
            using (SWDataContext contexto = new SWDataContext())
            {
                contexto.Promocoes.Add(promocao); //todos os registros...
                contexto.SaveChanges();
            }
        }
        public static void Atualizar(Promocao promocao)
        {
            using (SWDataContext contexto = new SWDataContext())
            {
                contexto.Entry(promocao).State = EntityState.Modified;

                contexto.SaveChanges();
            }
        }
        public static List<Promocao> Listar()
        {
            try
            {
                using (SWDataContext contexto = new SWDataContext())
                {

                    var promocoes = contexto.Promocoes
                    .Include(p => p.TipoDesconto)
                    .ToList();
                    return promocoes;
                }
            }

            catch
            {
                throw;
            }
        }
        public static Promocao ListarPorId(int id)
        {
            try
            {
                using (SWDataContext contexto = new SWDataContext())
                {
                    return contexto.Promocoes.Find(id); //todos os registros...
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
                Promocao promocao = contexto.Promocoes.Find(id);

                contexto.Promocoes.Remove(promocao);

                contexto.SaveChanges();
            }
        }
    }
}
