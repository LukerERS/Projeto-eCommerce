using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class CarrinhoItem
    {
        public CarrinhoItem() => CriadoEm = DateTime.Now; 

        [Key()]
        public int Id {get; set;}
        public Produto Produto { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade {get;set;}
        public double Preco {get; set;}
        public double Total {get; set;}
        public int CarrinhoId {get; set; }
        public DateTime CriadoEm {get; set;}

    }
}