namespace DailyChecklist.Domain.Entities
{
    public class Task : EntityBase
    {
        public string Name { get; set; }
        public int Order { get; set; }
    }
}
