namespace DailyChecklist.Domain.Entities
{
    public class DayTask : EntityBase
    {
        public Day Day { get; set; }
        public Guid DayId { get; set; }
        public Guid TaskId { get; set; }
        public bool Finished { get; set; } = false;
    }
}
