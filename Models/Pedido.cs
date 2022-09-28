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

        public double PrecoTotal { get; set; }

        public List<CartItem> Produtos { get; set; }

        public DateTime CriadoEm {get; set; }
    }
}