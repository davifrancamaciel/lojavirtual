using SW.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW.Infra.Mappings
{
    public class TipoDescontoMap : EntityTypeConfiguration<TipoDesconto>
    {
        public TipoDescontoMap()
        {
            ToTable("TipoDesconto");
            HasKey(x => x.Id);
            Property(x => x.Desconto).HasMaxLength(60).IsRequired();
            
        }
    }
}
