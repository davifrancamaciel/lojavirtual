using SW.Domain.Entity;
using System.Data.Entity.ModelConfiguration;

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
