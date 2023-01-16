using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private IPersonRepository _personRepository;
        private IEpisodeRepository _episodeRepository;
        private ILocationRepository _locationRepository;
        private IMemoryCache _memoryCache;
        private string _baseURL;
        public UnitOfWork(IMemoryCache memoryCache, string baseURL = "https://rickandmortyapi.com/api/")
        {
            _baseURL = baseURL;
            _memoryCache = memoryCache;
        }
        public IPersonRepository PersonRepository
        {
            get
            {
                if(_personRepository == null)
                {
                    _personRepository = new PersonRepository(_memoryCache, _baseURL);
                }
                return _personRepository;
            }
        }
        public IEpisodeRepository EpisodeRepository
        {
            get
            {
                if (_episodeRepository == null)
                {
                    _episodeRepository = new EpisodeRepository(_memoryCache, _baseURL);
                }
                return _episodeRepository;
            }
        }

        public ILocationRepository LocationsRepository
        {
            get
            {
                if (_locationRepository == null)
                {
                    _locationRepository = new LocationRepository(_memoryCache, _baseURL);
                }
                return _locationRepository;
            }
        }
    }
}
