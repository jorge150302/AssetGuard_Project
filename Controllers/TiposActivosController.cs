using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AssetGuard_Project.Models;

namespace AssetGuard_Project.Controllers
{
    public class TiposActivosController : Controller
    {
        private readonly AssetGuardDbContext _context;

        public TiposActivosController(AssetGuardDbContext context)
        {
            _context = context;
        }

        // GET: TiposActivos
        public async Task<IActionResult> Index(string term)
        {
            var AssetGuardDbContext = from h in _context.TiposActivos select h;

            return View(await AssetGuardDbContext.Where(x => term == null
            || x.IdTa.ToString().StartsWith(term)
            || x.DescripcionTa.Contains(term)
            || x.CuentaContableCompraTa.ToString().Contains(term)
            || x.CuentaContableDepreciacionTa.ToString().Contains(term)).ToListAsync());
        }

        // GET: TiposActivos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TiposActivos == null)
            {
                return NotFound();
            }

            var tiposActivo = await _context.TiposActivos
                .FirstOrDefaultAsync(m => m.IdTa == id);
            if (tiposActivo == null)
            {
                return NotFound();
            }

            return View(tiposActivo);
        }

        // GET: TiposActivos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TiposActivos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTa,DescripcionTa,CuentaContableCompraTa,CuentaContableDepreciacionTa,EstadoTa")] TiposActivo tiposActivo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tiposActivo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tiposActivo);
        }

        // GET: TiposActivos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TiposActivos == null)
            {
                return NotFound();
            }

            var tiposActivo = await _context.TiposActivos.FindAsync(id);
            if (tiposActivo == null)
            {
                return NotFound();
            }
            return View(tiposActivo);
        }

        // POST: TiposActivos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTa,DescripcionTa,CuentaContableCompraTa,CuentaContableDepreciacionTa,EstadoTa")] TiposActivo tiposActivo)
        {
            if (id != tiposActivo.IdTa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tiposActivo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TiposActivoExists(tiposActivo.IdTa))
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
            return View(tiposActivo);
        }

        // GET: TiposActivos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TiposActivos == null)
            {
                return NotFound();
            }

            var tiposActivo = await _context.TiposActivos
                .FirstOrDefaultAsync(m => m.IdTa == id);
            if (tiposActivo == null)
            {
                return NotFound();
            }

            return View(tiposActivo);
        }

        // POST: TiposActivos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TiposActivos == null)
            {
                return Problem("Entity set 'AssetGuardDbContext.TiposActivos'  is null.");
            }
            var tiposActivo = await _context.TiposActivos.FindAsync(id);
            if (tiposActivo != null)
            {
                _context.TiposActivos.Remove(tiposActivo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TiposActivoExists(int id)
        {
          return (_context.TiposActivos?.Any(e => e.IdTa == id)).GetValueOrDefault();
        }
    }
}
