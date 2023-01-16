using BLL.Interfaces;
using BLL.Models;
using BLL.Services;
using DAL.Entities;
using DAL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RickAndMortyAPI.Filters;

namespace RickAndMortyAPI.Controllers
{
    [Route("api/v1")]
    [ApiController]
    [NotFoundExceptionFilterAttribute]
    public class PersonController : ControllerBase
    {
        private readonly IPersonEpisodeService _personEpisodeService;
        private JsonSerializerSettings _serializerSettings;
        public PersonController(IPersonEpisodeService personEpisodeService)
        {
            _personEpisodeService = personEpisodeService;
            _serializerSettings = new JsonSerializerSettings();
            _serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }

        [HttpPost("check-person")]
        public async Task<ActionResult<bool>> CheckPerson(CheckPeronModel checkPeronModel)
        {
            bool result = await _personEpisodeService.IsPersonInEpisode(checkPeronModel);

            return Content(JsonConvert.SerializeObject(result, _serializerSettings));
        }

        [HttpGet("person")]
        public async Task<ActionResult<PersonWithOrigin>> GetPersonWithOrigin(string name)
        {
            var result = await _personEpisodeService.GetPersonWithOriginByName(name);

            return Content(JsonConvert.SerializeObject(result, _serializerSettings));
        }



    }
}
