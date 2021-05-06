using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeListApp.Models
{
    public class UserAnimeList
    {
        public int Id { get; set; }
        public Status Status { get; set; }

        //Relationships 
        public int AppUserId { get; set; }
        public  AppUser AppUser { get; set; }
        public int AnimeId { get; set; }
        public Anime Anime { get; set; }
    }
}
