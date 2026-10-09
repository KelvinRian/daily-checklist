using DailyChecklist.Domain.Entities;
using DailyChecklist.Domain.Filters;
using TreadingTask = System.Threading.Tasks.Task;

namespace DailyChecklist.Domain.Interfaces.Repositories
{
    public interface IRoutineRepository
    {
        TreadingTask AddAsync(Routine routine);
        Task<IEnumerable<Routine>> GetAllAsync(RoutineFilters filters);
        Task<Routine> GetById(Guid id);
    }
}
