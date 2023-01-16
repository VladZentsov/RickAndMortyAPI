using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IPersonRepository: IRepository<Person>
    {
        /// <summary>
        /// Get all persons bu URL.
        /// </summary>
        /// <returns>Persons enumerable.</returns>
        public Task<IEnumerable<Person>> GetPersonsByURL(string personURL);
    }
}
