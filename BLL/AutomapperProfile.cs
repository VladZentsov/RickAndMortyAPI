using AutoMapper;
using BLL.Models;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AutomapperProfile: Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Person, PersonDto>();

            CreateMap<Episode, EpisodeDto>()
                .ReverseMap();

            CreateMap<(Person, Location), PersonWithOrigin>()
                .ForMember(p => p.Name, c => c.MapFrom(model => model.Item1.Name))
                .ForMember(p => p.Status, c => c.MapFrom(model => model.Item1.Status))
                .ForMember(p => p.Species, c => c.MapFrom(model => model.Item1.Species))
                .ForMember(p => p.Gender, c => c.MapFrom(model => model.Item1.Gender))
                .ForMember(p => p.Status, c => c.MapFrom(model => model.Item1.Status))
                .ForMember(p => p.Type, c => c.MapFrom(model => model.Item1.Type))
                .ForPath(p => p.Origin.Name, c => c.MapFrom(model => model.Item1.Origin.Name))
                .ForPath(p => p.Origin.Type, c => c.MapFrom(model => model.Item2.Type))
                .ForPath(p => p.Origin.Dimension, c => c.MapFrom(model => model.Item2.Dimension));

        }
    }
}
