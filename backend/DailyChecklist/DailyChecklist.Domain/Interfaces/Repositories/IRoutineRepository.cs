using DailyChecklist.Domain.Entities;
using TreadingTask = System.Threading.Tasks.Task;

namespace DailyChecklist.Domain.Interfaces.Repositories
{
    public interface IRoutineRepository
    {
        TreadingTask AddAsync(Routine routine);
    }
}
