using Pretriage.Entitis.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pretriage.AccessData.Repositories
{
    public interface IUnitRepository
    {
        Task<IReadOnlyCollection<Unit>> GetUnits();
        Task<Unit> GetAsync(int id);
        Task UpdateAsync(Unit unit);
        Task AddAsync(Unit unit);
        void Delete(int id);
    }
}