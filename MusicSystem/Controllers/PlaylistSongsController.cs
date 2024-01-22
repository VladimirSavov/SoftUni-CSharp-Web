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
    public class PlaylistSongsController : Controller
    {
        private readonly MusicSystemDbContext _context;

        public PlaylistSongsController(MusicSystemDbContext context)
        {
            _context = context;
        }

        // GET: PlaylistSongs
        public async Task<IActionResult> Index()
        {
            var context = _context.PlaylistSong.Include(p => p.Playlist).Include(p => p.Song);
            return View(await context.ToListAsync());
        }

        // GET: PlaylistSongs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PlaylistSong == null)
            {
                return NotFound();
            }

            var playlistSong = _context.PlaylistSong
                .Include(p => p.Playlist)
                .Include(p => p.Song)
                .Where(m => m.PlaylistId == id);

            int totalRuntime = playlistSong
                .Sum(p => p.Song.Duration);

            ViewBag.totalDuration = totalRuntime;

            if (playlistSong == null)
            {
                return NotFound();
            }

            return View(playlistSong);
        }

        // GET: PlaylistSongs/Create
        public IActionResult Create()
        {
            ViewData["PlaylistId"] = new SelectList(_context.Playlists, "Id", "Id");
            ViewData["SongsId"] = new SelectList(_context.Songs, "Id", "Id");
            return View();
        }

        // POST: PlaylistSongs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SongsId,PlaylistId,TimeAdded")] PlaylistSong playlistSong)
        {
            if (ModelState.IsValid)
            {
                _context.Add(playlistSong);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PlaylistId"] = new SelectList(_context.Playlists, "Id", "Id", playlistSong.PlaylistId);
            ViewData["SongsId"] = new SelectList(_context.Songs, "Id", "Id", playlistSong.SongsId);
            return View(playlistSong);
        }

        // GET: PlaylistSongs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PlaylistSong == null)
            {
                return NotFound();
            }

            var playlistSong = await _context.PlaylistSong.FindAsync(id);
            if (playlistSong == null)
            {
                return NotFound();
            }
            ViewData["PlaylistId"] = new SelectList(_context.Playlists, "Id", "Id", playlistSong.PlaylistId);
            ViewData["SongsId"] = new SelectList(_context.Songs, "Id", "Id", playlistSong.SongsId);
            return View(playlistSong);
        }

        // POST: PlaylistSongs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SongsId,PlaylistId,TimeAdded")] PlaylistSong playlistSong)
        {
            if (id != playlistSong.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(playlistSong);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlaylistSongExists(playlistSong.Id))
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
            ViewData["PlaylistId"] = new SelectList(_context.Playlists, "Id", "Id", playlistSong.PlaylistId);
            ViewData["SongsId"] = new SelectList(_context.Songs, "Id", "Id", playlistSong.SongsId);
            return View(playlistSong);
        }

        // GET: PlaylistSongs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PlaylistSong == null)
            {
                return NotFound();
            }

            var playlistSong = await _context.PlaylistSong
                .Include(p => p.Playlist)
                .Include(p => p.Song)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (playlistSong == null)
            {
                return NotFound();
            }

            return View(playlistSong);
        }

        // POST: PlaylistSongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PlaylistSong == null)
            {
                return Problem("Entity set 'Context.PlaylistSong'  is null.");
            }
            var playlistSong = await _context.PlaylistSong.FindAsync(id);
            if (playlistSong != null)
            {
                _context.PlaylistSong.Remove(playlistSong);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlaylistSongExists(int id)
        {
            return (_context.PlaylistSong?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
