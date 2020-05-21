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
    public class TipoProfissionalsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TipoProfissionalsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TipoProfissionals
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoProfissional.ToListAsync());
        }

        // GET: TipoProfissionals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoProfissional = await _context.TipoProfissional
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoProfissional == null)
            {
                return NotFound();
            }

            return View(tipoProfissional);
        }

        // GET: TipoProfissionals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoProfissionals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] TipoProfissional tipoProfissional)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoProfissional);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoProfissional);
        }

        // GET: TipoProfissionals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoProfissional = await _context.TipoProfissional.FindAsync(id);
            if (tipoProfissional == null)
            {
                return NotFound();
            }
            return View(tipoProfissional);
        }

        // POST: TipoProfissionals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] TipoProfissional tipoProfissional)
        {
            if (id != tipoProfissional.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoProfissional);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoProfissionalExists(tipoProfissional.Id))
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
            return View(tipoProfissional);
        }

        // GET: TipoProfissionals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoProfissional = await _context.TipoProfissional
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoProfissional == null)
            {
                return NotFound();
            }

            return View(tipoProfissional);
        }

        // POST: TipoProfissionals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoProfissional = await _context.TipoProfissional.FindAsync(id);
            _context.TipoProfissional.Remove(tipoProfissional);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoProfissionalExists(int id)
        {
            return _context.TipoProfissional.Any(e => e.Id == id);
        }
    }
}
