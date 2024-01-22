using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicSystem.Data;
using MusicSystem.Entities;

namespace MusicSystem.Controllers
{
    public class SongContributorsController : Controller
    {
        private readonly MusicSystemDbContext _context;

        public SongContributorsController(MusicSystemDbContext context)
        {
            _context = context;
        }

        // GET: SongContributors
        public async Task<IActionResult> Index()
        {
            var context = _context.SongContributors.Include(s => s.Artist).Include(s => s.Song);
            return View(await context.ToListAsync());
        }

        // GET: SongContributors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SongContributors == null)
            {
                return NotFound();
            }

            var songContributor = await _context.SongContributors
                .Include(s => s.Artist)
                .Include(s => s.Song)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (songContributor == null)
            {
                return NotFound();
            }

            return View(songContributor);
        }

        // GET: SongContributors/Create
        public IActionResult Create()
        {
            ViewData["ArtistId"] = new SelectList(_context.Artists, "Id", "Id");
            ViewData["SongId"] = new SelectList(_context.Songs, "Id", "Id");
            return View();
        }

        // POST: SongContributors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ArtistId,SongId,Role")] SongContributor songContributor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(songContributor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArtistId"] = new SelectList(_context.Artists, "Id", "Id", songContributor.ArtistId);
            ViewData["SongId"] = new SelectList(_context.Songs, "Id", "Id", songContributor.SongId);
            return View(songContributor);
        }

        // GET: SongContributors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SongContributors == null)
            {
                return NotFound();
            }

            var songContributor = await _context.SongContributors.FindAsync(id);
            if (songContributor == null)
            {
                return NotFound();
            }
            ViewData["ArtistId"] = new SelectList(_context.Artists, "Id", "Id", songContributor.ArtistId);
            ViewData["SongId"] = new SelectList(_context.Songs, "Id", "Id", songContributor.SongId);
            return View(songContributor);
        }

        // POST: SongContributors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ArtistId,SongId,Role")] SongContributor songContributor)
        {
            if (id != songContributor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(songContributor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SongContributorExists(songContributor.Id))
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
            ViewData["ArtistId"] = new SelectList(_context.Artists, "Id", "Id", songContributor.ArtistId);
            ViewData["SongId"] = new SelectList(_context.Songs, "Id", "Id", songContributor.SongId);
            return View(songContributor);
        }

        // GET: SongContributors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SongContributors == null)
            {
                return NotFound();
            }

            var songContributor = await _context.SongContributors
                .Include(s => s.Artist)
                .Include(s => s.Song)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (songContributor == null)
            {
                return NotFound();
            }

            return View(songContributor);
        }

        // POST: SongContributors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SongContributors == null)
            {
                return Problem("Entity set 'Context.SongContributors'  is null.");
            }
            var songContributor = await _context.SongContributors.FindAsync(id);
            if (songContributor != null)
            {
                _context.SongContributors.Remove(songContributor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SongContributorExists(int id)
        {
            return (_context.SongContributors?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
