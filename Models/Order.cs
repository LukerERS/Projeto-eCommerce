using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System;

//modelo do pedido 
namespace Ecommerce.Models 
{
    public class Order 
    {
        public Order () => CreatedAt = DateTimeConverter.Now; 

        public int Id { get; set; }

        public double TotalPrice { get; set; }

        public List<CartItem> products { get; set; }

        public DateTime CreatedAt {get; set; }
    }
}