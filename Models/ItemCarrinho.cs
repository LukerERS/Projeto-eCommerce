using System;

//modelo do produto adicionado no carrinho de compras
namespace Ecommerce.Models 
{
    public class ItemCarrinho 
    {
        public int Id { get; set; }

        public int IdProduto { get; set; }

        public string Nome { get; set; }

        public int Quantidade { get; set; }

        public double Preco { get; set; }
        
    }
}