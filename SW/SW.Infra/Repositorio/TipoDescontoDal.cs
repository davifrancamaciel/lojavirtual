using SW.Domain.Entity;
using SW.Infra.DataContexts;
using System.Collections.Generic;
using System.Linq;

namespace SW.Infra.Repositorio
{
    public class TipoDescontoDal
    {
        public static List<TipoDesconto> Listar()
        {
            try
            {
                using (SWDataContext contexto = new SWDataContext())
                {
                    return contexto.TipoDescontos.ToList(); //todos os registros...
                }
            }

            catch
            {
                throw;
            }
        }
    }
}
