using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CinemaWebSystem.Data;
using CinemaWebSystem.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Drawing;

namespace CinemaWebSystem.Controllers
{
    public class FilmesController : Controller
    {
        private readonly CinemaDbContext _context;

        public FilmesController(CinemaDbContext context)
        {
            _context = context;
        }

        // GET: Filmes
        public async Task<IActionResult> Index()
        {
            var cinemaDbContext = _context.Filmes.Include(f => f.Genero);
            return View(await cinemaDbContext.ToListAsync());
        }

        // GET: Filmes/Create
        public IActionResult Create()
        {
            ViewData["GeneroId"] = new SelectList(_context.Generos, "GeneroId", "Descricao");
            return View();
        }

        // POST: Filmes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FilmeId,Titulo,Classificacao,GeneroId,Ativa")] Filme filme, IFormFile Imagem)
        { 
            if(Imagem != null && Imagem.Length > 0)
            {
                
                using (var stream = new MemoryStream())
                {
                    await Imagem.CopyToAsync(stream);
                    Bitmap img = new Bitmap(stream);
                    var v = img.Size;
                    filme.Imagem = stream.ToArray();
                }
            }
            if (ModelState.IsValid)
            {
                _context.Add(filme);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GeneroId"] = new SelectList(_context.Generos, "GeneroId", "Descricao", filme.GeneroId);
            return View(filme);
        }

        // GET: Filmes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filme = await _context.Filmes.SingleOrDefaultAsync(m => m.FilmeId == id);
            if (filme == null)
            {
                return NotFound();
            }
            ViewData["GeneroId"] = new SelectList(_context.Generos, "GeneroId", "Descricao", filme.GeneroId);
            return View(filme);
        }

        // POST: Filmes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FilmeId,Titulo,Classificacao,GeneroId,Ativa")] Filme filme, IFormFile Imagem)
        {
            if (id != filme.FilmeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (Imagem != null && Imagem.Length > 0)
                    {
                        using (var stream = new MemoryStream())
                        {
                            await Imagem.CopyToAsync(stream);
                            filme.Imagem = stream.ToArray();
                        }
                        _context.Update(filme);
                    }
                    else
                    {
                        _context.Entry(filme).State = EntityState.Unchanged;
                        _context.Entry(filme).Property("Titulo").IsModified = true;
                        _context.Entry(filme).Property("Classificacao").IsModified = true;
                        _context.Entry(filme).Property("GeneroId").IsModified = true;
                    }
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilmeExists(filme.FilmeId))
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
            ViewData["GeneroId"] = new SelectList(_context.Generos, "GeneroId", "Descricao", filme.GeneroId);
            return View(filme);
        }

        // GET: Filmes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filme = await _context.Filmes
                .Include(f => f.Genero)
                .SingleOrDefaultAsync(m => m.FilmeId == id);
            if (filme == null)
            {
                return NotFound();
            }

            return View(filme);
        }

        // POST: Filmes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var filme = await _context.Filmes.SingleOrDefaultAsync(m => m.FilmeId == id);
            _context.Filmes.Remove(filme);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilmeExists(int id)
        {
            return _context.Filmes.Any(e => e.FilmeId == id);
        }
    }
}
