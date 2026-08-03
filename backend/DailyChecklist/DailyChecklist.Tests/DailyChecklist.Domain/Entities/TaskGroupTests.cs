using DailyChecklist.Domain.Entities;
using EntityTask = DailyChecklist.Domain.Entities.Task;

namespace DailyChecklist.Tests.DailyChecklist.Domain.Entities
{
    public class TaskGroupTests
    {
        [Fact]
        public void Constructor_Should_CreateTaskGroup()
        {
            var name = "task group";
            var order = 1;

            var task1 = new EntityTask("task name", 1);
            var task2 = new EntityTask("task name 2", 2);
            var tasks = new List<EntityTask> { task1, task2 };

            var result = new TaskGroup(name, order, tasks);

            Assert.Equal(name, result.Name);
            Assert.Equal(order, result.Order);
            Assert.Equal(tasks, result.Tasks);
        }
    }
}
