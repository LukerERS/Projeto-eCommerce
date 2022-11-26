using System.Collections.Generic;
using System.Linq;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/cliente")]
    public class ClienteController : ControllerBase
    {
        private readonly DataContext _context;
        public ClienteController(DataContext context) =>
        _context = context;

        // POST: /api/cliente/cadastrar
        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar([FromBody] Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
            return Created("", cliente);
        }

        // GET: /api/cliente/buscar/{id}
        [HttpGet]
        [Route("buscar/{id}")]
        public IActionResult Buscar([FromRoute] int id)
        {
            Cliente cliente = _context.Clientes.Find(id);
            return cliente != null ? Ok(cliente) : NotFound();
        }

        // GET: /api/cliente/listar
        [HttpGet]
        [Route("listar")]
        public IActionResult Listar() => Ok(_context.Clientes.ToList());

        // DELETE: /api/cliente/deletar/{id}
        [HttpDelete]
        [Route("deletar/{id}")]
        public IActionResult Deletar([FromRoute] int id)
        {
            Cliente cliente = _context.Clientes.Find(id);
            if(cliente !=null)
            {
                _context.Clientes.Remove(cliente);
                _context.SaveChanges();
                return Ok(cliente);
            }
            return NotFound();
        }

        // PATCH: /api/cliente/alterar
        [HttpPatch]
        [Route("alterar")]
        public IActionResult Alterar([FromBody] Cliente cliente)
        {
            try
            {
                _context.Clientes.Update(cliente);
                _context.SaveChanges();
                return Ok(cliente);
            }
            catch 
            {
               return NotFound();
            }
        }        


    }
    
}