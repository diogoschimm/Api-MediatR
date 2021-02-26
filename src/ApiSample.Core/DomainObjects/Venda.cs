using System;
using System.Collections.Generic;

namespace ApiSample.Core.DomainObjects
{
    public class Venda
    {
        public Venda( )
        {
            this.Data = DateTime.Now;
        }

        public int Id { get; set; }
        public DateTime Data { get; set; }
        public double ValorTotal { get; private set; }

        public ICollection<ItemVenda> Itens { get; private set; }

        public void AdicionarItem(ItemVenda item)
        {
            Itens.Add(item);
        }
    }
}
