using AnimeListApp.Data;
using AnimeListApp.Models;
using AnimeListApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListApp.Models.Repositories
{
    public class AnimeRepository : Repository<Anime>, IAnimeRepository
    {
        public AnimeRepository(ApplicationDbContext dbContext) : base (dbContext)
        {

        }
    }

}
