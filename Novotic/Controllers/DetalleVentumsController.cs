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
    public class DetalleVentumsController : Controller
    {
        private readonly novoContext _context;

        public DetalleVentumsController(novoContext context)
        {
            _context = context;
        }

        // GET: DetalleVentums
        public async Task<IActionResult> Index(string buscar)
        {
            var usuarios = from cliente in _context.DetalleVenta select cliente;

            if (!String.IsNullOrEmpty(buscar))
                usuarios = usuarios.Where(s => s.CodigoDetalleVenta.ToString()!.Contains(buscar));

            return View(await usuarios.ToListAsync());

            /*
              return _context.Carteras != null ? 
                          View(await _context.Carteras.ToListAsync()) :
                          Problem("Entity set 'novoContext.Carteras'  is null.");
            */
        }

        // GET: DetalleVentums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DetalleVenta == null)
            {
                return NotFound();
            }

            var detalleVentum = await _context.DetalleVenta
                .FirstOrDefaultAsync(m => m.CodigoDetalleVenta == id);
            if (detalleVentum == null)
            {
                return NotFound();
            }

            return View(detalleVentum);
        }

        // GET: DetalleVentums/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DetalleVentums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoDetalleVenta,PrecioUnitarioDetalleVenta,CantidadDetalleVenta,ValorTotalDetalleVenta,SubtotalDetalleVenta,CodigoVenta,CodigoProducto")] DetalleVentum detalleVentum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detalleVentum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(detalleVentum);
        }

        // GET: DetalleVentums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DetalleVenta == null)
            {
                return NotFound();
            }

            var detalleVentum = await _context.DetalleVenta.FindAsync(id);
            if (detalleVentum == null)
            {
                return NotFound();
            }
            return View(detalleVentum);
        }

        // POST: DetalleVentums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodigoDetalleVenta,PrecioUnitarioDetalleVenta,CantidadDetalleVenta,ValorTotalDetalleVenta,SubtotalDetalleVenta,CodigoVenta,CodigoProducto")] DetalleVentum detalleVentum)
        {
            if (id != detalleVentum.CodigoDetalleVenta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detalleVentum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetalleVentumExists(detalleVentum.CodigoDetalleVenta))
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
            return View(detalleVentum);
        }

        // GET: DetalleVentums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DetalleVenta == null)
            {
                return NotFound();
            }

            var detalleVentum = await _context.DetalleVenta
                .FirstOrDefaultAsync(m => m.CodigoDetalleVenta == id);
            if (detalleVentum == null)
            {
                return NotFound();
            }

            return View(detalleVentum);
        }

        // POST: DetalleVentums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DetalleVenta == null)
            {
                return Problem("Entity set 'novoContext.DetalleVenta'  is null.");
            }
            var detalleVentum = await _context.DetalleVenta.FindAsync(id);
            if (detalleVentum != null)
            {
                _context.DetalleVenta.Remove(detalleVentum);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetalleVentumExists(int id)
        {
          return (_context.DetalleVenta?.Any(e => e.CodigoDetalleVenta == id)).GetValueOrDefault();
        }
    }
}
