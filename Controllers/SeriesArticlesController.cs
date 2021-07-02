using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Crossways.Data;
using Crossways.Data.Domain;

namespace Crossways.Controllers
{
    public class SeriesPostsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SeriesPostsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SeriesPosts
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.SeriesPosts.Include(s => s.Post).Include(s => s.Series);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: SeriesPosts/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seriesPost = await _context.SeriesPosts
                .Include(s => s.Post)
                .Include(s => s.Series)
                .FirstOrDefaultAsync(m => m.PostId == id);
            if (seriesPost == null)
            {
                return NotFound();
            }

            return View(seriesPost);
        }

        // GET: SeriesPosts/Create
        public IActionResult Create()
        {
            ViewData["PostId"] = new SelectList(_context.Posts, "Id", "Id");
            ViewData["SeriesId"] = new SelectList(_context.Series, "Id", "Id");
            return View();
        }

        // POST: SeriesPosts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PostOrder,SeriesId,PostId,Id,Created,Updated")] SeriesPost seriesPost)
        {
            if (ModelState.IsValid)
            {
                _context.Add(seriesPost);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PostId"] = new SelectList(_context.Posts, "Id", "Id", seriesPost.PostId);
            ViewData["SeriesId"] = new SelectList(_context.Series, "Id", "Id", seriesPost.SeriesId);
            return View(seriesPost);
        }

        // GET: SeriesPosts/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seriesPost = await _context.SeriesPosts.FindAsync(id);
            if (seriesPost == null)
            {
                return NotFound();
            }
            ViewData["PostId"] = new SelectList(_context.Posts, "Id", "Id", seriesPost.PostId);
            ViewData["SeriesId"] = new SelectList(_context.Series, "Id", "Id", seriesPost.SeriesId);
            return View(seriesPost);
        }

        // POST: SeriesPosts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("PostOrder,SeriesId,PostId,Id,Created,Updated")] SeriesPost seriesPost)
        {
            if (id != seriesPost.PostId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(seriesPost);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SeriesPostExists(seriesPost.PostId))
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
            ViewData["PostId"] = new SelectList(_context.Posts, "Id", "Id", seriesPost.PostId);
            ViewData["SeriesId"] = new SelectList(_context.Series, "Id", "Id", seriesPost.SeriesId);
            return View(seriesPost);
        }

        // GET: SeriesPosts/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seriesPost = await _context.SeriesPosts
                .Include(s => s.Post)
                .Include(s => s.Series)
                .FirstOrDefaultAsync(m => m.PostId == id);
            if (seriesPost == null)
            {
                return NotFound();
            }

            return View(seriesPost);
        }

        // POST: SeriesPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var seriesPost = await _context.SeriesPosts.FindAsync(id);
            _context.SeriesPosts.Remove(seriesPost);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SeriesPostExists(long id)
        {
            return _context.SeriesPosts.Any(e => e.PostId == id);
        }
    }
}
