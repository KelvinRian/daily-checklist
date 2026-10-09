using DailyChecklist.Application.Utils.Result;
using DailyChecklist.Domain.Interfaces.Repositories;

namespace DailyChecklist.Application.Routine.GetById
{
    public class GetRoutineByIdHandler
    {
        private readonly IRoutineRepository _routineRepository;

        public GetRoutineByIdHandler(IRoutineRepository routineRepository)
        {
            _routineRepository = routineRepository;
        }

        public async Task<Result<RoutineDetailsDto>> Handle(Guid id)
        {
            var routine = await _routineRepository.GetById(id);

            if (routine == null)
                return Result<RoutineDetailsDto>.AsFailure(new Failure(404, "Routine not found"));
            else
            {
                var routineDetailsDto = new RoutineDetailsDto(routine);
                return Result<RoutineDetailsDto>.AsSuccess(routineDetailsDto);
            }
        }
    }
}
