using DailyChecklist.Domain.Interfaces.Repositories;
using ThreadingTask = System.Threading.Tasks.Task;
using RoutineEntity = DailyChecklist.Domain.Entities.Routine;
using DailyChecklist.Domain.Entities;


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
            // FluentValidation
            // DomainNotifications

            var groupItemsInCommand = command
                .Items
                .Where(i => i.Type == RountineItemType.Group);

            var routineItems = new List<RoutineItem>();
            foreach (var groupItem in groupItemsInCommand)
            {
                var groupTasks = groupItem.Tasks.Select(t => new GroupTask(t.Name, t.Order)).ToList();
                routineItems.Add(new GroupItem(groupItem.Name, groupItem.Order, groupTasks));
            }

            var taskItems = command
                .Items
                .Where(i => i.Type == RountineItemType.Task);

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
