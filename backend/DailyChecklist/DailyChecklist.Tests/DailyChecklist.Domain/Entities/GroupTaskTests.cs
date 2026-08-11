using DailyChecklist.Domain.Entities;

namespace DailyChecklist.Tests.DailyChecklist.Domain.Entities
{
    public class GroupTaskTests
    {
        [Fact]
        public void Constructor_Should_CreateGroupTask()
        {
            var name = "Name";
            var order = 1;

            var result = new GroupTask(name, order);

            Assert.Equal(name, result.Name);
            Assert.Equal(order, result.Order);
        }
    }
}
