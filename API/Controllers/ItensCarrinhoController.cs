using System.Runtime.CompilerServices;
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

    
        [HttpGet]
        [Route("carrinho/{carrinhoId}")]
        public IActionResult Carrinho([FromRoute] int carrinhoId) {
            List<CarrinhoItem> itens = new List<CarrinhoItem>(); 
            List<CarrinhoItem> itensDB = _context.CarrinhoItems.ToList(); 

            foreach (var item in itensDB)
            {
                if(item.CarrinhoId == carrinhoId) {
                    item.Produto = _context.Produtos.Find(item.ProdutoId); 
                    itens.Add(item); 
                }
                
            }
            return Ok(itens); 
        }

        //POST: api/item/criar
        [HttpPost]
        [Route("criar")]
        public IActionResult Criar([FromBody] CarrinhoItem item) {
            Produto produto = _context.Produtos.Find(item.ProdutoId);
            item.Produto = produto; 
            item.Preco = produto.Preco; 
            item.Total = item.Quantidade * item.Preco; 
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