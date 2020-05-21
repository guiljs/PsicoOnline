using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Psico.Data;
using Psico.Models;

namespace Psico.Controllers
{
    [Authorize]
    public class EscalasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EscalasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Escalas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Escala.ToListAsync());
        }

        // GET: Escalas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var escala = await _context.Escala
                .FirstOrDefaultAsync(m => m.Id == id);
            if (escala == null)
            {
                return NotFound();
            }

            return View(escala);
        }

        // GET: Escalas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Escalas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DiaDaSemana,Inicio,Fim,DuracaoMinutos")] Escala escala)
        {
            if (ModelState.IsValid)
            {
                _context.Add(escala);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(escala);
        }

        // GET: Escalas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var escala = await _context.Escala.FindAsync(id);
            if (escala == null)
            {
                return NotFound();
            }
            return View(escala);
        }

        // POST: Escalas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DiaDaSemana,Inicio,Fim,DuracaoMinutos")] Escala escala)
        {
            if (id != escala.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(escala);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EscalaExists(escala.Id))
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
            return View(escala);
        }

        // GET: Escalas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var escala = await _context.Escala
                .FirstOrDefaultAsync(m => m.Id == id);
            if (escala == null)
            {
                return NotFound();
            }

            return View(escala);
        }

        // POST: Escalas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var escala = await _context.Escala.FindAsync(id);
            _context.Escala.Remove(escala);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EscalaExists(int id)
        {
            return _context.Escala.Any(e => e.Id == id);
        }
    }
}
