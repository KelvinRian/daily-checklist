using DailyChecklist.Domain.Entities;
using DailyChecklist.Domain.Interfaces.Repositories;
using FluentValidation;
using RoutineEntity = DailyChecklist.Domain.Entities.Routine;
using ThreadingTask = System.Threading.Tasks.Task;


namespace DailyChecklist.Application.Routine.Create
{
    public class CreateRoutineHandler
    {
        private readonly IRoutineRepository _routineRepository;

        public CreateRoutineHandler(IRoutineRepository routineRepository)
        {
            _routineRepository = routineRepository;
        }

        public async ThreadingTask Handle(CreateRoutineCommand command)
        {
            // TODO
            // DomainNotifications

            var validator = new CreateRoutineCommandValidator();
            var result = validator.Validate(command);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

            var groupItemsInCommand = command
                .Items
                .Where(i => i.Type == RoutineItemType.Group);

            var routineItems = new List<RoutineItem>();
            foreach (var groupItem in groupItemsInCommand)
            {
                var groupTasks = groupItem.Tasks.Select(t => new GroupTask(t.Name, t.Order)).ToList();
                routineItems.Add(new GroupItem(groupItem.Name, groupItem.Order, groupTasks));
            }

            var taskItems = command
                .Items
                .Where(i => i.Type == RoutineItemType.Task);

            foreach(var taskItem in taskItems)
            {
                routineItems.Add(new TaskItem(taskItem.Name, taskItem.Order));
            };

            var activePeriod = new ActivePeriod(command.StartDate);

            var routine = new RoutineEntity(command.Name, command.Description, routineItems, activePeriod);

            await _routineRepository.AddAsync(routine);
        }
    }
}
