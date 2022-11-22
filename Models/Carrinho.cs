using System;
using System.Collections.Generic;

namespace Ecommerce.Models
{
    public class Carrinho
    {
        public Carrinho() => CriadoEm = DateTime.Now; 
        public String CarrinhoId{get; set;}
        public Cliente Cliente{get;set;}
        public List<ItemCarrinho> Itens{get;set;}
        public int Total {get; set;}
        public DateTime CriadoEm {get; set;}
    }
}