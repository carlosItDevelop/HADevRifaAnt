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
    public class GrupoPessoaController : Controller
    {
        private readonly HADeveloperDBContext _context;

        public GrupoPessoaController(HADeveloperDBContext context)
        {
            _context = context;
        }

        // GET: GrupoPessoa
        public async Task<IActionResult> Index()
        {
            return View(await _context.GrupoPessoa.ToListAsync());
        }

        // GET: GrupoPessoa/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grupoPessoa = await _context.GrupoPessoa
                .FirstOrDefaultAsync(m => m.Id == id);
            if (grupoPessoa == null)
            {
                return NotFound();
            }

            return View(grupoPessoa);
        }

        // GET: GrupoPessoa/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GrupoPessoa/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,Id")] GrupoPessoa grupoPessoa)
        {
            if (ModelState.IsValid)
            {
                grupoPessoa.Id = Guid.NewGuid();
                _context.Add(grupoPessoa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(grupoPessoa);
        }

        // GET: GrupoPessoa/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grupoPessoa = await _context.GrupoPessoa.FindAsync(id);
            if (grupoPessoa == null)
            {
                return NotFound();
            }
            return View(grupoPessoa);
        }

        // POST: GrupoPessoa/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Nome,Id")] GrupoPessoa grupoPessoa)
        {
            if (id != grupoPessoa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(grupoPessoa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GrupoPessoaExists(grupoPessoa.Id))
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
            return View(grupoPessoa);
        }

        // GET: GrupoPessoa/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grupoPessoa = await _context.GrupoPessoa
                .FirstOrDefaultAsync(m => m.Id == id);
            if (grupoPessoa == null)
            {
                return NotFound();
            }

            return View(grupoPessoa);
        }

        // POST: GrupoPessoa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var grupoPessoa = await _context.GrupoPessoa.FindAsync(id);
            _context.GrupoPessoa.Remove(grupoPessoa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GrupoPessoaExists(Guid id)
        {
            return _context.GrupoPessoa.Any(e => e.Id == id);
        }
    }
}
