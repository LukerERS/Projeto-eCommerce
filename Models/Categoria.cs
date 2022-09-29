using System.Collections.Generic;

namespace Ecommerce.Models
{
    public class Categoria
    {
        public int Id {get;set;}
        public string Tipo {get;set;}

        public ICollection<Produto> Produtos {get;set;}
    }
}