namespace DailyChecklist.Domain.Entities
{
    public class Routine : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<RoutineItem> Items { get; set; }
        public ICollection<ActivePeriod> ActivePeriods { get; set; }
        public bool Active { get; set; } = true;

        private Routine() { }

        public Routine(string name, string description, ICollection<RoutineItem> items, ActivePeriod activePeriod) 
        {
            Name = name;
            Description = description;
            Items = items;
            ActivePeriods = new List<ActivePeriod> { activePeriod };
        }
    }
}
