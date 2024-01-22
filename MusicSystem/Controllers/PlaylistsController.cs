using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicSystem.ActionFilters;
using MusicSystem.Data;
using MusicSystem.Entities;

namespace MusicSystem.Controllers
{
    [AuthFilter]
    public class PlaylistsController : Controller
    {
        private readonly MusicSystemDbContext _context;

        public PlaylistsController(MusicSystemDbContext context)
        {
            _context = context;
        }

        // GET: Playlists
        public async Task<IActionResult> Index()
        {
            return _context.Playlists != null ?
                        View(await _context.Playlists.ToListAsync()) :
                        Problem("Entity set 'Context.Playlists'  is null.");
        }

        // GET: Playlists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Playlists == null)
            {
                return NotFound();
            }

            var playlists = await _context.Playlists
                .FirstOrDefaultAsync(m => m.Id == id);
            if (playlists == null)
            {
                return NotFound();
            }

            return View(playlists);
        }

        // GET: Playlists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Playlists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Playlists playlists)
        {
            if (ModelState.IsValid)
            {
                _context.Add(playlists);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(playlists);
        }

        // GET: Playlists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Playlists == null)
            {
                return NotFound();
            }

            var playlists = await _context.Playlists.FindAsync(id);
            if (playlists == null)
            {
                return NotFound();
            }
            return View(playlists);
        }

        // POST: Playlists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Playlists playlists)
        {
            if (id != playlists.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(playlists);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlaylistsExists(playlists.Id))
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
            return View(playlists);
        }

        // GET: Playlists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Playlists == null)
            {
                return NotFound();
            }

            var playlists = await _context.Playlists
                .FirstOrDefaultAsync(m => m.Id == id);
            if (playlists == null)
            {
                return NotFound();
            }

            return View(playlists);
        }

        // POST: Playlists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Playlists == null)
            {
                return Problem("Entity set 'Context.Playlists'  is null.");
            }
            var playlists = await _context.Playlists.FindAsync(id);
            if (playlists != null)
            {
                _context.Playlists.Remove(playlists);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlaylistsExists(int id)
        {
            return (_context.Playlists?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
