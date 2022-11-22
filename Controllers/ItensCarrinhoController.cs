using System;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers 
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
        public IActionResult Criar([FromBody] ItemCarrinho item) {
            if(String.IsNullOrEmpty(item.CarrinhoId)) {
                item.CarrinhoId = Guid.NewGuid().ToString(); 
            } 
            item.Produto = _context.Produtos.Find(item.ProdutoId); 
            _context.ItensCarrinho.Add(item); 
            _context.SaveChanges(); 
            return Created("", item); 
        }

    }
}