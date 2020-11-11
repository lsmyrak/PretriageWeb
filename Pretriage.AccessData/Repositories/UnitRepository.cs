using Microsoft.EntityFrameworkCore;
using Pretriage.Context;
using Pretriage.Entitis.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pretriage.AccessData.Repositories
{
    public class UnitRepository : IUnitRepository
    {
        private readonly  PretriageContext _context;
        public UnitRepository(PretriageContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Unit unit)
        {
            _context.Unit.Add(unit);
            await _context.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            var unit = _context.Unit.FirstOrDefault(x => x.Id == id);
            unit.Status = false;
            _context.SaveChanges();
        }

        public async Task UpdateAsync(Unit unit)
        {
            _context.Unit.Update(unit);
            await _context.SaveChangesAsync();
        }


        public async Task<IReadOnlyCollection<Unit>> GetUnits() =>
            await _context.Unit.Where(x => x.Status).ToListAsync();

        public async Task<Unit> GetAsync(int id) =>
            await _context.Unit.FindAsync(id);

       
    }
}

