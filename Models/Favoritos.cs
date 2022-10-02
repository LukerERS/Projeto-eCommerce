using System.Collections;
using System;
using System.Collections.Generic;

namespace Ecommerce.Models 
{
    public class Favoritos
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public Produto ProdutoFavoritado { get; set; }
    }
}