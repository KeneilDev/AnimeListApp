using AnimeListApp.Models;
using AnimeListApp.Models.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListApp.Utility
{
    public static class UserAnimeListUtility
    {
        public static UserAnimeListViewModel GetViewModel(this UserAnimeList useranime)
        {
            var UserAnimeListVM = new UserAnimeListViewModel()
            {
                Id = useranime.Id,
                Status = useranime.Status
            };

            return UserAnimeListVM;
        }

        public static List<UserAnimeListViewModel> GetViewModels(this List<UserAnimeList> useranimes)
        {
            var allUserAnimeListVM = new List<UserAnimeListViewModel>();
            foreach (var useranime in useranimes)
            {
                allUserAnimeListVM.Add(new UserAnimeListViewModel()
                {
                    Id = useranime.Id,
                    Status = useranime.Status
                });
            }
            return allUserAnimeListVM;
        }
    }
}
