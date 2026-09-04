using DailyChecklist.Application.Routine.Create;
using RoutineEntity = DailyChecklist.Domain.Entities.Routine;
using DailyChecklist.Domain.Interfaces.Repositories;
using NSubstitute;
using ThreadingTask = System.Threading.Tasks.Task;

namespace DailyChecklist.Tests.DailyChecklist.Application.Routine.Create
{
    public class CreateRoutineHandlerTests
    {
        private readonly IRoutineRepository _routineRepository;
        private readonly CreateRoutineHandler _handler;

        public CreateRoutineHandlerTests()
        {
            _routineRepository = Substitute.For<IRoutineRepository>();
            _handler = new CreateRoutineHandler(_routineRepository);
        }

        [Fact]
        public async ThreadingTask Should_Handle_Routine_Creation()
        {
            //Arrange
            var groupItem = new CreateRoutineItemDto
            {
                Type = RoutineItemType.Group,
                Name = "Task Group 1",
                Order = 1,
                Tasks = new List<GroupTaskDto>
                {
                    new GroupTaskDto
                    {
                        Name = "Task in Group 1",
                        Order = 1
                    },
                }
            };

            var taskItem = new CreateRoutineItemDto
            {
                Type = RoutineItemType.Task,
                Name = "Task Without Group",
                Order = 3
            };

            var command = new CreateRoutineCommand()
            {
                Name = "Routine Name",
                Description = "Routine Description",
                StartDate = DateOnly.FromDateTime(DateTime.Now),
                Items = new List<CreateRoutineItemDto>
                {
                    groupItem,
                    taskItem
                }
            };

            //Act
            await _handler.Handle(command);

            //Assert
            await _routineRepository
                .Received(1)
                .AddAsync(Arg.Is<RoutineEntity>(x => x.Name == command.Name
                                                && x.Description == command.Description
                                                && x.Items.Any(y => y.Name == groupItem.Name)
                                                && x.Items.Any(y => y.Name == taskItem.Name)
                                                && x.ActivePeriods.Any(y => y.StartDate == command.StartDate)));
        }
    }
}
