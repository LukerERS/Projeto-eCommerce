using System.Linq;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    [ApiController]
    [Route("api/categoria")]
    public class CategoriaController : ControllerBase
    {
        private readonly DataContext _contex;
        public CategoriaController(DataContext context) => _contex = context;
        //POST: /api/categoria/cadastrar
        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar([FromBody] Categoria categoria)
        {
            _contex.Categorias.Add(categoria);
            _contex.SaveChanges();
            return Created("", categoria);
        }

        //GET: /api/categoria/listar
        [HttpGet]
        [Route("listar")]
        public IActionResult Listar() => Ok(_contex.Categorias.ToList());
    }
}