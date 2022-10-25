using System.Collections.Generic;
using System.Linq;
using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;
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
            Categoria categoria = _contex.Categorias.Find(produto.CategoriaID);
            produto.Categoria = categoria;
            _contex.Produtos.Add(produto);
            _contex.SaveChanges();
            return Created("", produto);
        }
        //GET: /api/produto/listar
        [HttpGet]
        [Route("listar")]
        public IActionResult listar()
        {
            List<Produto> produtos = 
                _contex.Produtos.Include(f => f.Categoria).ToList();
            if(produtos.Count == 0) return NotFound();
            return Ok(produtos);
        }
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
            try
            {
                Categoria categoria = _contex.Categorias.Find(produto.CategoriaID);
                if(categoria!= null)
                {
                    produto.Categoria = categoria;
                    _contex.Produtos.Update(produto);
                    _contex.SaveChanges();
                    return Ok(produto);
                }else{return NotFound();}
            }
            catch 
            {
               return NotFound();
            }
        }
    }
}