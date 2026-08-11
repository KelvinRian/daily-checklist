namespace DailyChecklist.Domain.Entities
{
    public sealed class TaskItem : RoutineItem
    {
        public TaskItem(string name, int order)
        {
            Name = name;
            Order = order;
        }
    }
}
