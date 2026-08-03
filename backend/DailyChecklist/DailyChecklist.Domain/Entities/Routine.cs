namespace DailyChecklist.Domain.Entities
{
    public class Routine : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Task> Tasks { get; set; }
        public ICollection<ActivePeriod> ActivePeriods { get; set; }
        public ICollection<Day> Days { get; set; }
        public bool Active { get; set; } = true;

        public Routine(string name, string description, ICollection<Task> tasks, ActivePeriod activePeriod) 
        {
            Name = name;
            Description = description;
            Tasks = tasks;
            ActivePeriods = new List<ActivePeriod> { activePeriod };
        }
    }
}
