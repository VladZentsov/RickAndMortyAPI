using BLL.Models;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IPersonEpisodeService
    {
        /// <summary>
        /// Сhecks if the person is in the episode.
        /// </summary>
        /// <returns>True if there is a person in episode. False if there is no person in episode.</returns>
        public Task<bool> IsPersonInEpisode(CheckPeronModel checkPeronModel);
        /// <summary>
        /// Get person by name
        /// </summary>
        /// <returns>Person.</returns>
        public Task<PersonWithOrigin> GetPersonWithOriginByName(string name);

    }
}
