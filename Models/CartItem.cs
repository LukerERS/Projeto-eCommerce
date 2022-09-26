using System;

//modelo do produto adicionado no carrinho de compras
namespace Ecommerce.Models 
{
    public class CartItem 
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }
        
    }
}