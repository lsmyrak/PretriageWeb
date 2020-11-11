using Microsoft.EntityFrameworkCore;
using Pretriage.Context;
using Pretriage.Entitis.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pretriage.AccessData.Repositories
{
    public class PretriageRepository : IPretriageRepository
    {    
        private readonly PretriageContext _context;

        public PretriageRepository(PretriageContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyCollection<PretriageEntity>> GetFilter(DateTime StartDate, DateTime StopDate) =>
            await _context.Pretriage
                .Where(x => x.Data_Od >= StartDate && x.Data_Od <= StopDate && (x.Status == true))
                .OrderByDescending(x => x.Id).ToArrayAsync();


        public async Task<IReadOnlyCollection<PretriageEntity>> GetFilter(DateTime StartDate, DateTime StopDate, string NumberSerialPesel) =>
            await _context.Pretriage
                .Where(x => x.Data_Od >= StartDate && x.Data_Od <= StopDate && (x.Pesel.Contains(NumberSerialPesel)
                || x.NumerSeria.Contains(NumberSerialPesel) || x.InnyDokument.Contains(NumberSerialPesel))
                && (x.Status == true)).OrderByDescending(x => x.Id).ToArrayAsync();


        public async Task<IReadOnlyCollection<PretriageEntity>> GetFilter(string NumberSerialPesel) =>
            await _context.Pretriage
                .Where(x => x.Status == true && (x.Pesel.Contains(NumberSerialPesel) || x.NumerSeria.Contains(NumberSerialPesel)
                || x.InnyDokument.Contains(NumberSerialPesel))).OrderByDescending(x => x.Id).ToArrayAsync();

        public async Task<IReadOnlyCollection<PretriageEntity>> Gets() =>
            await _context.Pretriage
                .Where(x => x.Status == true).OrderByDescending(x => x.Id).ToArrayAsync();


        public async Task AddAsync(PretriageEntity pretriageEntity)
        {
            await _context.Pretriage.AddAsync(pretriageEntity);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(PretriageEntity pretriage)
        {
            _context.Pretriage.Update(pretriage);
            await _context.SaveChangesAsync();             
        }
            public async Task<PretriageEntity> Get(int id)
            {
                return await _context.Pretriage.FindAsync(id);
            }


            public void DeletePretriage(int id)
            {
                var pretriage = _context.Pretriage.FirstOrDefault(x => x.Id == id);
                pretriage.SetStatus(false);
                _context.Pretriage.Update(pretriage);
                _context.SaveChanges();
            }
        }
    }

