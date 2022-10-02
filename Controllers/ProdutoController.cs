using System.Collections.Generic;
using System.Linq;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    [ApiController]
    [Route("api/produto")]
    public class ProdutoController : ControllerBase
    {
        private readonly DataContext _contex;
        public ProdutoController(DataContext context) => _contex = context;

        //POST: /api/produto/cadastrar
        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar([FromBody] Produto produto)
        {
            Categoria categoria = _contex.Categorias.Find(produto.Categorias.Id);
            produto.Categorias = categoria;
            _contex.Produtos.Add(produto);
            _contex.SaveChanges();
            return Created("", produto);
        }
        //GET: /api/produto/listar
        [HttpGet]
        [Route("listar")]
        public IActionResult listar() => Ok(_contex.Produtos.ToList());
        //DELETE: /api/produto/deletar/{id}
        [HttpDelete]
        [Route("deletar/{id}")]
        public IActionResult Deletar([FromRoute] int id)
        {
            Produto produto = _contex.Produtos.Find(id);
            if(produto != null)
            {
                _contex.Produtos.Remove(produto);
                _contex.SaveChanges();
                return Ok(produto);
            }
            return NotFound();
        }
        //PATCH: /api/produto/alterar
        [HttpPatch]
        [Route("alterar")]
        public IActionResult Alterar([FromBody] Produto produto)
        {   
            Categoria categoria = _contex.Categorias.Find(produto.Categorias.Id);
            produto.Categorias = categoria;
            try
            {
                _contex.Produtos.Update(produto);
                _contex.SaveChanges();
                return Ok(produto);
            }
            catch
            {
                return NotFound();
            }
        }
    }
}