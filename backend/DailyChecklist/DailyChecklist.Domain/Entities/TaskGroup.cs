namespace DailyChecklist.Domain.Entities
{
    public class TaskGroup : EntityBase
    {
        public string Name { get; set; }
        public int Order { get; set; }
        public ICollection<Task> Tasks { get; set; }

        private TaskGroup() { }

        public TaskGroup(string name, int order, ICollection<Task> tasks)
        {
            Name = name;
            Order = order;
            Tasks = tasks;
        }
    }
}
