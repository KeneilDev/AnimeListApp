using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeListApp.Models.View
{
    public class UserAnimeListViewModel
    {
        public int Id { get; set; }
        public int AppUserId { get; set; }
        public int AnimeId { get; set; }
        public  AppUser AppUser { get; set; }
        public  Anime Anime { get; set; }
        public Status Status { get; set; }
    }
}
