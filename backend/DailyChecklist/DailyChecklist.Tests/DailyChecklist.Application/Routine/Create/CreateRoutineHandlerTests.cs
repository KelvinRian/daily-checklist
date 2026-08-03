using DailyChecklist.Application.Routine.Create;
using EntityRoutine = DailyChecklist.Domain.Entities.Routine;
using DailyChecklist.Domain.Interfaces.Repositories;
using ThreadingTask = System.Threading.Tasks.Task;
using NSubstitute;
using Microsoft.IdentityModel.Tokens;

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
            // Arrange
            var taskGroupDto = new CreateRoutineTaskGroupDto
            {
                Name = "Task Group",
                Order = 1
            };

            var taskInGroupDto = new CreateRoutineTaskDto
            {
                Name = "Task in Group",
                Order = 1,
                TaskGroup = taskGroupDto
            };

            var taskWithoutGroupDto = new CreateRoutineTaskDto
            {
                Name = "Task Without Group",
                Order = 2,
            };

            var name = "Routine Name";
            var description = "Routine Description";
            var startDate = DateOnly.FromDateTime(DateTime.Now);

            var command = new CreateRoutineCommand
            {
                Name = name,
                Description = description,
                StartDate = startDate,
                Tasks = new List<CreateRoutineTaskDto>
                {
                    taskInGroupDto,
                    taskWithoutGroupDto
                }
            };

            // Act
            await _handler.Handle(command);

            // Assert
            await _routineRepository
                .Received(1)
                .AddAsync(Arg.Is<EntityRoutine>(x => x.Name == name
                                                    && x.Description == description
                                                    && x.Tasks.Count == 2
                                                    && x.Tasks.Any(y => y.Name == taskInGroupDto.Name 
                                                        && y.Order == taskInGroupDto.Order 
                                                        && y.TaskGroup.Name == taskGroupDto.Name 
                                                        && y.TaskGroup.Order == taskGroupDto.Order)
                                                    && x.Tasks.Any(y => y.Name == taskWithoutGroupDto.Name
                                                        && y.Order == taskWithoutGroupDto.Order
                                                        && y.TaskGroup == null)
                                                    && x.ActivePeriods.Count == 1
                                                    && x.ActivePeriods.Any(y => y.StartDate == startDate
                                                        && !y.EndDate.HasValue)
                                                    && x.Days.IsNullOrEmpty()
                                                    && x.Active
                                                    ));
        }
    }
}
