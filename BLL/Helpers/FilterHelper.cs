using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Helpers
{
    public static class FilterHelper
    {
        public static string GetFilteredPersonURL(PersonFilter personFilter)
        {
            string characterURL = "character/";
            string filterURL = "?";
            bool isPersonFilterNotNull = false;

            if (personFilter.Name != null)
            {
                isPersonFilterNotNull = true;
                filterURL += "name=" + personFilter.Name + "&";
            }
            if (personFilter.Status != null)
            {
                isPersonFilterNotNull = true;
                filterURL += "status=" + personFilter.Status + "&";
            }
            if (personFilter.Species != null)
            {
                isPersonFilterNotNull = true;
                filterURL += "species=" + personFilter.Species + "&";
            }
            if (personFilter.Type != null)
            {
                isPersonFilterNotNull = true;
                filterURL += "type=" + personFilter.Type + "&";
            }
            if (personFilter.Gender != null)
            {
                isPersonFilterNotNull = true;
                filterURL += "gender=" + personFilter.Gender + "&";
            }

            if (isPersonFilterNotNull)
                filterURL = filterURL.Remove(filterURL.Length - 1);
            else
                return "";

            return characterURL + filterURL;
        }

        public static string GetFilteredEpisodeURL(EpisodeFilter episodeFilter)
        {
            string episodeURL = "episode/";
            string filterURL = "?";
            bool isPEpisodeFilterNotNull = false;

            if (episodeFilter.Name != null)
            {
                isPEpisodeFilterNotNull = true;
                filterURL += "name=" + episodeFilter.Name + "&";
            }
            if (episodeFilter.EpisodeCode != null)
            {
                isPEpisodeFilterNotNull = true;
                filterURL += "episode=" + episodeFilter.EpisodeCode + "&";
            }

            if (isPEpisodeFilterNotNull)
                filterURL = filterURL.Remove(filterURL.Length - 1);
            else
                return "";

            return episodeURL + filterURL;

        }
    }
}
