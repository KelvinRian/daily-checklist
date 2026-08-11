namespace DailyChecklist.Domain.Entities
{
    public sealed class GroupItem : RoutineItem
    {
        public ICollection<GroupTask> GroupTasks { get; set; }

        private GroupItem() { }

        public GroupItem(string name, int order, ICollection<GroupTask> tasks)
        {
            Name = name;
            Order = order;
            GroupTasks = tasks;
        }
    }
}
