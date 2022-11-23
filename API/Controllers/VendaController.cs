using System.Security.AccessControl;
using System;
using API.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers
{
    [ApiController]
    [Route("api/venda")]
    public class VendaController : ControllerBase {
        private readonly DataContext _context; 
        public VendaController(DataContext context) {
            _context = context; 
        }

        // POST: api/venda/criar
        [HttpPost]
        [Route("criar")]
        public IActionResult Criar([FromBody] Venda venda) {
            Cliente cliente = _context.Clientes.Find(venda.ClienteId); 
            venda.Cliente = cliente; 
            List<CarrinhoItem> itensDB = _context.CarrinhoItems.ToList();
            List<CarrinhoItem> itens = new List<CarrinhoItem>(); 
            double total = 0.0; 

            foreach (var item in itensDB)
            {
                Produto produto = _context.Produtos.Find(item.ProdutoId);
                    item.Produto = produto; 
                    double itemTotal = item.Quantidade * item.Preco; 
                    total += itemTotal; 

                    itens.Add(item);
            }
            venda.Total = total; 
            _context.Vendas.Add(venda); 
            _context.SaveChanges(); 
            return Created("", venda); 
        }
    }
}