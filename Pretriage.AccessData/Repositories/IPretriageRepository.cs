using Pretriage.Entitis.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pretriage.AccessData.Repositories
{
    public interface IPretriageRepository
    {
       
        Task AddAsync(PretriageEntity pretriageEntity);
        void DeletePretriage(int id);
        Task UpdateAsync(PretriageEntity pretriage);
        Task<PretriageEntity> Get(int id);
        Task<IReadOnlyCollection<PretriageEntity>> Gets();
        Task<IReadOnlyCollection<PretriageEntity>> GetFilter(DateTime StartDate, DateTime StopDate);
        Task<IReadOnlyCollection<PretriageEntity>> GetFilter(DateTime StartDate, DateTime StopDate, string NumberSerialPesel);
        Task<IReadOnlyCollection<PretriageEntity>> GetFilter(string NumberSerialPesel);
    }
}