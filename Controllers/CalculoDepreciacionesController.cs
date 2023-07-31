using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AssetGuard_Project.Models;
using System.Text;

namespace AssetGuard_Project.Controllers
{
    public class CalculoDepreciacionesController : Controller
    {
        private readonly AssetGuardDbContext _context;

        public CalculoDepreciacionesController(AssetGuardDbContext context)
        {
            _context = context;
        }

        // GET: CalculoDepreciaciones
        public async Task<IActionResult> Index()
        {
            var assetGuardDbContext = _context.CalculoDepreciacions.Include(c => c.ActivoFijoCdNavigation);
            return View(await assetGuardDbContext.ToListAsync());
        }

        // GET: CalculoDepreciaciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CalculoDepreciacions == null)
            {
                return NotFound();
            }

            var calculoDepreciacion = await _context.CalculoDepreciacions
                .Include(c => c.ActivoFijoCdNavigation)
                .FirstOrDefaultAsync(m => m.IdCd == id);
            if (calculoDepreciacion == null)
            {
                return NotFound();
            }

            return View(calculoDepreciacion);
        }

        // GET: CalculoDepreciaciones/Create
        public IActionResult Create()
        {
            ViewData["ActivoFijoCd"] = new SelectList(_context.ActivosFijos, "IdAf", "DescripcionAf");
            return View();
        }

        // POST: CalculoDepreciaciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCd,AnoProcesoCd,MesProcesoCd,ActivoFijoCd,FechaProcesoCd,MontoDepreciadoCd,DepreciacionAcumuladaCd,CuentaCompra,CuentaDepreciacion")] CalculoDepreciacion calculoDepreciacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(calculoDepreciacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ActivoFijoCd"] = new SelectList(_context.ActivosFijos, "IdAf", "DescripcionAf", calculoDepreciacion.ActivoFijoCd);
            return View(calculoDepreciacion);
        }

        // GET: CalculoDepreciaciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CalculoDepreciacions == null)
            {
                return NotFound();
            }

            var calculoDepreciacion = await _context.CalculoDepreciacions.FindAsync(id);
            if (calculoDepreciacion == null)
            {
                return NotFound();
            }
            ViewData["ActivoFijoCd"] = new SelectList(_context.ActivosFijos, "IdAf", "DescripcionAf", calculoDepreciacion.ActivoFijoCd);
            return View(calculoDepreciacion);
        }

        // POST: CalculoDepreciaciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCd,AnoProcesoCd,MesProcesoCd,ActivoFijoCd,FechaProcesoCd,MontoDepreciadoCd,DepreciacionAcumuladaCd,CuentaCompra,CuentaDepreciacion")] CalculoDepreciacion calculoDepreciacion)
        {
            if (id != calculoDepreciacion.IdCd)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(calculoDepreciacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CalculoDepreciacionExists(calculoDepreciacion.IdCd))
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
            ViewData["ActivoFijoCd"] = new SelectList(_context.ActivosFijos, "IdAf", "DescripcionAf", calculoDepreciacion.ActivoFijoCd);
            return View(calculoDepreciacion);
        }

        // GET: CalculoDepreciaciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CalculoDepreciacions == null)
            {
                return NotFound();
            }

            var calculoDepreciacion = await _context.CalculoDepreciacions
                .Include(c => c.ActivoFijoCdNavigation)
                .FirstOrDefaultAsync(m => m.IdCd == id);
            if (calculoDepreciacion == null)
            {
                return NotFound();
            }

            return View(calculoDepreciacion);
        }

        // POST: CalculoDepreciaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CalculoDepreciacions == null)
            {
                return Problem("Entity set 'AssetGuardDbContext.CalculoDepreciacions'  is null.");
            }
            var calculoDepreciacion = await _context.CalculoDepreciacions.FindAsync(id);
            if (calculoDepreciacion != null)
            {
                _context.CalculoDepreciacions.Remove(calculoDepreciacion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CalculoDepreciacionExists(int id)
        {
            return (_context.CalculoDepreciacions?.Any(e => e.IdCd == id)).GetValueOrDefault();
        }

        /// <summary>
        /// ///////////////////////////////////////////////////////////////////////
        /// </summary>



    }
}   


