using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Ecommerce.Models
{
    public class Categoria
    {
        [Key()]
        public int Id {get;set;}
        public string Tipo {get;set;}
    }
}