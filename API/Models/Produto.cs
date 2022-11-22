using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace API.Models 
{
    public class Produto 
    {   
        [Key()]
        public int Id { get; set; }

        [ForeignKey("Categoria")]
        public int CategoriaId {get;set;}
        public virtual Categoria Categoria {get; set;}
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; } 
    }
}