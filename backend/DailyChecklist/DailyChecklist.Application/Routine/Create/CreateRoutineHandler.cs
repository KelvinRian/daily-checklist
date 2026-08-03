using DailyChecklist.Domain.Interfaces.Repositories;

namespace DailyChecklist.Application.Routine.Create
{
    public class CreateRoutineHandler
    {
        private readonly IRoutineRepository _routineRepository;
        
        public CreateRoutineHandler(IRoutineRepository routineRepository)
        {
            _routineRepository = routineRepository;   
        }

        public async Task Handle(CreateRoutineCommand command)
        {
            // TODO
            // Validate Command
            // Create Tasks
            // Create TasksGroups
            // Link TaskGroups to Tasks
            // Create a Active Period
            // Create Routine
            // Call Repository to persist data
        }
    }
}
