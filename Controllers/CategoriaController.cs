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
        //DELETE: /api/categoria/deletar/{id}
        [HttpDelete]
        [Route("deletar/{id}")]
        public IActionResult Deletar([FromRoute] int id)
        {
            Categoria categoria = _contex.Categorias.Find(id);
            if(categoria != null)
            {
                _contex.Categorias.Remove(categoria);
                _contex.SaveChanges();
                return Ok(categoria);
            }
            return NotFound();
        }
        // //PATCH: /api/categoria/alterar
        [HttpPatch]
        [Route("alterar")]
        public IActionResult Alterar([FromBody] Categoria categoria)
        {   
            try
            {
                _contex.Categorias.Update(categoria);
                _contex.SaveChanges();
                return Ok(categoria);
            }
            catch
            {
                return NotFound();
            }
        }
    }
    
}