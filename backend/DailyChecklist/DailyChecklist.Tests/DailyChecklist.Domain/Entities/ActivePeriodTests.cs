using DailyChecklist.Domain.Entities;

namespace DailyChecklist.Tests.DailyChecklist.Domain.Entities
{
    public class ActivePeriodTests
    {
        [Fact]
        public void Constructor_Should_CreateActivePeriod()
        {
            var startDate = DateOnly.FromDateTime(DateTime.Now);

            var activePeriod = new ActivePeriod(startDate);

            Assert.Equal(startDate, activePeriod.StartDate);
            Assert.True(activePeriod.Active);
        }
    }
}
