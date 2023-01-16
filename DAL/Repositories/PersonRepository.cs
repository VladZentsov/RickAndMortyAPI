using DAL.Entities;
using DAL.Interfaces;
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
    public class PersonRepository : BaseRepository, IPersonRepository
    {
        public PersonRepository(IMemoryCache memoryCache, string baseURL = "https://rickandmortyapi.com/api/") : base(baseURL, memoryCache)
        {
        }

        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            var persons = await GetFromAllPages<Person>(_baseURL+"character/");


            return persons;
        }

        public async Task<Person> GetByIdAsync(int id)
        {
            var person = await GetByRawLinkGeneric<Person>(_baseURL + "character/" + id);

            return person;
        }

        public async Task<IEnumerable<Person>> GetPersonsByURL(string personURL)
        {
            return await GetEntityByURL<Person>(personURL);
        }

        public async Task<Person> GetByRawLink(string url)
        {
            var result = await base.GetByRawLinkGeneric<Person>(url);

            return result;
        }
    }
}
