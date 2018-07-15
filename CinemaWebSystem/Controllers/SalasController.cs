using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CinemaWebSystem.Data;
using CinemaWebSystem.Models;

namespace CinemaWebSystem.Controllers
{
    public class SalasController : Controller
    {
        private readonly CinemaDbContext _context;

        public SalasController(CinemaDbContext context)
        {
            _context = context;
        }

        // GET: Salas
        public async Task<IActionResult> Index()
        {
            var cinemaDbContext = _context.Salas.Include(s => s.Cinema);
            return View(await cinemaDbContext.ToListAsync());
        }

        // GET: Salas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sala = await _context.Salas
                .Include(s => s.Cinema)
                .SingleOrDefaultAsync(m => m.SalaId == id);
            if (sala == null)
            {
                return NotFound();
            }

            return View(sala);
        }

        // GET: Salas/Create
        public IActionResult Create()
        {
            ViewData["CinemaId"] = new SelectList(_context.Cinemas, "CinemaId", "Cidade");
            return View();
        }

        // POST: Salas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SalaId,Nome,QuantidadeAssentos,Ativa,CinemaId")] Sala sala)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sala);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CinemaId"] = new SelectList(_context.Cinemas, "CinemaId", "Cidade", sala.CinemaId);
            return View(sala);
        }

        // GET: Salas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sala = await _context.Salas.SingleOrDefaultAsync(m => m.SalaId == id);
            if (sala == null)
            {
                return NotFound();
            }
            ViewData["CinemaId"] = new SelectList(_context.Cinemas, "CinemaId", "Cidade", sala.CinemaId);
            return View(sala);
        }

        // POST: Salas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SalaId,Nome,QuantidadeAssentos,Ativa,CinemaId")] Sala sala)
        {
            if (id != sala.SalaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sala);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalaExists(sala.SalaId))
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
            ViewData["CinemaId"] = new SelectList(_context.Cinemas, "CinemaId", "Cidade", sala.CinemaId);
            return View(sala);
        }

        // GET: Salas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sala = await _context.Salas
                .Include(s => s.Cinema)
                .SingleOrDefaultAsync(m => m.SalaId == id);
            if (sala == null)
            {
                return NotFound();
            }

            return View(sala);
        }

        // POST: Salas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sala = await _context.Salas.SingleOrDefaultAsync(m => m.SalaId == id);
            _context.Salas.Remove(sala);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalaExists(int id)
        {
            return _context.Salas.Any(e => e.SalaId == id);
        }
    }
}
