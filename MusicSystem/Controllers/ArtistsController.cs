﻿using System;
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
    public class ArtistsController : Controller
    {
        private readonly MusicSystemDbContext _context;

        public ArtistsController(MusicSystemDbContext context)
        {
            _context = context;
        }

        // GET: Artists
        public async Task<IActionResult> Index()
        {
            return _context.Artists != null ?
                        View(await _context.Artists.ToListAsync()) :
                        Problem("Entity set 'Context.Artists'  is null.");
        }

        // GET: Artists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Artists == null)
            {
                return NotFound();
            }

            var artists = await _context.Artists
                .FirstOrDefaultAsync(m => m.Id == id);

            var inAlbum = await _context.Artists
           .Include(a => a.SongContributors)
           .ThenInclude(sc => sc.Song)
           .ThenInclude(s => s.Album)
           .FirstOrDefaultAsync(a => a.Id == id);



            if (artists == null)
            {
                return NotFound();
            }

            return View(artists);
        }

        // GET: Artists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Artists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Artists artists)
        {
            if (ModelState.IsValid)
            {
                _context.Add(artists);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(artists);
        }

        // GET: Artists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Artists == null)
            {
                return NotFound();
            }

            var artists = await _context.Artists.FindAsync(id);
            if (artists == null)
            {
                return NotFound();
            }
            return View(artists);
        }

        // POST: Artists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Artists artists)
        {
            if (id != artists.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(artists);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArtistsExists(artists.Id))
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
            return View(artists);
        }

        // GET: Artists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Artists == null)
            {
                return NotFound();
            }

            var artists = await _context.Artists
                .FirstOrDefaultAsync(m => m.Id == id);
            if (artists == null)
            {
                return NotFound();
            }

            return View(artists);
        }

        // POST: Artists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Artists == null)
            {
                return Problem("Entity set 'Context.Artists'  is null.");
            }
            var artists = await _context.Artists.FindAsync(id);
            if (artists != null)
            {
                _context.Artists.Remove(artists);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArtistsExists(int id)
        {
            return (_context.Artists?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
