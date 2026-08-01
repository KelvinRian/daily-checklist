namespace DailyChecklist.Domain.Entities
{
    public class ActivePeriod : EntityBase
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
