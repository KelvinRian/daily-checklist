namespace DailyChecklist.Domain.Entities
{
    public class TaskGroup : EntityBase
    {
        public string Name { get; set; }
        public ICollection<Task> Tasks { get; set; }
        public int Order { get; set; }
    }
}
