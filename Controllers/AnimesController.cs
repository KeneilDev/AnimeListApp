using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AnimeListApp.Data;
using AnimeListApp.Models;
using AnimeListApp.Models.Binding;

namespace AnimeListApp.Controllers
{
    public class AnimesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AnimesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: All Animes
        public IActionResult Index()
        {
            var allAnimes = _context.Anime.ToList();
            return View(allAnimes);
        }

        // GET: Animes/Details/5
        public IActionResult Details(int id)
        {
            var animeById = _context.Anime.FirstOrDefault(c => c.Id == id);
            return View(animeById);
        }

        // GET: Animes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Animes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AddAnimeBindingModel bindingModel)
        {
            var animeToCreate = new Anime
            {
                Name = bindingModel.Name,
                Description = bindingModel.Description,
                PictureURL = bindingModel.PictureURL,
                Genre = bindingModel.Genre,
                CreatedAt = bindingModel.CreatedAt
            };
            _context.Anime.Add(animeToCreate);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

            //if (ModelState.IsValid)
            //{
            //    _context.Add(anime);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            //return View(anime);
        //}

        // GET: Animes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anime = await _context.Anime.FindAsync(id);
            if (anime == null)
            {
                return NotFound();
            }
            return View(anime);
        }

        // POST: Animes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Anime anime)
        {
            if (id != anime.Id)
            {
                return RedirectToAction("Index");

                //return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var animeToUpdate = _context.Anime.FirstOrDefault(a => a.Id == id);

                    animeToUpdate.Name = anime.Name;
                    animeToUpdate.Description = anime.Description;
                    animeToUpdate.PictureURL = anime.PictureURL;
                    animeToUpdate.Genre = anime.Genre;
                    animeToUpdate.CreatedAt = anime.CreatedAt;
                    
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                    //_context.Update(anime);
                    //await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnimeExists(anime.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(anime);
        }

        // GET: Animes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anime = await _context.Anime
                .FirstOrDefaultAsync(m => m.Id == id);
            if (anime == null)
            {
                return NotFound();
            }

            return View(anime);
        }

        // POST: Animes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var anime = await _context.Anime.FindAsync(id);
            _context.Anime.Remove(anime);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnimeExists(int id)
        {
            return _context.Anime.Any(e => e.Id == id);
        }
    }
}
