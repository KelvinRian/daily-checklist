using DailyChecklist.Domain.Entities;
using DailyChecklist.Domain.Filters;
using DailyChecklist.Domain.Interfaces.Repositories;
using DailyChecklist.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IEnumerable<Routine>> GetAllAsync(RoutineFilters routineFilters)
        {
            //TODO
            // Apply Filters
            var routines = await _context
                .Routines
                .Where(x => x.Active)
                .ToListAsync();

            return routines;
        }
    }
}
