using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ILocationRepository : IRepository<Location>
    {
        public Task<IEnumerable<Location>> GetLocationsByURL(string locationURL);
    }
}
