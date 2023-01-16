using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class OriginDto
    {
        /// <summary>
        /// The name of the origin.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The type of the origin.
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// The dimension of the origin.
        /// </summary>
        public string Dimension { get; set; }
    }
}
