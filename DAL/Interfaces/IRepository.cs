using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        /// <summary>
        /// Get all entities asynchronously.
        /// </summary>
        /// <returns>Entities enumerable.</returns>
        Task<IEnumerable<TEntity>> GetAllAsync();

        /// <summary>
        /// Get a single entity.
        /// </summary>
        /// <param name="id">Id of character.</param>
        /// <returns>Entity.</returns>
        Task<TEntity> GetByIdAsync(int id);

        /// <summary>
        /// Get a single entity.
        /// </summary>
        /// <param name="path">URL path of entity.</param>
        /// <returns>Entity.</returns>
        Task<TEntity> GetByRawLink(string path);
    }
}
