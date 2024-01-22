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
using MusicSystem.ExtensionMethods;
using MusicSystem.ViewModels.Song;

namespace MusicSystem.Controllers
{
    [AuthFilter]
    public class SongsController : Controller
    {
        private readonly MusicSystemDbContext _context;

        public SongsController(MusicSystemDbContext context)
        {
            _context = context;
        }

        // GET: Songs
        public async Task<IActionResult> Index()
        {

            var playlists = _context.Playlists.ToList();

            ViewBag.listPlaylist = new SelectList(playlists, "Id", "Name");
            MusicSystemDbContext context = new MusicSystemDbContext();
            Users loggedUser = this.HttpContext.Session.GetObject<Users>("loggedUser");
            IndexVM model = new IndexVM();
            model.Items = context.Songs.Where(a => a.OwnerId == loggedUser.Id).ToList();
            return View(model);
            //return _context.Songs != null ?
            //            View(await _context.Songs.ToListAsync()) :
            //            Problem("Entity set 'Context.Songs'  is null.");
        }

        // GET: Songs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Songs == null)
            {
                return NotFound();
            }

            var songs = await _context.Songs
                .FirstOrDefaultAsync(m => m.Id == id);

            if (songs == null)
            {
                return NotFound();
            }

            return View(songs);
        }

        // GET: Songs/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToPlaylist(int songId, int playlistId)
        {
            if (songId == null || playlistId == null || _context.Songs == null)
            {
                return NotFound();
            }

            PlaylistSong addedSong = new PlaylistSong(songId, playlistId);

            _context.Add(addedSong);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Songs");
        }

        [HttpPost]
        // GET: Albums/Create
        public IActionResult Create(CreateVM model)
        {
            if (!ModelState.IsValid) { return View(model); }

            MusicSystemDbContext context = new MusicSystemDbContext();
            Users loggedUser = this.HttpContext.Session.GetObject<Users>("loggedUser");
            Songs item = new Songs();
            item.OwnerId = loggedUser.Id;
            item.Title = model.Title;
            item.Duration = model.Duration;

            context.Songs.Add(item);
            context.SaveChanges();

            return RedirectToAction("Index", "Songs");
            return View();
        }
        // POST: Songs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Title,Duration")] Songs songs)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(songs);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(songs);
        //}

        // GET: Songs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Songs == null)
            {
                return NotFound();
            }

            var songs = await _context.Songs.FindAsync(id);
            if (songs == null)
            {
                return NotFound();
            }
            return View(songs);
        }

        // POST: Songs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Duration")] Songs songs)
        {
            if (id != songs.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(songs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SongsExists(songs.Id))
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
            return View(songs);
        }

        // GET: Songs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Songs == null)
            {
                return NotFound();
            }

            var songs = await _context.Songs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (songs == null)
            {
                return NotFound();
            }

            return View(songs);
        }

        // POST: Songs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Songs == null)
            {
                return Problem("Entity set 'Context.Songs'  is null.");
            }
            var songs = await _context.Songs.FindAsync(id);
            if (songs != null)
            {
                _context.Songs.Remove(songs);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SongsExists(int id)
        {
            return (_context.Songs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
