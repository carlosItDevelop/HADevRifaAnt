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
    public class EnderecoController : Controller
    {
        private readonly HADeveloperDBContext _context;

        public EnderecoController(HADeveloperDBContext context)
        {
            _context = context;
        }

        // GET: Endereco
        public async Task<IActionResult> Index()
        {
            var hADeveloperDBContext = _context.Endereco.Include(e => e.Bairro).Include(e => e.Cidade).Include(e => e.Estado).Include(e => e.Pessoa);
            return View(await hADeveloperDBContext.ToListAsync());
        }

        // GET: Endereco/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var endereco = await _context.Endereco
                .Include(e => e.Bairro)
                .Include(e => e.Cidade)
                .Include(e => e.Estado)
                .Include(e => e.Pessoa)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (endereco == null)
            {
                return NotFound();
            }

            return View(endereco);
        }

        // GET: Endereco/Create
        public IActionResult Create()
        {
            ViewData["BairroId"] = new SelectList(_context.Bairro, "BairroId", "Cep");
            ViewData["CidadeId"] = new SelectList(_context.Cidade, "CidadeId", "Nome");
            ViewData["EstadoId"] = new SelectList(_context.Estado, "EstadoId", "Nome");
            ViewData["PessoaId"] = new SelectList(_context.Pessoa, "Id", "Id");
            return View();
        }

        // POST: Endereco/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PessoaId,Descricao,Responsavel,CEP,Longradouro,Numero,Referencia,EstadoId,CidadeId,BairroId,Id")] Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                endereco.Id = Guid.NewGuid();
                _context.Add(endereco);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BairroId"] = new SelectList(_context.Bairro, "BairroId", "Cep", endereco.BairroId);
            ViewData["CidadeId"] = new SelectList(_context.Cidade, "CidadeId", "Nome", endereco.CidadeId);
            ViewData["EstadoId"] = new SelectList(_context.Estado, "EstadoId", "Nome", endereco.EstadoId);
            ViewData["PessoaId"] = new SelectList(_context.Pessoa, "Id", "Id", endereco.PessoaId);
            return View(endereco);
        }

        // GET: Endereco/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var endereco = await _context.Endereco.FindAsync(id);
            if (endereco == null)
            {
                return NotFound();
            }
            ViewData["BairroId"] = new SelectList(_context.Bairro, "BairroId", "Cep", endereco.BairroId);
            ViewData["CidadeId"] = new SelectList(_context.Cidade, "CidadeId", "Nome", endereco.CidadeId);
            ViewData["EstadoId"] = new SelectList(_context.Estado, "EstadoId", "Nome", endereco.EstadoId);
            ViewData["PessoaId"] = new SelectList(_context.Pessoa, "Id", "Id", endereco.PessoaId);
            return View(endereco);
        }

        // POST: Endereco/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("PessoaId,Descricao,Responsavel,CEP,Longradouro,Numero,Referencia,EstadoId,CidadeId,BairroId,Id")] Endereco endereco)
        {
            if (id != endereco.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(endereco);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnderecoExists(endereco.Id))
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
            ViewData["BairroId"] = new SelectList(_context.Bairro, "BairroId", "Cep", endereco.BairroId);
            ViewData["CidadeId"] = new SelectList(_context.Cidade, "CidadeId", "Nome", endereco.CidadeId);
            ViewData["EstadoId"] = new SelectList(_context.Estado, "EstadoId", "Nome", endereco.EstadoId);
            ViewData["PessoaId"] = new SelectList(_context.Pessoa, "Id", "Id", endereco.PessoaId);
            return View(endereco);
        }

        // GET: Endereco/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var endereco = await _context.Endereco
                .Include(e => e.Bairro)
                .Include(e => e.Cidade)
                .Include(e => e.Estado)
                .Include(e => e.Pessoa)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (endereco == null)
            {
                return NotFound();
            }

            return View(endereco);
        }

        // POST: Endereco/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var endereco = await _context.Endereco.FindAsync(id);
            _context.Endereco.Remove(endereco);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnderecoExists(Guid id)
        {
            return _context.Endereco.Any(e => e.Id == id);
        }
    }
}
