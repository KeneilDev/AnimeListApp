using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AnimeListApp.Data;
using AnimeListApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace AnimeListApp.Controllers
{
    [Authorize]
    public class UserAnimeListsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;


        public UserAnimeListsController(ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            this._context = context;
            this._userManager = userManager;
        }

        // GET: UserAnimeLists
        public async Task<IActionResult> Index()
        {
            //User Id
            AppUser user = await _userManager.GetUserAsync(HttpContext.User);

            IQueryable<UserAnimeList> userAnimes = from i in _context.UserAnimes
                                                   .Include(u => u.Anime)
                                                   .Include(u => u.AppUser)
                                                   where i.AppUser.Id == user.Id
                                                   orderby i.Id
                                                   select i;

            return View(userAnimes);
        }

        // GET: UserAnimeLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userAnimeList = await _context.UserAnimes
                .Include(u => u.Anime)
                .Include(u => u.AppUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userAnimeList == null)
            {
                return NotFound();
            }

            return View(userAnimeList);
        }

        // GET: UserAnimeLists/Create
        public async Task<IActionResult> CreateAsync(int? id)
        {
            AppUser user = await _userManager.GetUserAsync(HttpContext.User);
            var animeById = _context.Anime
            .FirstOrDefault(a => a.Id == id);

            ViewData["AnimeId"] = animeById.Id;
            ViewData["PictureURL"] = animeById.PictureURL;
            ViewData["AppUserId"] = user.Id;
            return View();
        }

        // POST: UserAnimeLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Status,AppUserId,AnimeId")] UserAnimeList userAnimeList)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(userAnimeList);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            catch
            {
               return RedirectToAction("Index");
            }
        }

        // GET: UserAnimeLists/Edit/5
        public async Task<IActionResult> EditAsync(int? id)
        {

            AppUser user = await _userManager.GetUserAsync(HttpContext.User);
            try
            {
                var userAnimeById = _context.UserAnimes.FirstOrDefault(ua => ua.Id == id);

                if (user.Id == userAnimeById.AppUserId && id != null)
                {

                    return View(userAnimeById);
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return NotFound();
            }
        }

        // POST: UserAnimeLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(UserAnimeList useranime, int id, [Bind("Id,Status,AppUserId,AnimeId")] UserAnimeList userAnimeList)
        {
            var userAnimeToUpdate = _context.UserAnimes.FirstOrDefault(a => a.Id == id);
            userAnimeToUpdate.Status = useranime.Status;
    
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: UserAnimeLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userAnimeList = await _context.UserAnimes
                .Include(u => u.Anime)
                .Include(u => u.AppUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userAnimeList == null)
            {
                return NotFound();
            }

            return View(userAnimeList);
        }

        // POST: UserAnimeLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userAnimeList = await _context.UserAnimes.FindAsync(id);
            _context.UserAnimes.Remove(userAnimeList);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserAnimeListExists(int id)
        {
            return _context.UserAnimes.Any(e => e.Id == id);
        }
    }
}
