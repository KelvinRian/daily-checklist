using EntityRoutine = DailyChecklist.Domain.Entities.Routine;
namespace DailyChecklist.Application.Routine.GetAll
{
    public class RoutineDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public RoutineDto(EntityRoutine routine)
        {
            Id = routine?.Id ?? Guid.Empty;
            Name = routine?.Name ?? string.Empty;
        }
    }
}