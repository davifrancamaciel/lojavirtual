using SW.Domain.Entity;
using SW.Infra.Mappings;
using System;
using System.Configuration;
using System.Data.Entity;

namespace SW.Infra.DataContexts
{
    public class SWDataContext : DbContext
    {
        public SWDataContext()
            : base(ConfigurationManager.ConnectionStrings["SWConexao"].ConnectionString)
        {
            Database.SetInitializer<SWDataContext>(new SWDataContextInitializer());
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Promocao> Promocoes { get; set; }
        public DbSet<TipoDesconto> TipoDescontos { get; set; }
        public DbSet<ProdutoPromocao> ProdutosPromocoes { get; set; }

        // reescrever o metodo OnModelCreating para criar o banco
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // apontando para confuguracao de modelo do banco
            modelBuilder.Configurations.Add(new TipoDescontoMap());
            modelBuilder.Configurations.Add(new PromocaoMap());
            modelBuilder.Configurations.Add(new ProdutoMap());
            modelBuilder.Configurations.Add(new ProdutoPromocaoMap());

            base.OnModelCreating(modelBuilder);
        }
    }

    // este metodo é executado se hover mudancas na model
    public class SWDataContextInitializer : DropCreateDatabaseIfModelChanges<SWDataContext>
    {
        protected override void Seed(SWDataContext context)
        {
            context.TipoDescontos.Add(new TipoDesconto { Id = 1, Desconto = "Porcentagem" });
            context.TipoDescontos.Add(new TipoDesconto { Id = 2, Desconto = "Valor Final" });


            context.SaveChanges();

            context.Promocoes.Add(new Promocao { Id = 1, Titulo = "3 por 10 reais", Valor = 10, TipoDescontoId = 2, Quantidade = 3 });
            context.Promocoes.Add(new Promocao { Id = 2, Titulo = "Pague 1 e Leve 2", Valor = 50, TipoDescontoId = 1, Quantidade = 2 });
            context.Promocoes.Add(new Promocao { Id = 3, Titulo = "Pague 3 e Leve 5", Valor = 40, TipoDescontoId = 1, Quantidade = 5 });

            context.SaveChanges();

            context.Produtos.Add(new Produto { Id = 1, Preco = 6.59, Nome = "Shampoo Garnier Fructis", DataCadastro = DateTime.Now });
            context.Produtos.Add(new Produto { Id = 2, Preco = 4, Nome = "Shampoo Seda", DataCadastro = DateTime.Now });
            context.Produtos.Add(new Produto { Id = 3, Preco = 3.95, Nome = "Creme de Barbear Bozzano Hidratação 65g", DataCadastro = DateTime.Now });
            context.Produtos.Add(new Produto { Id = 4, Preco = 9.90, Nome = "Creme de Barbear Bozzano Mentolado", DataCadastro = DateTime.Now });
            context.Produtos.Add(new Produto { Id = 5, Preco = 14.90, Nome = "Creme de Barbear Bozzano Pele Sensível", DataCadastro = DateTime.Now });
            context.Produtos.Add(new Produto { Id = 6, Preco = 29.90, Nome = "Carga para Aparelho de Barbear Gillette Mach3 Sensitive", DataCadastro = DateTime.Now });
            context.Produtos.Add(new Produto { Id = 7, Preco = 15.50, Nome = "Aparelho de Barbear Gillette Mach3 Regular", DataCadastro = DateTime.Now });

            context.SaveChanges();


            context.ProdutosPromocoes.Add(new ProdutoPromocao { Id = 1, ProdutoId = 1, PromocaoId = 2, Ativa = true });
            context.ProdutosPromocoes.Add(new ProdutoPromocao { Id = 2, ProdutoId = 2, PromocaoId = 1, Ativa = true });
            context.SaveChanges();

            base.Seed(context);
        }

    }
}
