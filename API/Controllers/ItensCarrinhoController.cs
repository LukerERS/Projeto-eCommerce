using System;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers 
{
    [ApiController]
    [Route("api/item")]
    public class ItensCarrinhoController : ControllerBase {
        private readonly DataContext _context; 
        public ItensCarrinhoController(DataContext context) {
            _context = context; 
        }

        //POST: api/item/criar
        [HttpPost]
        [Route("criar")]
        public IActionResult Criar([FromBody] CarrinhoItem item) {
            Produto produto = _context.Produtos.Find(item.ProdutoId);
            item.Produto = produto; 
            _context.CarrinhoItems.Add(item);  
            _context.SaveChanges(); 
            return Created("", item); 
        }

        //DELETE: /api/item/deletar/id
        [HttpDelete]
        [Route("deletar/{id}")]
        public IActionResult Deletar([FromRoute] int id) {
            CarrinhoItem carrinhoItem = _context.CarrinhoItems.Find(id); 
            if(carrinhoItem != null) {
                _context.CarrinhoItems.Remove(carrinhoItem); 
                _context.SaveChanges();
                return Ok(carrinhoItem); 
            } else {
                return NotFound(); 
            }
        }

    }
}