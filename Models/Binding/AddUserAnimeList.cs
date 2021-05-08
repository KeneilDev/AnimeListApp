using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListApp.Models.Binding
{
    public class AddUserAnimeList
    {
        public int Id { get; set; }
        public Status Status { get; set; }

        //Relationships 
        public virtual AppUser AppUser { get; set; }
        public virtual Anime Anime { get; set; }
    }
}
