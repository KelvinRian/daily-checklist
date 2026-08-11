namespace DailyChecklist.Domain.Entities
{
    public abstract class RoutineItem : EntityBase
    {
        public string Name { get; protected set; }
        public int Order { get; protected set; }
        public Routine Routine { get; protected set; }
        public Guid RoutineId { get; protected set; }
    }
}
