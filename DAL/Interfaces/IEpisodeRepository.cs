using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IEpisodeRepository: IRepository<Episode>
    {
        public Task<IEnumerable<Episode>> GetEpisodesByURL(string personURL);
    }
}
