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


        [HttpPost]
        public async Task<ActionResult> EnviarJSON(string Descripcion, int Auxiliar, int CuentaDB, int CuentaCR, decimal Monto)
        {
            // Objeto que deseas enviar en el JSON
            var dataToSend = new
            {
                Descripcion = Descripcion,
                Auxiliar = Auxiliar,
                CuentaDB = CuentaDB,
                CuentaCR = CuentaCR,
                Monto = Monto
            };

            // Serializar el objeto a JSON
            string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(dataToSend);

            // URL de la API
            string apiUrl = "http://129.80.203.120:5000/post-accounting-entries";

            // Crear cliente HTTP
            using (var httpClient = new HttpClient())
            {
                // Configurar encabezados para indicar JSON
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                // Contenido del JSON
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                // Enviar la solicitud POST a la API
                HttpResponseMessage response = await httpClient.PostAsync(apiUrl, content);

                // Procesar la respuesta de la API si es necesario
                if (response.IsSuccessStatusCode)
                {
                    // Obtener la respuesta de la API como texto (puedes usar otros métodos de lectura según lo que retorne tu API)
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    // Realizar acciones con la respuesta recibida, si es necesario

                    // Retornar la respuesta como texto (puedes personalizar esto según tus necesidades)
                    return Content(apiResponse);
                }

                // Manejar errores si la solicitud no fue exitosa
                return Content("Error en la solicitud a la API");
            }







        }
    }
}   


