using SW.Domain.Entity;
using System.Data.Entity.ModelConfiguration;

namespace SW.Infra.Mappings
{
    public class ProdutoMap : EntityTypeConfiguration<Produto>
    {
        public ProdutoMap()
        {
            ToTable("Produto");
            HasKey(x => x.Id);
            Property(x => x.Nome).HasMaxLength(60).IsRequired();
            Property(x => x.Preco).IsRequired();
            Property(x => x.DataCadastro).IsRequired();
            
        }
    }
}
