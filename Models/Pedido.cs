using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System;

//modelo do pedido 
namespace Ecommerce.Models 
{
    public class Pedido 
    {
        public Pedido () => CreatedAt = DateTimeConverter.Now; 

        public int Id { get; set; }

        public double Total { get; set; }

        public List<ItemCarrinho> Produtos { get; set; }

        public DateTime CriadoEm {get; set; }
    }
}