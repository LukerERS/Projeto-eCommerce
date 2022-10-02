using System.Linq;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Ecommerce.Controllers {
    [ApiController]
    [Route("api/favoritos")]
    public class FavoritosController : ControllerBase {
        private readonly DataContext _context; 

        public FavoritosController(DataContext context) => _context = context; 

        [HttpPost]
        [Route("cadastrar")] 
        public IActionResult Cadastrar([FromBody] Favoritos favorito) {
            Produto produto = _context.Produtos.Find(favorito.ProdutoFavoritado.Id);
            favorito.ProdutoFavoritado = produto; 

            _context.Favoritos.Add(favorito);
            _context.SaveChanges(); 
            return Created("", favorito); 
        }

        [HttpDelete]
        [Route("deletar/{id}")]
        public IActionResult Deletar([FromRoute] int id) {
            Favoritos favorito = _context.Favoritos.Find(id); 

            if(favorito != null) {
                _context.Favoritos.Remove(favorito);
                _context.SaveChanges();
                return Ok(favorito); 
            } else {
                return NotFound(); 
            }
        }

        [HttpGet]
        [Route("listar")]
        public IActionResult Listar() {
            
            return Ok(_context.Favoritos); 
        }
    }
}