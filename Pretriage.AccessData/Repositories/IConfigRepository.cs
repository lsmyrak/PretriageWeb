using Pretriage.Entitis.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pretriage.AccessData.Repositories
{
    public interface IConfigRepository
    {
        /// <summary>
        /// Get first or default Unit object. always  is one true.
        /// </summary>
        /// <returns>Unit object with status true</returns>
        Task<Config> GetAsync();
        /// <summary>
        /// Add new config.
        /// </summary>
        /// <param name="newconfig"></param>
        /// <returns></returns>
        Task AddAsync(Config newconfig);
        /// <summary>
        /// Delete config
        /// </summary>
        /// <param name="Id"></param>
        void Delete(int Id);
        /// <summary>
        /// Update config
        /// </summary>
        /// <param name="updateConfig"></param>
        /// <returns></returns>
        Task UpdateAsync(Config updateConfig);
        /// <summary>
        /// Get config
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<Config> GetAsync(int Id);

        /// <summary>
        /// Get all config where idDeleted is false
        /// </summary>
        /// <returns>Config list</returns>
        Task<IReadOnlyCollection<Config>> Gets();
        /// <summary>
        /// Update range config list 
        /// </summary>
        /// <param name="configList"></param>
        /// <returns></returns>
        Task UpdateRangeAsync(Config configList);
    }
}