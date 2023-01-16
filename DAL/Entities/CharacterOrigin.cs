using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class CharacterOrigin
    {
        /// <summary>
        /// Name to the character's origin location.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Link to the character's origin location.
        /// </summary>
        public string Url { get; set; }
    }
}
