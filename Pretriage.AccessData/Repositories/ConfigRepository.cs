using Microsoft.EntityFrameworkCore;
using Pretriage.Context;
using Pretriage.Entitis.Model;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pretriage.AccessData.Repositories
{
    public class ConfigRepository : IConfigRepository
    {
        private PretriageContext _context;
        public ConfigRepository(PretriageContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Config config)
        {
            await _context.Config.AddAsync(config);
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyCollection<Config>> Gets() =>
             await _context.Config.Where(x => !x.IsDeleted).ToArrayAsync();



        public async Task<Config> GetAsync(int Id) =>
            await _context.Config.FindAsync(Id);

        public async Task<Config> GetAsync() =>
            await _context.Config.FirstOrDefaultAsync(x => x.Status);

        /// <summary>
        /// move to Service. !!
        /// </summary>
        /// <param name="updateConfig"></param>
        /// <returns></returns>
        public async Task UpdateAsync(Config updateConfig)
        {
            var configOld = _context.Config.FirstOrDefault(x => x.Id == updateConfig.Id);
            if (configOld != null)
            {
                configOld.SetDeleted(true);
                await _context.Config.AddAsync(updateConfig);
            }
            await _context.SaveChangesAsync();
        }


        public Task UpdateRangeAsync(Config configList)
        {                        
            _context.Config.Update(configList);            
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        public void Delete(int Id)
        {
            Config model = _context.Config.FirstOrDefault(x => x.Id == Id);
            model.SetDeleted(true);
            _context.SaveChanges();
        }


    }
}