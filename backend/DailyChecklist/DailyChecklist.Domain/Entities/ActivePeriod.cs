namespace DailyChecklist.Domain.Entities
{
    public class ActivePeriod : EntityBase
    {
        public DateOnly StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Routine Routine { get; set; }
        public Guid RoutineId { get; set; }
        public bool Active { get; set; } = true;

        public ActivePeriod(DateOnly startDate) 
        {
            StartDate = startDate;
        }
    }
}
