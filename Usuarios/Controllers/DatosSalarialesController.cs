using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Usuarios.Models;

namespace Usuarios.Controllers
{
    public class DatosSalarialesController : Controller
    {
        private readonly ClientesContext _context;

        public DatosSalarialesController(ClientesContext context)
        {
            _context = context;
        }

        // GET: DatosSalariales
        public async Task<IActionResult> Index()
        {
            var clientesContext = _context.DatosSalariales.Include(d => d.CedulaEmpleadoNavigation);
            return View(await clientesContext.ToListAsync());
        }

        // GET: DatosSalariales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datosSalariale = await _context.DatosSalariales
                .Include(d => d.CedulaEmpleadoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (datosSalariale == null)
            {
                return NotFound();
            }

            return View(datosSalariale);
        }

        // GET: DatosSalariales/Create
        public IActionResult Create()
        {
            ViewData["CedulaEmpleado"] = new SelectList(_context.Empleados, "Cedula", "Cedula");
            return View();
        }

        // POST: DatosSalariales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CedulaEmpleado")] DatosSalariale datosSalariale)
        {
            if (ModelState.IsValid)
            {
                _context.Add(datosSalariale);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CedulaEmpleado"] = new SelectList(_context.Empleados, "Cedula", "Cedula", datosSalariale.CedulaEmpleado);
            return View(datosSalariale);
        }

        // GET: DatosSalariales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datosSalariale = await _context.DatosSalariales.FindAsync(id);
            if (datosSalariale == null)
            {
                return NotFound();
            }
            ViewData["CedulaEmpleado"] = new SelectList(_context.Empleados, "Cedula", "Cedula", datosSalariale.CedulaEmpleado);
            return View(datosSalariale);
        }

        // POST: DatosSalariales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CedulaEmpleado")] DatosSalariale datosSalariale)
        {
            if (id != datosSalariale.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(datosSalariale);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DatosSalarialeExists(datosSalariale.Id))
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
            ViewData["CedulaEmpleado"] = new SelectList(_context.Empleados, "Cedula", "Cedula", datosSalariale.CedulaEmpleado);
            return View(datosSalariale);
        }

        // GET: DatosSalariales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datosSalariale = await _context.DatosSalariales
                .Include(d => d.CedulaEmpleadoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (datosSalariale == null)
            {
                return NotFound();
            }

            return View(datosSalariale);
        }

        // POST: DatosSalariales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var datosSalariale = await _context.DatosSalariales.FindAsync(id);
            if (datosSalariale != null)
            {
                _context.DatosSalariales.Remove(datosSalariale);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DatosSalarialeExists(int id)
        {
            return _context.DatosSalariales.Any(e => e.Id == id);
        }
    }
}
