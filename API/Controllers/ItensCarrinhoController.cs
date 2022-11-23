using System.Runtime.InteropServices;
using System.Text;
using System.Security.AccessControl;
using System;
using API.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace API.Controllers 
{
    [ApiController]
    [Route("api/item")]
    public class ItensCarrinhoController : ControllerBase {
        private readonly DataContext _context; 
        public ItensCarrinhoController(DataContext context) {
            _context = context; 
        }

        //GET: api/item/Carinho
        [HttpGet]
        [Route("carrinho/{carrinhoId}")]
        public IActionResult Carrinho([FromRoute] string carrinhoId) {
            return Ok(_context.CarrinhoItems.
            Include(item => item.Produto.Categoria).
            Where(item => item.CarrinhoId == carrinhoId).ToList());
        }

        //POST: api/item/criar
        [HttpPost]
        [Route("criar")]
        public IActionResult Criar([FromBody] CarrinhoItem item) {
            if(String.IsNullOrEmpty(item.CarrinhoId)) 
            {
                item.CarrinhoId = Guid.NewGuid().ToString(); 
            }

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