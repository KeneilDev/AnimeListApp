using AnimeListAppLibrary.Models;
using AnimeListAppLibrary.Models.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListAppLibrary.Utility
{
    public static class AnimeUtility
    {
        public static AnimeViewModel GetViewModel(this Anime anime)
        {
            var animeVm = new AnimeViewModel()
            {
                ID = anime.ID,
                Name = anime.Name,
                Description = anime.Description,
                PictureURL = anime.PictureURL,
                Genre = anime.Genre,
                CreatedAt = anime.CreatedAt
            };
            return animeVm;
        }

        public static List<AnimeViewModel> GetViewModels(this List<AnimeViewModel> animes)
        {
            var allAnimesVM = new List<AnimeViewModel>();
            foreach (var anime in animes)
            {
                allAnimesVM.Add(new AnimeViewModel()
                {
                    ID = anime.ID,
                    Name = anime.Name,
                    Description = anime.Description,
                    PictureURL = anime.PictureURL,
                    Genre = anime.Genre,
                    CreatedAt = anime.CreatedAt
                });
            }
            return allAnimesVM;
        }
    }
}
