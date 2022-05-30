using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cinema.Data;
using Cinema.Models;

namespace Cinema.Controllers
{
    public class IngressosController : Controller
    {
        private readonly CinemaContext _context;

        public IngressosController(CinemaContext context)
        {
            _context = context;
        }

        // GET: Ingressos
        public async Task<IActionResult> Index()
        {
            var cinemaContext = _context.Ingresso.Include(i => i.Sessao);
            return View(await cinemaContext.ToListAsync());
        }

        // GET: Ingressos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingresso = await _context.Ingresso
                .Include(i => i.Sessao)
                .FirstOrDefaultAsync(m => m.IngressoId == id);
            if (ingresso == null)
            {
                return NotFound();
            }

            return View(ingresso);
        }

        // GET: Ingressos/Create
        public IActionResult Create()
        {
            ViewData["SessaoId"] = new SelectList(_context.Sessao, "SessaoId", "SessaoId");
            return View();
        }

        // POST: Ingressos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IngressoId,IngressoInteiro,IngressoMeia,Preco,SessaoId,Fileira,AssentoNum")] Ingresso ingresso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ingresso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SessaoId"] = new SelectList(_context.Sessao, "SessaoId", "SessaoId", ingresso.SessaoId);
            return View(ingresso);
        }

        // GET: Ingressos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingresso = await _context.Ingresso.FindAsync(id);
            if (ingresso == null)
            {
                return NotFound();
            }
            ViewData["SessaoId"] = new SelectList(_context.Sessao, "SessaoId", "SessaoId", ingresso.SessaoId);
            return View(ingresso);
        }

        // POST: Ingressos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IngressoId,IngressoInteiro,IngressoMeia,Preco,SessaoId,Fileira,AssentoNum")] Ingresso ingresso)
        {
            if (id != ingresso.IngressoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ingresso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IngressoExists(ingresso.IngressoId))
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
            ViewData["SessaoId"] = new SelectList(_context.Sessao, "SessaoId", "SessaoId", ingresso.SessaoId);
            return View(ingresso);
        }

        // GET: Ingressos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingresso = await _context.Ingresso
                .Include(i => i.Sessao)
                .FirstOrDefaultAsync(m => m.IngressoId == id);
            if (ingresso == null)
            {
                return NotFound();
            }

            return View(ingresso);
        }

        // POST: Ingressos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ingresso = await _context.Ingresso.FindAsync(id);
            _context.Ingresso.Remove(ingresso);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IngressoExists(int id)
        {
            return _context.Ingresso.Any(e => e.IngressoId == id);
        }
    }
}
