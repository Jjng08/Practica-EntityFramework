using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClaseNosePeroClase.Models;
using Microsoft.EntityFrameworkCore;

namespace ClaseNosePeroClase.Controllers
{
    public class bddController : Controller
    {
        private readonly BtallerProgramacionContext _context;

        public bddController(BtallerProgramacionContext context)
        {
            _context = context;
        }

        // Esta es para crear un nuevo contacto
        [HttpGet]
        public IActionResult Form()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Form(Contacto contacto)
        {
            if (ModelState.IsValid)
            {
                await _context.Contactos.AddAsync(contacto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(vista));
            }
            return RedirectToAction(nameof(vista));
        }
        [HttpGet]
        public async Task<IActionResult> vista()
        {
            List<Contacto> contacto = await _context.Contactos.ToListAsync();
            return View(contacto);
        }
    }
}
