using DailyChecklist.Domain.Entities;
using DailyChecklist.Domain.Filters;
using ThreadingTask = System.Threading.Tasks.Task;

namespace DailyChecklist.Domain.Interfaces.Repositories
{
    public interface IRoutineRepository
    {
        ThreadingTask AddAsync(Routine routine);
        Task<IEnumerable<Routine>> GetAllAsync(RoutineFilters filters);
        Task<Routine> GetById(Guid id);
        Task<Routine> GetByIdWithIncludes(Guid id);
        ThreadingTask UpdateAsync(Routine routine);
    }
}
