using DailyChecklist.Domain.Entities;
using DailyChecklist.Domain.Enums;
using EntityRoutine = DailyChecklist.Domain.Entities.Routine;

namespace DailyChecklist.Application.Routine.GetById
{
    public class RoutineDetailsDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<RoutineItemDto> Items { get; set; }
        public DateOnly? StartDate { get; set; }

        public RoutineDetailsDto(EntityRoutine routine)
        {
            Id = routine?.Id ?? Guid.Empty;
            Name = routine?.Name ?? string.Empty;
            StartDate = GetStartDate(routine);
            Items = GetRoutineItems(routine);
        }

        private DateOnly? GetStartDate(EntityRoutine routine)
        {
            if (routine == null)
            {
                return null;
            }
            else if (routine.ActivePeriods == null || !routine.ActivePeriods.Any())
            {
                return null;
            }
            else if (routine.ActivePeriods.Any(x => x.Active))
            {
                var currentActivePeriod = routine.ActivePeriods.First(x => x.Active);
                return currentActivePeriod.StartDate;
            }
            else if (routine.ActivePeriods.Any(x => x.EndDate == null))
            {
                var nextActivePeriods = routine.ActivePeriods.Where(x => x.EndDate == null);
                return nextActivePeriods.Min(x => x.StartDate);
            }
            else
            {
                var lastActiveperiods = routine.ActivePeriods.Where(x => x.EndDate != null);
                return lastActiveperiods.Max(x => x.StartDate);
            }
        }

        private IEnumerable<RoutineItemDto> GetRoutineItems(EntityRoutine routine)
        {
            var routineItems = new List<RoutineItemDto>();

            if (routine == null)
                return routineItems;

            if (routine.Items == null || !routine.Items.Any())
                return routineItems;

            foreach (var item in routine.Items)
            {
                var itemDto = new RoutineItemDto()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Order = item.Order,
                    Type = item.GetTypeEnum()
                };

                if (item is GroupItem groupItem)
                {
                    itemDto.GroupTasks = groupItem
                        .GroupTasks
                        .OrderBy(x => x.Order)
                        .Select(x => new GroupTaskDto()
                        {
                            Id = x.Id,
                            Name = x.Name,
                            Order = x.Order,
                        });
                }

                routineItems.Add(itemDto);
            }

            return routineItems.OrderBy(x => x.Order);
        }
    }

    public class RoutineItemDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public RoutineItemType Type { get; set; }
        public IEnumerable<GroupTaskDto> GroupTasks { get; set; } = new List<GroupTaskDto>();
    }

    public class GroupTaskDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
    }
}
