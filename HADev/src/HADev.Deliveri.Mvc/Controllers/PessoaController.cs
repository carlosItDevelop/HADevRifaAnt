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
    public class PessoaController : Controller
    {
        private readonly HADeveloperDBContext _context;

        public PessoaController(HADeveloperDBContext context)
        {
            _context = context;
        }

        // GET: Pessoa
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pessoa
                .Include(p => p.GrupoPessoa).AsNoTracking().ToListAsync());
        }

        // GET: Pessoa/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoa = await _context.Pessoa
                .Include(p => p.GrupoPessoa).AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pessoa == null)
            {
                return NotFound();
            }

            return View(pessoa);
        }

        // GET: Pessoa/Create
        public IActionResult Create()
        {
            ViewData["GrupoPessoaId"] = new SelectList(_context.GrupoPessoa, "Id", "Nome");
            return View();
        }

        // POST: Pessoa/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Cpf,DataNascimento,Rg,OrgaoEspedidor,Nome,Sexo,EstadoCivil,GrupoPessoaId,NomeMae,NomePai,Cliente,Fornecedor,Vendedor,TipoPessoa,DataCadastro,UserCadastroId,DataAlteracao,UserAlteracaoId,Ativo,Atualizar,SenhaCDA,Bio,Id")] Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                pessoa.Id = Guid.NewGuid();
                _context.Add(pessoa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GrupoPessoaId"] = new SelectList(_context.GrupoPessoa, "Id", "Nome", pessoa.GrupoPessoaId);
            return View(pessoa);
        }

        // GET: Pessoa/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoa = await _context.Pessoa.FindAsync(id);
            if (pessoa == null)
            {
                return NotFound();
            }
            ViewData["GrupoPessoaId"] = new SelectList(_context.GrupoPessoa, "Id", "Nome", pessoa.GrupoPessoaId);
            return View(pessoa);
        }

        // POST: Pessoa/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Cpf,DataNascimento,Rg,OrgaoEspedidor,Nome,Sexo,EstadoCivil,GrupoPessoaId,NomeMae,NomePai,Cliente,Fornecedor,Vendedor,TipoPessoa,DataCadastro,UserCadastroId,DataAlteracao,UserAlteracaoId,Ativo,Atualizar,SenhaCDA,Bio,Id")] Pessoa pessoa)
        {
            if (id != pessoa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pessoa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PessoaExists(pessoa.Id))
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
            ViewData["GrupoPessoaId"] = new SelectList(_context.GrupoPessoa, "Id", "Nome", pessoa.GrupoPessoaId);
            return View(pessoa);
        }

        // GET: Pessoa/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoa = await _context.Pessoa
                .Include(p => p.GrupoPessoa).AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pessoa == null)
            {
                return NotFound();
            }

            return View(pessoa);
        }

        // POST: Pessoa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var pessoa = await _context.Pessoa.FindAsync(id);
            _context.Pessoa.Remove(pessoa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PessoaExists(Guid id)
        {
            return _context.Pessoa.Any(e => e.Id == id);
        }
    }
}
