﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AssetGuard_Project.Models;
using System.Net.Http;
using System.Text;
using System.Text.Json;



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
            var assetGuardDbContext = _context.EnvioContabilidad.Include(c => c.MontoEnvioContabilidadNavigation);


            return View(await assetGuardDbContext.ToListAsync());
        }
        // ENVIO CONTA
        public async Task<IActionResult> EnviarSolicitud(string Descripcion, int Auxiliar, int CuentaDB, int CuentaCR, decimal MontoEnvioContabilidad)
        {
            try
            {
                // Llamada de datos en el model 
                string descripcionInput = Descripcion;
                int? auxiliarInput = Auxiliar;
                int? cuentaDBInput = CuentaDB;
                int? cuentaCRInput = CuentaCR;
                decimal? MontoEnvioContabilidadInput = MontoEnvioContabilidad;
                // falta el el monto po  que un no se a hecho la union 

                // Crear el objeto de datos para enviar en la solicitud
                var data = new
                 {
                     descripcion = descripcionInput,
                     auxiliar = auxiliarInput,
                     cuentaDB = cuentaDBInput,
                     cuentaCR = cuentaCRInput,
                     monto = MontoEnvioContabilidadInput
                };

                // Convertir a JSON
                var jsonData = JsonSerializer.Serialize(data);

                // URL del endpoint
                var url = "http://129.80.203.120:5000/post-accounting-entries";

                // Realizar la solicitud HTTP POST de forma asincrónica
                using (var httpClient = new HttpClient())
                {
                    // Establecer el encabezado Content-Type
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    // Crear el contenido JSON de la solicitud
                    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                    // Enviar la solicitud POST y obtener la respuesta de forma asincrónica
                    var response = await httpClient.PostAsync(url, content);

                    // Leer el contenido de la respuesta como una cadena JSON de forma asincrónica
                    var responseContent = await response.Content.ReadAsStringAsync();

                    // Puedes procesar la respuesta según sea necesario y retornarla o mostrarla en la vista
                    // ...

                    return Content(responseContent); // Por ejemplo, retornar el contenido de la respuesta como una cadena en la vista
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores si es necesario
                return Problem("Error al realizar la solicitud HTTP: " + ex.Message);
            }
        }

        // GET: EnvioContabilidads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EnvioContabilidad == null)
            {
                return NotFound();
            }

            var envioContabilidad = await _context.EnvioContabilidad
                .Include(c => c.MontoEnvioContabilidadNavigation)
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
        public async Task<IActionResult> Create([Bind("IdEC,DescripcionEC,Auxiliar,CuentaDB,CuentaCR,MontoEnvioContabilidad")] EnvioContabilidad envioContabilidad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(envioContabilidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MontoEnvioContabilidad"] = new SelectList(_context.CalculoDepreciacions, "IdCd", "MontoDepreciadoCd", envioContabilidad.MontoEnvioContabilidad);
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
            ViewData["MontoEnvioContabilidad"] = new SelectList(_context.CalculoDepreciacions, "IdCd", "MontoDepreciadoCd", envioContabilidad.MontoEnvioContabilidad);
            return View(envioContabilidad);
        }

        // POST: EnvioContabilidads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEC,DescripcionEC,Auxiliar,CuentaDB,CuentaCR,MontoEnvioContabilidad")] EnvioContabilidad envioContabilidad)
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
            ViewData["MontoEnvioContabilidad"] = new SelectList(_context.CalculoDepreciacions, "IdCd", "MontoDepreciadoCd", envioContabilidad.MontoEnvioContabilidad);

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
                .Include(c => c.MontoEnvioContabilidadNavigation)
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
