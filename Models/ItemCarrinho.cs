using System;

namespace Ecommerce.Models
{
    public class ItemCarrinho
    {
        public int ItemCarrinhoId{get; set;}
        public Produto produto{get;set;}
        public int ProdutoId{get;set;}
        public int Quantidade{get;set;}
        public int CarrinhoId{get;set;} 
    }
}