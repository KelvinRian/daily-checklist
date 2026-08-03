using EntityTask = DailyChecklist.Domain.Entities.Task;
using DailyChecklist.Domain.Entities;

namespace DailyChecklist.Tests.DailyChecklist.Domain.Entities
{
    public class RoutineTests
    {
        [Fact]
        public void Constructor_Should_CreateRoutine()
        {
            var name = "test routine";
            var description = "test description";

            var task1 = new EntityTask("task name", 1);
            var task2 = new EntityTask("task name 2", 2);
            var tasks = new List<EntityTask> { task1, task2 };

            var activePeriod = new ActivePeriod(DateOnly.FromDateTime(DateTime.Now));

            var result = new Routine(name, description, tasks, activePeriod);

            Assert.Equal(name, result.Name);
            Assert.Equal(description, result.Description);
            Assert.Equal(tasks, result.Tasks);
            Assert.Contains(activePeriod, result.ActivePeriods);
            Assert.True(result.Active);
        }
    }
}
