using DailyChecklist.Domain.Entities;
using DailyChecklist.Infrastructure.Context;
using DailyChecklist.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DailyChecklist.Tests.DailyChecklst.Infrastructure.Repositories
{
    public class RoutineRepositoryTests
    {
        [Fact]
        public async Task Should_AddAsync()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<DailyChecklistContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            await using var context = new DailyChecklistContext(options);

            var repository = new RoutineRepository(context);

            var routine = new Routine(
                name: "Test Routine",
                description: "Test Description",
                items: new List<RoutineItem>(),
                activePeriod: new ActivePeriod(DateOnly.MinValue)
            );

            // Act
            await repository.AddAsync(routine);

            // Assert
            var addedRoutine = await context.Routines.FindAsync(routine.Id);

            Assert.NotNull(addedRoutine);
            Assert.Equal(routine.Name, addedRoutine.Name);
        }
    }
}
