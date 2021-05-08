using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnimeListApp.Data;
using AnimeListApp.Models;
using AnimeListApp.Interfaces;
using AnimeListApp.Models.Binding;
using AnimeListApp.Utility;

namespace AnimeListApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimesAPIController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        private IRepositoryWrapper repository;

        public AnimesAPIController(IRepositoryWrapper repositoryWrapper)
        {
            repository = repositoryWrapper;
        }

        // GET: api/AnimesAPI
        [HttpGet]
        public IEnumerable<Anime> GetAnime()
        {
            var allAnimes = repository.Anime.FindAll();
            return allAnimes;
            //return await _context.Anime.ToListAsync();
        }

        //GET: api/AnimesAPI/5
        [HttpGet("{id}")]
        public ActionResult<Anime> GetAnime(int id)
        {
            var anime = repository.Anime.FindbyCondition(a => a.Id == id).FirstOrDefault();
            //var anime = await _context.Anime.FindAsync(id);

            if (anime == null)
            {
                return NotFound();
            }

            return Ok(anime.GetViewModel());
        }

        // PUT: api/AnimesAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutAnime(int id,[FromBody] UpdateAnimeBindingModel bindingModel)
        {
            var animeToUpdate = repository.Anime.FindbyCondition(a => a.Id == id).FirstOrDefault();

            if (animeToUpdate == null)
            {
                return NotFound();
            }

            animeToUpdate.Name = bindingModel.Name;
            animeToUpdate.Description = bindingModel.Description;
            animeToUpdate.PictureURL = bindingModel.PictureURL;
            animeToUpdate.Genre = bindingModel.Genre;
            animeToUpdate.CreatedAt = bindingModel.CreatedAt;

            try
            {
                repository.Anime.Update(animeToUpdate);
                repository.Save();
                return Ok(animeToUpdate.GetViewModel());
            }
            catch (DbUpdateConcurrencyException)
            {
               
            }

            return NoContent();
        }

        // POST: api/AnimesAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Anime> PostAnime([FromBody] AddAnimeBindingModel bindingModel)
        {
            var animetoAdd = new Anime
            {
                Name = bindingModel.Name,
                Description = bindingModel.Description,
                PictureURL = bindingModel.PictureURL,
                Genre = bindingModel.Genre,
                CreatedAt = bindingModel.CreatedAt
            };

            var createdAnime = repository.Anime.Create(animetoAdd);
            repository.Save();

            return Ok(animetoAdd);
        }

        // DELETE: api/AnimesAPI/5
        [HttpDelete("{id}")]
        public IActionResult DeleteAnime(int id)
        {
            var animeToDelete = repository.Anime.FindbyCondition(a => a.Id == id).FirstOrDefault();
            if (animeToDelete == null)
            {
                return NotFound();
            }

            repository.Anime.Delete(animeToDelete);
            repository.Save();
            return Ok("Anime Deleted");
        }

       // private bool AnimeExists(int id)
       // {
            //return _context.Anime.Any(e => e.Id == id);
     //   }
    }
}
