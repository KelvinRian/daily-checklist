using EntityTask = DailyChecklist.Domain.Entities.Task;

namespace DailyChecklist.Tests.DailyChecklist.Domain.Entities
{
    public class TaskTests
    {
        [Fact]
        public void Constructor_Should_CreateTask()
        {
            var name = "task";
            var order = 1;

            var task = new EntityTask(name, order);

            Assert.Equal(name, task.Name);
            Assert.Equal(order, task.Order);
        }
    }
}
