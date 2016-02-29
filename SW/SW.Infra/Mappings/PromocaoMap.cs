using SW.Domain.Entity;
using System.Data.Entity.ModelConfiguration;

namespace SW.Infra.Mappings
{
    public class PromocaoMap : EntityTypeConfiguration<Promocao>
    {
        public PromocaoMap()
        {
           
            ToTable("Promocao");
            HasKey(x => x.Id);
            HasRequired(x => x.TipoDesconto).WithMany().HasForeignKey(x=>x.TipoDescontoId);
            Property(x => x.Titulo).HasMaxLength(60).IsRequired();
            Property(x => x.Valor).IsRequired();
            Property(x => x.Quantidade).IsRequired();


            
        }
    }
}
