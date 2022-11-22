using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using API.Models; 

namespace API.Models {
    public class Carrinho
    {
        public Carrinho() => CriadoEm = DateTime.Now; 
        [Key()]
        public String Id{get; set;}

        [ForeignKey("Cliente")]
        public int ClienteId {get; set; }
        public Cliente Cliente{get;set;}
        public List<CarrinhoItem> Itens{get;set;}
        public int Total {get; set;}
        public DateTime CriadoEm {get; set;}
    }
}