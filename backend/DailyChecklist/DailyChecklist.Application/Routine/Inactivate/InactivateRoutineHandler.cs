using DailyChecklist.Domain.Interfaces.Repositories;

namespace DailyChecklist.Application.Routine.Inactivate
{
    public class InactivateRoutineHandler
    {
        private readonly IRoutineRepository _routineRepository;

        public InactivateRoutineHandler(IRoutineRepository routineRepository)
        {
            _routineRepository = routineRepository;
        }

        public async Task Handle(Guid id)
        {
            var routine = await _routineRepository.GetById(id);

            if (routine != null)
            {
                routine.Inactivate();
                await _routineRepository.UpdateAsync(routine);
            }
        }
    }
}
