using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HADev.Delivery.Domain.Models;
using HADeveloper.Date.ORM;

namespace HADev.Delivery.Mvc.Controllers
{
    public class CidadeController : Controller
    {
        private readonly HADeveloperDBContext _context;

        public CidadeController(HADeveloperDBContext context)
        {
            _context = context;
        }

        // GET: Cidade
        public async Task<IActionResult> Index()
        {
            var hADeveloperDBContext = _context.Cidade.Include(c => c.Estado);
            return View(await hADeveloperDBContext.ToListAsync());
        }

        // GET: Cidade/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cidade = await _context.Cidade
                .Include(c => c.Estado)
                .FirstOrDefaultAsync(m => m.CidadeId == id);
            if (cidade == null)
            {
                return NotFound();
            }

            return View(cidade);
        }

        // GET: Cidade/Create
        public IActionResult Create()
        {
            ViewData["EstadoId"] = new SelectList(_context.Estado, "EstadoId", "Nome");
            return View();
        }

        // POST: Cidade/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CidadeId,EstadoId,Nome")] Cidade cidade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cidade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EstadoId"] = new SelectList(_context.Estado, "EstadoId", "Nome", cidade.EstadoId);
            return View(cidade);
        }

        // GET: Cidade/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cidade = await _context.Cidade.FindAsync(id);
            if (cidade == null)
            {
                return NotFound();
            }
            ViewData["EstadoId"] = new SelectList(_context.Estado, "EstadoId", "Nome", cidade.EstadoId);
            return View(cidade);
        }

        // POST: Cidade/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CidadeId,EstadoId,Nome")] Cidade cidade)
        {
            if (id != cidade.CidadeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cidade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CidadeExists(cidade.CidadeId))
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
            ViewData["EstadoId"] = new SelectList(_context.Estado, "EstadoId", "Nome", cidade.EstadoId);
            return View(cidade);
        }

        // GET: Cidade/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cidade = await _context.Cidade
                .Include(c => c.Estado)
                .FirstOrDefaultAsync(m => m.CidadeId == id);
            if (cidade == null)
            {
                return NotFound();
            }

            return View(cidade);
        }

        // POST: Cidade/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cidade = await _context.Cidade.FindAsync(id);
            _context.Cidade.Remove(cidade);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CidadeExists(int id)
        {
            return _context.Cidade.Any(e => e.CidadeId == id);
        }
    }
}
