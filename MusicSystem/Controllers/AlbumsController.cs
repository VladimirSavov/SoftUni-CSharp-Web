﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MusicSystem.ActionFilters;
using MusicSystem.Data;
using MusicSystem.Entities;
using MusicSystem.ExtensionMethods;
using MusicSystem.ViewModels.Album;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MusicSystem.Controllers
{
    [AuthFilter]
    public class AlbumsController : Controller
    {
        private readonly MusicSystemDbContext _context;

        public AlbumsController(MusicSystemDbContext context)
        {
            _context = context;
        }

        // GET: Albums
        public async Task<IActionResult> Index()
        {
            MusicSystemDbContext context = new MusicSystemDbContext();
            Users loggedUser = this.HttpContext.Session.GetObject<Users>("loggedUser");
            IndexVM model = new IndexVM();
            model.Items = context.Albums.Where(a => a.OwnerId == loggedUser.Id).ToList();
            return View(model);
            //return _context.Albums != null ?
            //            View(await _context.Albums.ToListAsync()) :
            //            Problem("Entity set 'Context.Albums'  is null.");
        }

        // GET: Albums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Albums == null)
            {
                return NotFound();
            }

            var albums = await _context.Albums
                .FirstOrDefaultAsync(m => m.Id == id);

            var songsIn = await _context.Songs
                .Include(s => s.Album)
                .Include(a => a.SongContributors)
                .ThenInclude(sc => sc.Artist)
                .Where(s => s.Album.Id == id)
                .ToListAsync();

            ViewBag.allSongs = songsIn;

            if (albums == null)
            {
                return NotFound();
            }

            return View(albums);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        // GET: Albums/Create
        public IActionResult Create(CreateVM model)
        {
            if (!ModelState.IsValid) { return View(model); }

            MusicSystemDbContext context = new MusicSystemDbContext();
            Users loggedUser = this.HttpContext.Session.GetObject<Users>("loggedUser");
            Albums item = new Albums();
            item.OwnerId = loggedUser.Id;
            item.Title = model.Title;

            context.Albums.Add(item);
            context.SaveChanges();

            return RedirectToAction("Index", "Albums");
            return View();
        }

        // POST: Albums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Title")] Albums albums)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(albums);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(albums);
        //}

        // GET: Albums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Albums == null)
            {
                return NotFound();
            }

            var albums = await _context.Albums.FindAsync(id);
            if (albums == null)
            {
                return NotFound();
            }
            return View(albums);
        }

        // POST: Albums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title")] Albums albums)
        {
            if (id != albums.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(albums);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlbumsExists(albums.Id))
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
            return View(albums);
        }

        // GET: Albums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Albums == null)
            {
                return NotFound();
            }

            var albums = await _context.Albums
                .FirstOrDefaultAsync(m => m.Id == id);
            if (albums == null)
            {
                return NotFound();
            }

            return View(albums);
        }

        // POST: Albums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Albums == null)
            {
                return Problem("Entity set 'Context.Albums'  is null.");
            }
            var albums = await _context.Albums.FindAsync(id);
            if (albums != null)
            {
                _context.Albums.Remove(albums);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlbumsExists(int id)
        {
            return (_context.Albums?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
