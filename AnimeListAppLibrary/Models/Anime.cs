using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeListAppLibrary.Models
{
    public class Anime
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string  Description { get; set; }
        public string PictureURL { get; set; }
        public Genre Genre { get; set; }
        public DateTime CreatedAt { get; set; }

       // public virtual List<UserAnimeList> UserAnimes { get; set; }
    }
}
