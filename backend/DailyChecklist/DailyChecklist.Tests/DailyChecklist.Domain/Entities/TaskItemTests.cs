using DailyChecklist.Domain.Entities;

namespace DailyChecklist.Tests.DailyChecklist.Domain.Entities
{
    public class TaskItemTests
    {
        [Fact]
        public void Constructor_Should_CreateTaskItem()
        {
            var name = "Name";
            var order = 1;

            var result = new TaskItem(name, order);

            Assert.Equal(name, result.Name);
            Assert.Equal(order, result.Order);
        }
    }
}
