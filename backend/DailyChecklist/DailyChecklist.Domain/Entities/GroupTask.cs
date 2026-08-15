namespace DailyChecklist.Domain.Entities
{
    public class GroupTask : EntityBase
    {
        public string Name { get; private set; }
        public int Order { get; private set; }
        public GroupItem GroupItem { get; private set; }
        public Guid GroupItemId { get; private set; }

        public GroupTask(string name, int order)
        {
            Name = name;
            Order = order;
        }
    }
}
