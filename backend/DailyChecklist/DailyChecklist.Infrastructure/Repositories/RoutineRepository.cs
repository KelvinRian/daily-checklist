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
            var routines = _context
                .Routines
                .Where(x => x.Active);

            routines = ApplyPagination(routines, routineFilters);
            routines = ApplyOptionalFilters(routines, routineFilters);

            return await routines.ToListAsync();
        }

        private static IQueryable<Routine> ApplyPagination(IQueryable<Routine>? query, RoutineFilters routineFilters)
        {
            if (routineFilters.Page.HasValue && routineFilters.PageSize.HasValue)
            {
                query = query
                    .Skip((routineFilters.Page.Value - 1) * routineFilters.PageSize.Value)
                    .Take(routineFilters.PageSize.Value);
            }
            return query;
        }

        private static IQueryable<Routine> ApplyOptionalFilters(IQueryable<Routine>? query, RoutineFilters routineFilters)
        {
            if (!string.IsNullOrEmpty(routineFilters.Name))
            {
                query = query
                    .Where(x => x.Name.Contains(routineFilters.Name));
            }
            return query;
        }

        public async Task<Routine> GetById(Guid id)
        {
            var routine = await _context
                .Routines
                .Include(x => x.Items)
                    .ThenInclude(x => (x as GroupItem)!.GroupTasks)
                .Include(x => x.ActivePeriods)
                .FirstOrDefaultAsync(x => x.Active && x.Id == id);

            return routine;
        }
    }
}
