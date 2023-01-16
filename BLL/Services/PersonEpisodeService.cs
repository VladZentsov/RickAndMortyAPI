using AutoMapper;
using BLL.Helpers;
using BLL.Interfaces;
using BLL.Models;
using BLL.Validation;
using DAL.Entities;
using DAL.UnitOfWork;

namespace BLL.Services
{
    public class PersonEpisodeService: IPersonEpisodeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PersonEpisodeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<PersonWithOrigin> GetPersonWithOriginByName(string name)
        {
            var personFilter = new PersonFilter() { Name = name };
            var person = (await GetFilteredPersons(personFilter)).FirstOrDefault();

            var location = (await _unitOfWork.LocationsRepository.GetByRawLink(person.Origin.Url));

            var personWithOrigin = _mapper.Map<(Person, Location), PersonWithOrigin>((person, location));

            return personWithOrigin;

        }

        public async Task<bool> IsPersonInEpisode(CheckPeronModel checkPeronModel)
        {
            if (checkPeronModel.PersonName == "" || checkPeronModel.PersonName == null)
                throw new FilterNullException("Filter fields is empty", "PersonName");

            if (checkPeronModel.EpisodeName == "" || checkPeronModel.EpisodeName == null)
                throw new FilterNullException("Filter fields is empty", "EpisodeName");

            var personFilter = new PersonFilter() { Name = checkPeronModel.PersonName };
            var episodeFilter = new EpisodeFilter() { Name = checkPeronModel.EpisodeName };

            var personsIds = (await GetFilteredPersons(personFilter)).Select(x => x.Id);
            var episodesPersons = (await GetFilteredEpisodes(episodeFilter)).SelectMany(x => x.Characters).Distinct();

            bool result = false;

            foreach (var personURL in episodesPersons)
            {
                var str = personURL.Substring(personURL.LastIndexOf('/') + 1);
                int personId = Convert.ToInt32(personURL.Substring(personURL.LastIndexOf('/')+1));

                if (personsIds.Contains(personId))
                {
                    result = true;
                    break;
                }
            }

            return result;
        }

        private async Task<IEnumerable<Person>> GetFilteredPersons(PersonFilter personFilter)
        {
            var personURL = FilterHelper.GetFilteredPersonURL(personFilter);

            if (personURL == "")
                return await _unitOfWork.PersonRepository.GetAllAsync();

            //var fullPersonURL = "https://rickandmortyapi.com/api/" + personURL;

            var persons = await _unitOfWork.PersonRepository.GetPersonsByURL(personURL);

            if (persons == null)
                throw new EntityNorFoundException("Persons not found", "persons");

            return persons;
        }

        private async Task<IEnumerable<Episode>> GetFilteredEpisodes(EpisodeFilter episodeFilter)
        {
            var episodeURL = FilterHelper.GetFilteredEpisodeURL(episodeFilter);

            if (episodeURL == "")
                return await _unitOfWork.EpisodeRepository.GetAllAsync();

            //var fullEpisodeURL = "https://rickandmortyapi.com/api/" + episodeURL;

            var episodes = await _unitOfWork.EpisodeRepository.GetEpisodesByURL(episodeURL);

            if (episodes == null)
                throw new EntityNorFoundException("Episodes not found", "episodes");

            return episodes;
        }


    }
}
