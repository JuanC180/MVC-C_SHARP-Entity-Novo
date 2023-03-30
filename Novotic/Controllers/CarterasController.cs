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
    public class CarterasController : Controller
    {
        private readonly novoContext _context;

        public CarterasController(novoContext context)
        {
            _context = context;
        }

        // GET: Carteras
        public async Task<IActionResult> Index(string buscar)
        {
            var usuarios = from cartera in _context.Carteras select cartera;

            

            if (!String.IsNullOrEmpty(buscar)) 
                usuarios = usuarios.Where(s=>s.CodigoCartera.ToString()!.Contains(buscar));

 

            return View(await usuarios.ToListAsync());
            /*
              return _context.Carteras != null ? 
                          View(await _context.Carteras.ToListAsync()) :
                          Problem("Entity set 'novoContext.Carteras'  is null.");
            */
        }

        // GET: Carteras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Carteras == null)
            {
                return NotFound();
            }

            var cartera = await _context.Carteras
                .FirstOrDefaultAsync(m => m.CodigoCartera == id);
            if (cartera == null)
            {
                return NotFound();
            }

            return View(cartera);
        }

        // GET: Carteras/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Carteras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoCartera,FechaCartera,CoutaRestanteCartera,PendienteCartera,EstadoCartera,IdCliente,CodigoVenta")] Cartera cartera)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cartera);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cartera);
        }

        // GET: Carteras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Carteras == null)
            {
                return NotFound();
            }

            var cartera = await _context.Carteras.FindAsync(id);
            if (cartera == null)
            {
                return NotFound();
            }
            return View(cartera);
        }

        // POST: Carteras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodigoCartera,FechaCartera,CoutaRestanteCartera,PendienteCartera,EstadoCartera,IdCliente,CodigoVenta")] Cartera cartera)
        {
            if (id != cartera.CodigoCartera)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cartera);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarteraExists(cartera.CodigoCartera))
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
            return View(cartera);
        }

        // GET: Carteras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Carteras == null)
            {
                return NotFound();
            }

            var cartera = await _context.Carteras
                .FirstOrDefaultAsync(m => m.CodigoCartera == id);
            if (cartera == null)
            {
                return NotFound();
            }

            return View(cartera);
        }

        // POST: Carteras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Carteras == null)
            {
                return Problem("Entity set 'novoContext.Carteras'  is null.");
            }
            var cartera = await _context.Carteras.FindAsync(id);
            if (cartera != null)
            {
                _context.Carteras.Remove(cartera);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarteraExists(int id)
        {
          return (_context.Carteras?.Any(e => e.CodigoCartera == id)).GetValueOrDefault();
        }
    }
}
