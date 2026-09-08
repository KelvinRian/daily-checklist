namespace DailyChecklist.Application.Routine.Create
{
    public class CreateRoutineCommand
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateOnly StartDate { get; set; }
        public ICollection<CreateRoutineItemDto>? Items { get; set; }
    }

    public class CreateRoutineItemDto 
    {
        public RoutineItemType Type { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public ICollection<GroupTaskDto>? Tasks { get; set; }
    }

    public class GroupTaskDto
    {
        public string Name { get; set; }
        public int Order { get; set; }
    }

    public enum RoutineItemType
    {
        Task = 1,
        Group = 2
    }
}
