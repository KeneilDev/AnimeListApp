using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeListAppLibrary.Models
{
    public class UserAnimeList
    {
        public int Id { get; set; }
        public Status Status { get; set; }

        //Relationships 
        public virtual AppUser AppUser { get; set; }
        public virtual Anime Anime { get; set; }
    }
}
