using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class PersonDto
    {
        /// <summary>
        /// The id of the character.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the character.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The status of the character ('Alive', 'Dead' or 'unknown').
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// The species of the character.
        /// </summary>
        public string Species { get; set; }

        /// <summary>
        /// The type or subspecies of the character.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The gender of the character ('Female', 'Male', 'Genderless' or 'unknown').
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// Name, type and dimension of character's origin location.
        /// </summary>
        public OriginDto Origin { get; set; }

    }
}
