using AnimeListApp.Data;
using AnimeListApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListApp.Models.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        ApplicationDbContext _repoContext;

        public RepositoryWrapper(ApplicationDbContext repoContext)
        {
            _repoContext = repoContext;
        }
        IAnimeRepository _anime;
        
        public IAnimeRepository Anime
        {
            get
            {
                if (_anime == null)
                {
                    _anime = new AnimeRepository(_repoContext);
                }
                return _anime;
            }
        }
        void IRepositoryWrapper.Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
