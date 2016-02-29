using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW.Domain.Entity
{
    public class ProdutoPromocao
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public int PromocaoId { get; set; }
        public bool Ativa { get; set; }
        public Promocao Promocao { get; set; }
        public virtual Produto Produto { get; set; }
    }
}
