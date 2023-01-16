using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IPersonRepository PersonRepository { get; }
        public IEpisodeRepository EpisodeRepository { get; }
        public ILocationRepository LocationsRepository { get; }
    }
}
