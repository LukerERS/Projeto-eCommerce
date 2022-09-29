using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System;

//modelo do pedido 
namespace Ecommerce.Models 
{
    public class Pedido 
    {
        public Pedido () => CriadoEm = DateTime.Now; 

        public int Id { get; set; }

        //Relacionamento de Um para muitos de Pedido e ItemCarrinho
        public ICollection<ItemCarrinho> ItensCarrinho {get;set;}
        public double Total { get; set; }


        public DateTime CriadoEm {get; set; }
    }
}