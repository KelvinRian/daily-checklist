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
            Validate(command);
            var routine = CreateRoutine(command);
            await _routineRepository.AddAsync(routine);
        }

        private static void Validate(CreateRoutineCommand command)
        {
            var validator = new CreateRoutineCommandValidator();
            var result = validator.Validate(command);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }

        private static RoutineEntity CreateRoutine(CreateRoutineCommand command)
        {
            var routineItems = CreateRoutineItems(command);

            var activePeriod = new ActivePeriod(command.StartDate);

            var routine = new RoutineEntity(command.Name, command.Description, routineItems, activePeriod);

            return routine;
        }

        private static List<RoutineItem> CreateRoutineItems(CreateRoutineCommand command)
        {
            var routineItems = new List<RoutineItem>();

            AddGroupItems(command, routineItems);
            AddTaskItems(command, routineItems);

            return routineItems;
        }

        private static void AddGroupItems(CreateRoutineCommand command, List<RoutineItem> routineItems)
        {
            var groupItemsInCommand = command
                .Items?
                .Where(i => i.Type == RoutineItemType.Group)
                ?? Enumerable.Empty<CreateRoutineItemDto>();

            foreach (var groupItem in groupItemsInCommand)
            {
                var groupTasks = groupItem.Tasks?.Select(t => new GroupTask(t.Name, t.Order)).ToList();
                routineItems.Add(new GroupItem(groupItem.Name, groupItem.Order, groupTasks));
            }
        }

        private static void AddTaskItems(CreateRoutineCommand command, List<RoutineItem> routineItems)
        {
            var taskItems = command
                            .Items?
                            .Where(i => i.Type == RoutineItemType.Task)
                            ?? Enumerable.Empty<CreateRoutineItemDto>();

            foreach (var taskItem in taskItems)
            {
                routineItems.Add(new TaskItem(taskItem.Name, taskItem.Order));
            };
        }
    }
}
