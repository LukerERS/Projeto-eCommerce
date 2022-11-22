using System.Security.AccessControl;
using System;
using API.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace API.Controllers 
{
    [ApiController]
    [Route("api/item")]
    public class ItensCarrinhoController : ControllerBase {
        private readonly DataContext _context; 
        public ItensCarrinhoController(DataContext context) {
            _context = context; 
        }

        //GET: api/item/listar
        [HttpGet]
        [Route("listar")]
        public IActionResult Listar() {
            List<CarrinhoItem> itens = new List<CarrinhoItem>(); 
            List<CarrinhoItem> itensDB = _context.CarrinhoItems.ToList(); 

            foreach (var item in itensDB)
            {
             Produto produto = _context.Produtos.Find(item.ProdutoId);
             item.Produto = produto; 

             itens.Add(item);    
            }

            if(itensDB == null) {
                return NotFound();
            } else {
                return Ok(itens); 
            }
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