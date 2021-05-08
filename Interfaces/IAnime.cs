using AnimeListApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeListApp.Interfaces
{
    public interface IAnime
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureURL { get; set; }
        public Genre Genre { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
