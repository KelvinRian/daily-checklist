namespace DailyChecklist.Domain.Entities
{
    public class Day : EntityBase
    {
        public DateOnly Date { get; set; }
        public Routine Routine { get; set; }
        public Guid RoutineId { get; set; }
        public ICollection<DayTask> DayTasks { get; set; }
    }
}
