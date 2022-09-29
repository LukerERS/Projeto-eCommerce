using System;

//modelo do produto adicionado no carrinho de compras
namespace Ecommerce.Models 
{
    public class ItemCarrinho 
    {
        public int Id { get; set; }
        //Relacionamento de Um para um de ItemCarrinho com Produto.
        public int? ProdutoId { get; set; }

        public string Nome { get; set; }

        public int Quantidade { get; set; }

        public double Preco { get; set; }
        
    }
}