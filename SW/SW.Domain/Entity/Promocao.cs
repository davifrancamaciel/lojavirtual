using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW.Domain.Entity
{

    public class Promocao
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public double Valor { get; set; }
        public int TipoDescontoId { get; set; }
        public virtual TipoDesconto TipoDesconto { get; set; }
    }
}
