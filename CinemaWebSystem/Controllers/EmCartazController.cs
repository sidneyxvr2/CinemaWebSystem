using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaWebSystem.Data;
using CinemaWebSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaWebSystem.Controllers
{
    public class EmCartazController : Controller
    {
        private readonly CinemaDbContext _context;

        public EmCartazController(CinemaDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var tbl = _context.Sessoes.Include(s => s.Filme).Include(s => s.Cinema).Include(s => s.Sala).Where(s => s.Horario > DateTime.Now).Select(s => s.Filme).Distinct();
            return View(await tbl.ToListAsync());
        }

        public async Task<IActionResult> EscolherSessao(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var tbl = _context.Sessoes.Include(s => s.Filme).Include(s => s.Cinema).Include(s => s.Sala).Where(s => s.FilmeId == id).OrderBy(s => s.Horario);
            return View(await tbl.ToListAsync());
        }

        public async Task<IActionResult> ComprarIngresso(int? id)
        {
            ViewBag.Sessao = await _context.Sessoes.Include(s => s.Filme).Include(s => s.Sala).Include(s => s.Cinema).SingleOrDefaultAsync(s => s.SessaoId == id);
            Venda v = new Venda() {
                SessaoId = ViewBag.Sessao.SessaoId
            };
            return View(v);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ComprarIngresso(int id, Venda venda)
        {
            if(venda.SessaoId != id)
            {
                return NotFound();
            }
            venda.Data = DateTime.Now;
            venda.ClienteId = 1;
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Vendas.Add(venda);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(EscolherSessao));
        }
    }
}