using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListApp.Interfaces
{
    public interface IRepositoryWrapper
    {
        IAnimeRepository Anime { get; }
        void Save();
    }
}
