using Microsoft.AspNetCore.Mvc;
using Ecommerce.Models;
using System.Linq;

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
            _contex.Produtos.Add(produto);
            _contex.SaveChanges();
            return Created("", produto);
        }

        //GET: /api/produto/buscarCategoria/{id}
        [HttpGet]
        [Route("buscarCategoria/{id}")]
        public IActionResult BuscarCategoria([FromRoute] int id)
        {
            Produto produto = _contex.Produtos.FirstOrDefault(p => p.Categoria.Id.Equals(id));
            return produto != null ? Ok(produto) : NotFound();
        }
    }
}