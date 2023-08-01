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
    public class EnvioContabilidadsController : Controller
    {
        private readonly AssetGuardDbContext _context;

        public EnvioContabilidadsController(AssetGuardDbContext context)
        {
            _context = context;
        }

        // GET: EnvioContabilidads
        public async Task<IActionResult> Index()
        {
              return _context.EnvioContabilidad != null ? 
                          View(await _context.EnvioContabilidad.ToListAsync()) :
                          Problem("Entity set 'AssetGuardDbContext.EnvioContabilidad'  is null.");
        }

        // GET: EnvioContabilidads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EnvioContabilidad == null)
            {
                return NotFound();
            }

            var envioContabilidad = await _context.EnvioContabilidad
                .FirstOrDefaultAsync(m => m.IdEC == id);
            if (envioContabilidad == null)
            {
                return NotFound();
            }

            return View(envioContabilidad);
        }

        // GET: EnvioContabilidads/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EnvioContabilidads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEC,DescripcionEC,Auxiliar,CuentaDB,CuentaCR")] EnvioContabilidad envioContabilidad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(envioContabilidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(envioContabilidad);
        }

        // GET: EnvioContabilidads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EnvioContabilidad == null)
            {
                return NotFound();
            }

            var envioContabilidad = await _context.EnvioContabilidad.FindAsync(id);
            if (envioContabilidad == null)
            {
                return NotFound();
            }
            return View(envioContabilidad);
        }

        // POST: EnvioContabilidads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEC,DescripcionEC,Auxiliar,CuentaDB,CuentaCR")] EnvioContabilidad envioContabilidad)
        {
            if (id != envioContabilidad.IdEC)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(envioContabilidad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnvioContabilidadExists(envioContabilidad.IdEC))
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
            return View(envioContabilidad);
        }

        // GET: EnvioContabilidads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EnvioContabilidad == null)
            {
                return NotFound();
            }

            var envioContabilidad = await _context.EnvioContabilidad
                .FirstOrDefaultAsync(m => m.IdEC == id);
            if (envioContabilidad == null)
            {
                return NotFound();
            }

            return View(envioContabilidad);
        }

        // POST: EnvioContabilidads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EnvioContabilidad == null)
            {
                return Problem("Entity set 'AssetGuardDbContext.EnvioContabilidad'  is null.");
            }
            var envioContabilidad = await _context.EnvioContabilidad.FindAsync(id);
            if (envioContabilidad != null)
            {
                _context.EnvioContabilidad.Remove(envioContabilidad);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnvioContabilidadExists(int id)
        {
          return (_context.EnvioContabilidad?.Any(e => e.IdEC == id)).GetValueOrDefault();
        }
    }
}
