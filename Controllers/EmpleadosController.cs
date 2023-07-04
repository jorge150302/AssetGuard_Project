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
    public class EmpleadosController : Controller
    {
        private readonly AssetGuardDbContext _context;

        public EmpleadosController(AssetGuardDbContext context)
        {
            _context = context;
        }

        // GET: Empleados
        public async Task<IActionResult> Index(string term)
        {
            var AssetGuardDbContext = from t in _context.Empleados.Include(g => g.DepartamentoEmpleadoNavigation)
                         select t;

            if (!String.IsNullOrEmpty(term))
            {
                AssetGuardDbContext = AssetGuardDbContext.Where(s => s.CedulaEmpleado!.Contains(term));
            }

            return View(await AssetGuardDbContext.ToListAsync());

        }

        // GET: Empleados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Empleados == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados
                .Include(e => e.DepartamentoEmpleadoNavigation)
                .FirstOrDefaultAsync(m => m.IdEmpleado == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // GET: Empleados/Create
        public IActionResult Create()
        {
            ViewData["DepartamentoEmpleado"] = new SelectList(_context.Departamentos, "IdDepartamento", "DescripcionDepartamento");
            return View();
        }

        // POST: Empleados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        public IActionResult ValidDepartment()
        {
            var activeDepartments = _context.Departamentos.Where(d => d.EstadoDepartamento == "Activo");
            ViewData["DepartamentoEmpleado"] = new SelectList(activeDepartments, "IdDepartamento", "DescripcionDepartamento");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEmpleado,NombreEmpleado,CedulaEmpleado,DepartamentoEmpleado,TipoPersonaEmpleado,FechaIngresoEmpleado,EstadoEmpleado")] Empleado empleado)
        {
            if (!validaCedula(empleado.CedulaEmpleado))
            {
                ViewData["CedulaError"] = "Cédula incorrecta";
                ModelState.AddModelError("Cedula", "Cédula incorrecta");
            }

            if (ModelState.IsValid)
            {
                _context.Add(empleado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartamentoEmpleado"] = new SelectList(_context.Departamentos, "IdDepartamento", "DescripcionDepartamento", empleado.DepartamentoEmpleado);
            return View(empleado);
        }

        // GET: Empleados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Empleados == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }
            ViewData["DepartamentoEmpleado"] = new SelectList(_context.Departamentos, "IdDepartamento", "DescripcionDepartamento", empleado.DepartamentoEmpleado);
            return View(empleado);
        }

        // POST: Empleados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEmpleado,NombreEmpleado,CedulaEmpleado,DepartamentoEmpleado,TipoPersonaEmpleado,FechaIngresoEmpleado,EstadoEmpleado")] Empleado empleado)
        {
            if (!validaCedula(empleado.CedulaEmpleado))
            {
                ViewData["CedulaError"] = "Cédula incorrecta";
                ModelState.AddModelError("Cedula", "Cédula incorrecta");
            }
            if (id != empleado.IdEmpleado)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empleado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpleadoExists(empleado.IdEmpleado))
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
            ViewData["DepartamentoEmpleado"] = new SelectList(_context.Departamentos, "IdDepartamento", "DescripcionDepartamento", empleado.DepartamentoEmpleado);
            return View(empleado);
        }

        // GET: Empleados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Empleados == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados
                .Include(e => e.DepartamentoEmpleadoNavigation)
                .FirstOrDefaultAsync(m => m.IdEmpleado == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // POST: Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Empleados == null)
            {
                return Problem("Entity set 'AssetGuardDbContext.Empleados'  is null.");
            }
            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado != null)
            {
                _context.Empleados.Remove(empleado);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpleadoExists(int id)
        {
          return (_context.Empleados?.Any(e => e.IdEmpleado == id)).GetValueOrDefault();
        }

        public static bool validaCedula(string pCedula)
        {
            int vnTotal = 0;
            string vcCedula = pCedula.Replace("-", "");
            int pLongCed = vcCedula.Trim().Length;
            int[] digitoMult = new int[11] { 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1 };

            if (pLongCed < 11 || pLongCed > 11)
                return false;

            for (int vDig = 1; vDig <= pLongCed; vDig++)
            {
                int vCalculo = Int32.Parse(vcCedula.Substring(vDig - 1, 1)) * digitoMult[vDig - 1];
                if (vCalculo < 10)
                    vnTotal += vCalculo;
                else
                    vnTotal += Int32.Parse(vCalculo.ToString().Substring(0, 1)) + Int32.Parse(vCalculo.ToString().Substring(1, 1));
            }

            if (vnTotal % 10 == 0)
                return true;
            else
                return false;
        }
    }
}
