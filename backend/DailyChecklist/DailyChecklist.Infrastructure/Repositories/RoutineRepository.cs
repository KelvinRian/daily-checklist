using DailyChecklist.Domain.Entities;
using DailyChecklist.Domain.Interfaces.Repositories;
using DailyChecklist.Infrastructure.Context;

namespace DailyChecklist.Infrastructure.Repositories
{
    public class RoutineRepository : IRoutineRepository
    {
        private DailyChecklistContext _context;

        public RoutineRepository(DailyChecklistContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Routine routine)
        {
            await _context.Routines.AddAsync(routine);
            await _context.SaveChangesAsync();
        }
    }
}
