using DAL.Entities;
using DAL.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class EpisodeRepository : BaseRepository, IEpisodeRepository
    {
        public EpisodeRepository(IMemoryCache memoryCache, string baseURL = "https://rickandmortyapi.com/api/") : base(baseURL, memoryCache)
        {
        }

        public async Task<IEnumerable<Episode>> GetAllAsync()
        {
            var episodes = await GetFromAllPages<Episode>(_baseURL + "episode/");


            return episodes;
        }

        public async Task<Episode> GetByIdAsync(int id)
        {
            Episode episode = null;

            if (!_cache.TryGetValue(id, out episode))
            {
                episode = await GetByRawLinkGeneric<Episode>(_baseURL + "episode/" + id);

                if(episode != null)
                    _cache.Set(id, episode, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(5)));
            }

            return episode;
        }

        public async Task<IEnumerable<Episode>> GetEpisodesByURL(string personURL)
        {
            return await GetEntityByURL<Episode>(personURL);
        }

        public async Task<Episode> GetByRawLink(string url)
        {
            var result = await base.GetByRawLinkGeneric<Episode>(url);

            return result;
        }



    }
}
