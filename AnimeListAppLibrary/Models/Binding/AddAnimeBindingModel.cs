using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListAppLibrary.Models.Binding
{
    class AddAnimeBindingModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureURL { get; set; }
        public Genre Genre { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
