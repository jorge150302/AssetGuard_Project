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
    public class ActivosFijosController : Controller
    {
        private readonly AssetGuardDbContext _context;

        public ActivosFijosController(AssetGuardDbContext context)
        {
            _context = context;
        }

        // GET: ActivosFijos
        public async Task<IActionResult> Index(string term)
        {
            var assetGuardDbContext = from t in _context.ActivosFijos.Include(a => a.DepartamentoAfNavigation).Include(a => a.TipoActivoAfNavigation)
                                      select t;

            if (!String.IsNullOrEmpty(term))
            {
                assetGuardDbContext = assetGuardDbContext.Where(s => s.DescripcionAf!.Contains(term)
                                                                      || s.FechaRegistroAf!.ToString().Contains(term)
                                                                      || s.ValorCompraAf!.ToString().Contains(term)
                                                                      || s.DepreciacionAcumuladaAf!.ToString().Contains(term)
                                                                      || s.TipoActivoAfNavigation.DescripcionTa.Contains(term)
                                                                      || s.DepartamentoAfNavigation.DescripcionDepartamento.Contains(term));
            }

            return View(await assetGuardDbContext.ToListAsync());

        }

        // GET: ActivosFijos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ActivosFijos == null)
            {
                return NotFound();
            }

            var activosFijo = await _context.ActivosFijos
                .Include(a => a.DepartamentoAfNavigation)
                .Include(a => a.TipoActivoAfNavigation)
                .FirstOrDefaultAsync(m => m.IdAf == id);
            if (activosFijo == null)
            {
                return NotFound();
            }

            return View(activosFijo);
        }

        // GET: ActivosFijos/Create
        public IActionResult Create()
        {
            ViewData["DepartamentoAf"] = new SelectList(_context.Departamentos, "IdDepartamento", "DescripcionDepartamento");
            ViewData["TipoActivoAf"] = new SelectList(_context.TiposActivos, "IdTa", "DescripcionTa");
            return View();
        }

        // POST: ActivosFijos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAf,DescripcionAf,DepartamentoAf,TipoActivoAf,FechaRegistroAf,ValorCompraAf,DepreciacionAcumuladaAf")] ActivosFijo activosFijo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(activosFijo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartamentoAf"] = new SelectList(_context.Departamentos, "IdDepartamento", "DescripcionDepartamento", activosFijo.DepartamentoAf);
            ViewData["TipoActivoAf"] = new SelectList(_context.TiposActivos, "IdTa", "DescripcionTa", activosFijo.TipoActivoAf);
            return View(activosFijo);
        }

        // GET: ActivosFijos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ActivosFijos == null)
            {
                return NotFound();
            }

            var activosFijo = await _context.ActivosFijos.FindAsync(id);
            if (activosFijo == null)
            {
                return NotFound();
            }
            ViewData["DepartamentoAf"] = new SelectList(_context.Departamentos, "IdDepartamento", "DescripcionDepartamento", activosFijo.DepartamentoAf);
            ViewData["TipoActivoAf"] = new SelectList(_context.TiposActivos, "IdTa", "DescripcionTa", activosFijo.TipoActivoAf);
            return View(activosFijo);
        }

        // POST: ActivosFijos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAf,DescripcionAf,DepartamentoAf,TipoActivoAf,FechaRegistroAf,ValorCompraAf,DepreciacionAcumuladaAf")] ActivosFijo activosFijo)
        {
            if (id != activosFijo.IdAf)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(activosFijo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActivosFijoExists(activosFijo.IdAf))
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
            ViewData["DepartamentoAf"] = new SelectList(_context.Departamentos, "IdDepartamento", "DescripcionDepartamento", activosFijo.DepartamentoAf);
            ViewData["TipoActivoAf"] = new SelectList(_context.TiposActivos, "IdTa", "DescripcionTa", activosFijo.TipoActivoAf);
            return View(activosFijo);
        }

        // GET: ActivosFijos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ActivosFijos == null)
            {
                return NotFound();
            }

            var activosFijo = await _context.ActivosFijos
                .Include(a => a.DepartamentoAfNavigation)
                .Include(a => a.TipoActivoAfNavigation)
                .FirstOrDefaultAsync(m => m.IdAf == id);
            if (activosFijo == null)
            {
                return NotFound();
            }

            return View(activosFijo);
        }

        // POST: ActivosFijos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ActivosFijos == null)
            {
                return Problem("Entity set 'AssetGuardDbContext.ActivosFijos'  is null.");
            }
            var activosFijo = await _context.ActivosFijos.FindAsync(id);
            if (activosFijo != null)
            {
                _context.ActivosFijos.Remove(activosFijo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActivosFijoExists(int id)
        {
          return (_context.ActivosFijos?.Any(e => e.IdAf == id)).GetValueOrDefault();
        }
    }
}
