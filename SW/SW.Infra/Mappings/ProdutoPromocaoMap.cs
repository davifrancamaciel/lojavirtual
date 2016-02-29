using SW.Domain.Entity;
using System.Data.Entity.ModelConfiguration;

namespace SW.Infra.Mappings
{
    public class ProdutoPromocaoMap : EntityTypeConfiguration<ProdutoPromocao>
    {
        public ProdutoPromocaoMap()
        {
            ToTable("ProdutoPromocao");
            HasKey(x => x.Id);
            HasRequired(x => x.Promocao).WithMany().HasForeignKey(x => x.PromocaoId);
            HasRequired(x => x.Produto).WithMany().HasForeignKey(x => x.ProdutoId);
            Property(x => x.Ativa).IsRequired();            
        }
    }
}
