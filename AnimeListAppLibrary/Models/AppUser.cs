using AnimeListAppLibrary.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeListAppLibrary.Models
{
    public class AppUser : IdentityUser<int>
    {
        [PersonalData, Required, StringLength(20)]
        public string FirstName { get; set; }
        [PersonalData, Required, StringLength(20)]
        public string LastName { get; set; }
        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }
        public virtual List<UserAnimeList> UserAnimes { get; set; }
    }
}
