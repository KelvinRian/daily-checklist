namespace DailyChecklist.Domain.Entities
{
    public class Task : EntityBase
    {
        public string Name { get; set; }
        public int Order { get; set; }
        public Routine Routine { get; set; }
        public Guid RoutineId { get; set; }
        public TaskGroup? TaskGroup { get; set; }
        public Guid? TaskGroupId { get; set; }
        public ICollection<DayTask> DayTasks { get; set; }

        public Task(string name, int order)
        {
            Name = name;
            Order = order;
        }
    }
}
