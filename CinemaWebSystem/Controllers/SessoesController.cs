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
    public class SessoesController : Controller
    {
        private readonly CinemaDbContext _context;

        public SessoesController(CinemaDbContext context)
        {
            _context = context;
        }

        // GET: Sessoes
        public async Task<IActionResult> Index()
        {
            var cinemaDbContext = _context.Sessoes.Include(s => s.Cinema).Include(s => s.Filme).Include(s => s.Sala);
            return View(await cinemaDbContext.ToListAsync());
        }

        // GET: Sessoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sessao = await _context.Sessoes
                .Include(s => s.Cinema)
                .Include(s => s.Filme)
                .Include(s => s.Sala)
                .SingleOrDefaultAsync(m => m.SessaoId == id);
            if (sessao == null)
            {
                return NotFound();
            }

            return View(sessao);
        }

        // GET: Sessoes/Create
        public IActionResult Create()
        {
            ViewData["CinemaId"] = new SelectList(_context.Cinemas, "CinemaId", "Nome");
            ViewData["FilmeId"] = new SelectList(_context.Filmes, "FilmeId", "Titulo");
            //ViewData["SalaId"] = new SelectList(_context.Salas, "SalaId", "Nome");
            return View();
        }

        // POST: Sessoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SessaoId,Horario,Preco,Ativa,FilmeId,SalaId,CinemaId")] Sessao sessao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sessao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CinemaId"] = new SelectList(_context.Cinemas, "CinemaId", "Nome", sessao.CinemaId);
            ViewData["FilmeId"] = new SelectList(_context.Filmes, "FilmeId", "Titulo", sessao.FilmeId);
            //ViewData["SalaId"] = new SelectList(_context.Salas, "SalaId", "Nome", sessao.SalaId);
            return View(sessao);
        }

        // GET: Sessoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sessao = await _context.Sessoes.SingleOrDefaultAsync(m => m.SessaoId == id);
            if (sessao == null)
            {
                return NotFound();
            }
            ViewData["CinemaId"] = new SelectList(_context.Cinemas, "CinemaId", "Nome", sessao.CinemaId);
            ViewData["FilmeId"] = new SelectList(_context.Filmes, "FilmeId", "Titulo", sessao.FilmeId);
            return View(sessao);
        }

        // POST: Sessoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SessaoId,Horario,Preco,Ativa,FilmeId,SalaId,CinemaId")] Sessao sessao)
        {
            if (id != sessao.SessaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sessao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SessaoExists(sessao.SessaoId))
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
            ViewData["CinemaId"] = new SelectList(_context.Cinemas, "CinemaId", "Nome", sessao.CinemaId);
            ViewData["FilmeId"] = new SelectList(_context.Filmes, "FilmeId", "Titulo", sessao.FilmeId);
            ViewData["SalaId"] = new SelectList(_context.Salas, "SalaId", "Nome", sessao.SalaId);
            return View(sessao);
        }

        // GET: Sessoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sessao = await _context.Sessoes
                .Include(s => s.Cinema)
                .Include(s => s.Filme)
                .Include(s => s.Sala)
                .SingleOrDefaultAsync(m => m.SessaoId == id);
            if (sessao == null)
            {
                return NotFound();
            }

            return View(sessao);
        }

        // POST: Sessoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sessao = await _context.Sessoes.SingleOrDefaultAsync(m => m.SessaoId == id);
            _context.Sessoes.Remove(sessao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SessaoExists(int id)
        {
            return _context.Sessoes.Any(e => e.SessaoId == id);
        }

        public JsonResult Salas(int CinemaId)
        {
            return Json(new SelectList(_context.Salas.Where(i => i.CinemaId == CinemaId), "SalaId", "Nome"));
        }
    }
}
