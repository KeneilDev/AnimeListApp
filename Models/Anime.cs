using AnimeListApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeListApp.Models
{
    public class Anime
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string  Description { get; set; }
        public string PictureURL { get; set; }
        public Genre Genre { get; set; }
        [DisplayName("Date Created")]
        public DateTime CreatedAt { get; set; }
        public virtual ICollection<UserAnimeList> UserAnimes { get; set; }
    }
}
