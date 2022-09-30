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
            Categoria categoria = _contex.Categorias.Find(produto.Categorias.Id);
            produto.Categorias = categoria;
            _contex.Produtos.Add(produto);
            _contex.SaveChanges();
            return Created("", produto);
        }
        //GET: /api/produto/buscarCategoria/{id}
    }
}