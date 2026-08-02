namespace DailyChecklist.Application.Routine.Create
{
    public class CreateRoutineCommand
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateOnly StartDate { get; set; }
        public ICollection<CreateRoutineTaskDto> Tasks { get; set; }
    }

    public class CreateRoutineTaskDto 
    {
        public string Name { get; set; }
        public int Order { get; set; }
        public CreateRoutineTaskGroupDto TaskGroup { get; set; }
    }

    public class CreateRoutineTaskGroupDto
    {
        public string Name { get; set; }
        public int Order { get; set; }
    }
}
