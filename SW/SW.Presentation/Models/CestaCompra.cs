using SW.Presentation.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace SW.Presentation.Models
{
    public class CestaCompra
    {

        public List<ItemCesta> Itens { get; set; }

        public double Total
        {
            get
            {
                return Itens.Sum(i => i.ValorTotal);
            }
        }

        //Métodos da Cesta de Compras
        public void AddItem(ItemCesta item) //adicionar um item na cesta
        {
            bool itemExistente = false;
            foreach (ItemCesta i in Itens)
            {
                if (i.Produto.Id == item.Produto.Id)
                {
                    AumentarQuantidade(item.Produto.Id);
                    itemExistente = true;
                    break;
                }
            }

            if (!itemExistente) //se não existir o item
                Itens.Add(item); //adicionar na cesta
        }

        public void AumentarQuantidade(int Id)
        {
            Itens.ForEach(i => { if (i.Produto.Id == Id) i.Quantidade++; });
        }

        public void ReduzirQuantidade(int Id)
        {
            Itens.ForEach(i => { if (i.Produto.Id == Id) i.Quantidade--; });
        }

        public void Remover(int Id)
        {
            Itens.RemoveAll(i => i.Produto.Id == Id);
        }

    }
}