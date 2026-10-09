using DailyChecklist.Domain.Enums;

namespace DailyChecklist.Domain.Entities
{
    public sealed class TaskItem : RoutineItem
    {
        public TaskItem(string name, int order)
        {
            Name = name;
            Order = order;
        }

        public override RoutineItemType GetTypeEnum()
            => RoutineItemType.Task;
    }
}
