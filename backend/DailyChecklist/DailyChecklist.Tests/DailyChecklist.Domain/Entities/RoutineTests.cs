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

            var activePeriod = new ActivePeriod(DateOnly.FromDateTime(DateTime.Now));

            var items = new List<RoutineItem>
            {
                new TaskItem("Task 1", 1),
                new GroupItem("Task 2", 2, new List<GroupTask>())
            };

            var result = new Routine(name, description, items, activePeriod);

            Assert.Equal(name, result.Name);
            Assert.Equal(description, result.Description);
            Assert.Equal(items, result.Items);
            Assert.Contains(activePeriod, result.ActivePeriods);
            Assert.True(result.Active);
        }
    }
}
