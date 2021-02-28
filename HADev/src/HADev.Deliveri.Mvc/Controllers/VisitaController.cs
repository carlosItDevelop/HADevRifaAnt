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
    public class VisitaController : Controller
    {
        private readonly HADeveloperDBContext _context;

        public VisitaController(HADeveloperDBContext context)
        {
            _context = context;
        }

        // GET: Visita
        public async Task<IActionResult> Index()
        {
            var hADeveloperDBContext = _context.Visista.Include(v => v.Eleitor);
            return View(await hADeveloperDBContext.ToListAsync());
        }

        // GET: Visita/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visita = await _context.Visista
                .Include(v => v.Eleitor)
                .FirstOrDefaultAsync(m => m.VisitaId == id);
            if (visita == null)
            {
                return NotFound();
            }

            return View(visita);
        }

        // GET: Visita/Create
        public IActionResult Create()
        {
            ViewData["EleitorId"] = new SelectList(_context.Eleitor, "EleitorId", "Nome");
            return View();
        }

        // POST: Visita/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VisitaId,EleitorId,DataVisita,Obs")] Visita visita)
        {
            if (ModelState.IsValid)
            {
                _context.Add(visita);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EleitorId"] = new SelectList(_context.Eleitor, "EleitorId", "Nome", visita.EleitorId);
            return View(visita);
        }

        // GET: Visita/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visita = await _context.Visista.FindAsync(id);
            if (visita == null)
            {
                return NotFound();
            }
            ViewData["EleitorId"] = new SelectList(_context.Eleitor, "EleitorId", "Nome", visita.EleitorId);
            return View(visita);
        }

        // POST: Visita/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VisitaId,EleitorId,DataVisita,Obs")] Visita visita)
        {
            if (id != visita.VisitaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(visita);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VisitaExists(visita.VisitaId))
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
            ViewData["EleitorId"] = new SelectList(_context.Eleitor, "EleitorId", "Nome", visita.EleitorId);
            return View(visita);
        }

        // GET: Visita/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visita = await _context.Visista
                .Include(v => v.Eleitor)
                .FirstOrDefaultAsync(m => m.VisitaId == id);
            if (visita == null)
            {
                return NotFound();
            }

            return View(visita);
        }

        // POST: Visita/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var visita = await _context.Visista.FindAsync(id);
            _context.Visista.Remove(visita);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VisitaExists(int id)
        {
            return _context.Visista.Any(e => e.VisitaId == id);
        }
    }
}
