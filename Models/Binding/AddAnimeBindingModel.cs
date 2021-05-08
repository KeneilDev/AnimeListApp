using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListApp.Models.Binding
{
    public class AddAnimeBindingModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureURL { get; set; }
        public Genre Genre { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
