using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Models
{
    public class CarrinhoItem
    {
        public CarrinhoItem() => CriadoEm = DateTime.Now; 

        [Key()]
        public int Id {get; set;}

        [ForeignKey("Produto")]
        public int ProdutoId { get; set; }
        public virtual Produto Produto { get; set; }
        public int Quantidade {get;set;}
        public double Preco {get; set;}

        public DateTime CriadoEm {get; set;}

    }
}