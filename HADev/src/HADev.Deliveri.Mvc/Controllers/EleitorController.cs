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
    public class EleitorController : Controller
    {
        private readonly HADeveloperDBContext _context;

        public EleitorController(HADeveloperDBContext context)
        {
            _context = context;
        }

        // GET: Eleitor
        public async Task<IActionResult> Index()
        {
            var hADeveloperDBContext = _context.Eleitor
                .Include(e => e.Bairro)
                .Include(e => e.Cidade)
                .Include(e => e.Estado);
            return View(await hADeveloperDBContext.ToListAsync());
        }

        // GET: Eleitor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eleitor = await _context.Eleitor
                .Include(e => e.Bairro)
                .Include(e => e.Cidade)
                .Include(e => e.Estado)
                .FirstOrDefaultAsync(m => m.EleitorId == id);
            if (eleitor == null)
            {
                return NotFound();
            }

            return View(eleitor);
        }

        // GET: Eleitor/Create
        public IActionResult Create()
        {
            ViewData["BairroId"] = new SelectList(_context.Bairro, "BairroId", "Nome");
            ViewData["CidadeId"] = new SelectList(_context.Cidade, "CidadeId", "Nome");
            ViewData["EstadoId"] = new SelectList(_context.Estado, "EstadoId", "Nome");
            return View();
        }

        // POST: Eleitor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EleitorId,Nome,Titulo,Apelido,EstadoId,CidadeId,BairroId,Endereco,Numero,Complemento,Celular,Telefone,Email,Sexo,Cep,DataCadastro,EstadoCivil,DataNascimento,Obs")] Eleitor eleitor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eleitor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BairroId"] = new SelectList(_context.Bairro, "BairroId", "Nome", eleitor.BairroId);
            ViewData["CidadeId"] = new SelectList(_context.Cidade, "CidadeId", "Nome", eleitor.CidadeId);
            ViewData["EstadoId"] = new SelectList(_context.Estado, "EstadoId", "Nome", eleitor.EstadoId);
            return View(eleitor);
        }

        // GET: Eleitor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eleitor = await _context.Eleitor.FindAsync(id);
            if (eleitor == null)
            {
                return NotFound();
            }
            ViewData["BairroId"] = new SelectList(_context.Bairro, "BairroId", "Nome", eleitor.BairroId);
            ViewData["CidadeId"] = new SelectList(_context.Cidade, "CidadeId", "Nome", eleitor.CidadeId);
            ViewData["EstadoId"] = new SelectList(_context.Estado, "EstadoId", "Nome", eleitor.EstadoId);
            return View(eleitor);
        }

        // POST: Eleitor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EleitorId,Nome,Titulo,Apelido,EstadoId,CidadeId,BairroId,Endereco,Numero,Complemento,Celular,Telefone,Email,Sexo,Cep,DataCadastro,EstadoCivil,DataNascimento,Obs")] Eleitor eleitor)
        {
            if (id != eleitor.EleitorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eleitor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EleitorExists(eleitor.EleitorId))
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
            ViewData["BairroId"] = new SelectList(_context.Bairro, "BairroId", "Nome", eleitor.BairroId);
            ViewData["CidadeId"] = new SelectList(_context.Cidade, "CidadeId", "Nome", eleitor.CidadeId);
            ViewData["EstadoId"] = new SelectList(_context.Estado, "EstadoId", "Nome", eleitor.EstadoId);
            return View(eleitor);
        }

        // GET: Eleitor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eleitor = await _context.Eleitor
                .Include(e => e.Bairro)
                .Include(e => e.Cidade)
                .Include(e => e.Estado)
                .FirstOrDefaultAsync(m => m.EleitorId == id);
            if (eleitor == null)
            {
                return NotFound();
            }

            return View(eleitor);
        }

        // POST: Eleitor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eleitor = await _context.Eleitor.FindAsync(id);
            _context.Eleitor.Remove(eleitor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EleitorExists(int id)
        {
            return _context.Eleitor.Any(e => e.EleitorId == id);
        }
    }
}
