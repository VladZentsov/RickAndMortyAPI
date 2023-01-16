using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class EpisodeFilter
    {
        /// <summary>
        /// The name of the episode.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The episode code.
        /// </summary>
        public string EpisodeCode { get; set; }
    }
}
