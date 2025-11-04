using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Models.Entities;
using personapi_dotnet.Repositories;

namespace personapi_dotnet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonasController : ControllerBase
    {
        private readonly IPersonRepository _repo;

        public PersonasController(IPersonRepository repo)
        {
            _repo = repo;
        }

        /// <summary>Lista todas las personas</summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Persona>>> GetAll()
        {
            var list = await _repo.GetAllAsync();
            return Ok(list);
        }

        /// <summary>Obtiene una persona por cédula</summary>
        [HttpGet("{cc:long}")]
        public async Task<ActionResult<Persona>> Get(long cc)
        {
            var p = await _repo.GetByIdAsync(cc);
            if (p == null) return NotFound();
            return Ok(p);
        }

        /// <summary>Crear persona</summary>
        [HttpPost]
        public async Task<ActionResult<Persona>> Create(Persona persona)
        {
            var created = await _repo.CreateAsync(persona);
            return CreatedAtAction(nameof(Get), new { cc = created.Cc }, created);
        }

        /// <summary>Actualizar persona</summary>
        [HttpPut("{cc:long}")]
        public async Task<IActionResult> Update(long cc, Persona persona)
        {
            if (cc != persona.Cc) return BadRequest("La llave no coincide");
            var ok = await _repo.UpdateAsync(persona);
            if (!ok) return NotFound();
            return NoContent();
        }

        /// <summary>Eliminar persona</summary>
        [HttpDelete("{cc:long}")]
        public async Task<IActionResult> Delete(long cc)
        {
            var ok = await _repo.DeleteAsync(cc);
            if (!ok) return NotFound();
            return NoContent();
        }

        /// <summary>Conteo total</summary>
        [HttpGet("count")]
        public async Task<ActionResult<int>> Count()
        {
            var c = await _repo.CountAsync();
            return Ok(c);
        }
    }
}
