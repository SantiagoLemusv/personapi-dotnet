using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Models.Entities;
using personapi_dotnet.Repositories;
using System.Threading.Tasks;

namespace personapi_dotnet.Controllers
{
    // MVC controller para vistas (no ApiController)
    [Route("Personas")]
    public class PersonasMvcController : Controller
    {
        private readonly IPersonRepository _repo;

        public PersonasMvcController(IPersonRepository repo)
        {
            _repo = repo;
        }

        // GET /Personas
        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var list = await _repo.GetAllAsync();
            return View(list);
        }

        // GET /Personas/Details/111...
        [HttpGet("Details/{cc:long}")]
        public async Task<IActionResult> Details(long cc)
        {
            var p = await _repo.GetByIdAsync(cc);
            if (p == null) return NotFound();
            return View(p);
        }

        // GET /Personas/Create
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST /Personas/Create
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Persona persona)
        {
            if (!ModelState.IsValid) return View(persona);
            await _repo.CreateAsync(persona);
            return RedirectToAction(nameof(Index));
        }

        // GET /Personas/Edit/111...
        [HttpGet("Edit/{cc:long}")]
        public async Task<IActionResult> Edit(long cc)
        {
            var p = await _repo.GetByIdAsync(cc);
            if (p == null) return NotFound();
            return View(p);
        }

        // POST /Personas/Edit/111...
        [HttpPost("Edit/{cc:long}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long cc, Persona persona)
        {
            if (cc != persona.Cc) return BadRequest();
            if (!ModelState.IsValid) return View(persona);
            var ok = await _repo.UpdateAsync(persona);
            if (!ok) return NotFound();
            return RedirectToAction(nameof(Index));
        }

        // GET /Personas/Delete/111...
        [HttpGet("Delete/{cc:long}")]
        public async Task<IActionResult> Delete(long cc)
        {
            var p = await _repo.GetByIdAsync(cc);
            if (p == null) return NotFound();
            return View(p);
        }

        // POST /Personas/Delete/111...
        [HttpPost("Delete/{cc:long}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long cc)
        {
            var ok = await _repo.DeleteAsync(cc);
            if (!ok) return NotFound();
            return RedirectToAction(nameof(Index));
        }
    }
}
