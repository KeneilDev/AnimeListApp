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
using AnimeListApp.Interfaces;

namespace AnimeListApp.Controllers
{
    public class AnimesController : Controller
    {
        //private readonly ApplicationDbContext _context;
        private IRepositoryWrapper _repo;


        public AnimesController(IRepositoryWrapper repo)
        {
            _repo = repo;
        }

        // GET: All Animes
        public IActionResult Index()
        {
            var allAnimes = _repo.Anime.FindAll();
            return View(allAnimes);
        }

        // GET: Animes/Details/5
        public IActionResult Details(int id)
        {
            //return View(_repo.Lists.FindByCondition(c => c.ID == id).FirstOrDefault());

            var animeById = _repo.Anime.FindbyCondition(c => c.Id == id).FirstOrDefault();
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
        public IActionResult Create(Anime anime)
        {
            var animeToCreate = new Anime
            {
                Name = anime.Name,
                Description = anime.Description,
                PictureURL = anime.PictureURL,
                Genre = anime.Genre,
                CreatedAt = anime.CreatedAt
            };
            _repo.Anime.Create(animeToCreate);
            _repo.Save();
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
        public  IActionResult Edit(int id)
        {

            var anime = _repo.Anime.FindbyCondition(a => a.Id == id).FirstOrDefault();
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
           
            var animeToUpdate = _repo.Anime.FindbyCondition(a => a.Id == id).FirstOrDefault();

            if (animeToUpdate != null)
            {
                animeToUpdate.Name = anime.Name;
                animeToUpdate.Description = anime.Description;
                animeToUpdate.PictureURL = anime.PictureURL;
                animeToUpdate.Genre = anime.Genre;
                animeToUpdate.CreatedAt = anime.CreatedAt;
            }
                _repo.Anime.Update(animeToUpdate);
                _repo.Save();
                return RedirectToAction("Index");
                //_context.Update(anime);
                //await _context.SaveChangesAsync();
                                
        }

        // GET: Animes/Delete/5
        public  IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anime =  _repo.Anime.FindbyCondition(m => m.Id == id).FirstOrDefault();
            if (anime == null)
            {
                return NotFound();
            }

            return View(anime);
        }

        // POST: Animes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public  IActionResult DeleteConfirmed(int id)
        {
            var anime = _repo.Anime.FindbyCondition(a => a.Id == id).FirstOrDefault();
            _repo.Anime.Delete(anime);
            _repo.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
