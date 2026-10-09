using DailyChecklist.Domain.Filters;
using DailyChecklist.Domain.Interfaces.Repositories;

namespace DailyChecklist.Application.Routine.GetAll
{
    public class GetAllRoutinesHandler
    {
        private readonly IRoutineRepository _routineRepository;

        public GetAllRoutinesHandler(IRoutineRepository routineRepository)
        {
            _routineRepository = routineRepository;
        }

        public async Task<IEnumerable<RoutineDto>> Handle(RoutineFilters filters)
        {
            var routines = await _routineRepository.GetAllAsync(filters);
            return routines.Select(r => new RoutineDto(r));
        }
    }
}
