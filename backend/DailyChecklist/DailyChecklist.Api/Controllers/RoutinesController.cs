using DailyChecklist.Application.Routine.Create;
using Microsoft.AspNetCore.Mvc;

namespace DailyChecklist.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoutinesController : ControllerBase
    {
        private readonly CreateRoutineHandler _createRoutineHandler;

        public RoutinesController(CreateRoutineHandler createRoutineHandler)
        {
            _createRoutineHandler = createRoutineHandler;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoutine([FromBody] CreateRoutineCommand command)
        {
            var result = await _createRoutineHandler.Handle(command);
            if (result.IsSuccess)
            {
                return Ok(result.Success);
            }
            else
            {
                return StatusCode(result.Failure!.Code, result.Failure.Message);
            }
        }
    }
}
