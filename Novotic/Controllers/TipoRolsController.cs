using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Novotic.Models;

namespace Novotic.Controllers
{
    public class TipoRolsController : Controller
    {
        private readonly novoContext _context;

        public TipoRolsController(novoContext context)
        {
            _context = context;
        }

        // GET: TipoRols
        public async Task<IActionResult> Index(string buscar)
        {
            var usuarios = from cliente in _context.TipoRols select cliente;



            if (!String.IsNullOrEmpty(buscar))
                usuarios = usuarios.Where(s => s.IdRol.ToString()!.Contains(buscar));



            return View(await usuarios.ToListAsync());
            /*
              return _context.Carteras != null ? 
                          View(await _context.Carteras.ToListAsync()) :
                          Problem("Entity set 'novoContext.Carteras'  is null.");
            */
        }

        // GET: TipoRols/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TipoRols == null)
            {
                return NotFound();
            }

            var tipoRol = await _context.TipoRols
                .FirstOrDefaultAsync(m => m.IdRol == id);
            if (tipoRol == null)
            {
                return NotFound();
            }

            return View(tipoRol);
        }

        // GET: TipoRols/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoRols/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRol,EstadoRol")] TipoRol tipoRol)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoRol);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoRol);
        }

        // GET: TipoRols/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TipoRols == null)
            {
                return NotFound();
            }

            var tipoRol = await _context.TipoRols.FindAsync(id);
            if (tipoRol == null)
            {
                return NotFound();
            }
            return View(tipoRol);
        }

        // POST: TipoRols/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRol,EstadoRol")] TipoRol tipoRol)
        {
            if (id != tipoRol.IdRol)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoRol);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoRolExists(tipoRol.IdRol))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tipoRol);
        }

        // GET: TipoRols/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TipoRols == null)
            {
                return NotFound();
            }

            var tipoRol = await _context.TipoRols
                .FirstOrDefaultAsync(m => m.IdRol == id);
            if (tipoRol == null)
            {
                return NotFound();
            }

            return View(tipoRol);
        }

        // POST: TipoRols/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TipoRols == null)
            {
                return Problem("Entity set 'novoContext.TipoRols'  is null.");
            }
            var tipoRol = await _context.TipoRols.FindAsync(id);
            if (tipoRol != null)
            {
                _context.TipoRols.Remove(tipoRol);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoRolExists(int id)
        {
          return (_context.TipoRols?.Any(e => e.IdRol == id)).GetValueOrDefault();
        }
    }
}
