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
    public class LocationRepository: BaseRepository, ILocationRepository
    {
        public LocationRepository(IMemoryCache memoryCache, string baseURL = "https://rickandmortyapi.com/api/") : base(baseURL, memoryCache)
        {
        }

        public async Task<IEnumerable<Location>> GetAllAsync()
        {
            var locations = await GetFromAllPages<Location>(_baseURL + "location/");


            return locations;
        }

        public async Task<Location> GetByIdAsync(int id)
        {
            var location = await GetByRawLinkGeneric<Location>(_baseURL + "location/" + id);

            return location;
        }

        public async Task<IEnumerable<Location>> GetLocationsByURL(string locationURL)
        {
            return await GetEntityByURL<Location>(locationURL);
        }
        public async Task<Location> GetByRawLink(string url)
        {
            var result = await base.GetByRawLinkGeneric<Location>(url);

            return result;
        }
    }
}
