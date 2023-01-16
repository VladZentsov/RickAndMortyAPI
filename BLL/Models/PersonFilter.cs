using DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class PersonFilter
    {
        /// <summary>
        /// The name of the person.
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// The status of the person.
        /// </summary>
        public string? Status { get; set; }
        /// <summary>
        /// The species of the person.
        /// </summary>
        public string? Species { get; set; }
        /// <summary>
        /// The type of the person.
        /// </summary>
        public string? Type { get; set; }
        /// <summary>
        /// The gender of the person.
        /// </summary>
        public CharacterGender? Gender { get; set; }
    }
}
