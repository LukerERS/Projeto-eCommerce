using System;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models 
{
    public class Produto 
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public double Preco { get; set; }
        //Relação de Um para Muitos de produtos e categoria.
        public Categoria Categorias {get;set;}
        
    }
}