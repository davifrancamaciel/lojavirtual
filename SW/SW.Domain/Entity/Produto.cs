using System;

namespace SW.Domain.Entity
{
    public class Produto
    {
       
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public DateTime DataCadastro { get; set; }

        public virtual ProdutoPromocao ProdutoPromocao { get; set; }

    }
}
