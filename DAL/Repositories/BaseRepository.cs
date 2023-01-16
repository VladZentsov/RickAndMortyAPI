using DAL.Entities;
using DAL.Validation;
using Microsoft.Extensions.Caching.Memory;
using Nancy;
using Nancy.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public abstract class BaseRepository
    {
        protected string _baseURL;
        protected HttpClient _client;
        JavaScriptSerializer _serializer;
        protected IMemoryCache _cache;
        public BaseRepository(string baseURL, IMemoryCache memoryCache)
        {
            _baseURL = baseURL;
            _client = new HttpClient();
            _serializer = new JavaScriptSerializer();
            var f = new Uri(baseURL);
            _cache = memoryCache;
        }

        public async Task<T> GetByRawLinkGeneric<T>(string path) where T : class
        {
            T entity = null;

            if (!_cache.TryGetValue(path, out entity))
            {
                var response = await _client.GetAsync(path);

                if (!response.IsSuccessStatusCode)
                    throw new EmptyResponseException("Not successed response" + path);

                entity = JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());

                if (entity != null)
                    _cache.Set(path, entity, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(5)));

            }

            return entity;
        }

        protected async Task<IEnumerable<T>> GetFromAllPages<T>(string url)
        {
            var result = new List<T>();

            while (url != null)
            {
                var page = await GetByRawLinkGeneric<Page<T>>(url);

                result.AddRange(page.Results);

                url = page.Info.Next;
            }

            return result;
        }

        protected async Task<IEnumerable<T>> GetEntityByURL<T>(string url)
        {
            string fullURL = _baseURL + url;

            var entities = await GetFromAllPages<T>(fullURL);

            return entities;
        }
    }
}
