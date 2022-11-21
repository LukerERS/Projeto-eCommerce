using System;
using System.Collections.Generic;

namespace Ecommerce.Models
{
    public class Carrinho
    {
        public int CarrinhoId{get; set;}
        public Cliente Cliente{get;set;}
        public List<ItemCarrinho> Itens{get;set;}
    }
}