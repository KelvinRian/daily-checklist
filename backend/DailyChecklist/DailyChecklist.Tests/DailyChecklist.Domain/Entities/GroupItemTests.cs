using DailyChecklist.Domain.Entities;

namespace DailyChecklist.Tests.DailyChecklist.Domain.Entities
{
    public class GroupItemTests
    {
        [Fact]
        public void Constructor_Should_CreateGroupItem()
        {
            var name = "Name";
            var order = 1;
            var groupTasks = new List<GroupTask>() { new GroupTask("groupTaskName", 1) };

            var result = new GroupItem(name, order, groupTasks);
            
            Assert.Equal(name, result.Name);
            Assert.Equal(order, result.Order);
            Assert.Equal(groupTasks, result.GroupTasks);
        }
    }
}
