using DailyChecklist.Application.Routine.Create;
using DailyChecklist.Application.Routine.GetAll;
using DailyChecklist.Application.Routine.GetById;
using DailyChecklist.Application.Routine.Inactivate;
using DailyChecklist.Domain.Filters;
using Microsoft.AspNetCore.Mvc;

namespace DailyChecklist.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoutinesController : ControllerBase
    {
        private readonly CreateRoutineHandler _createRoutineHandler;
        private readonly GetAllRoutinesHandler _getAllRoutinesHandler;
        private readonly GetRoutineByIdHandler _getRoutineByIdHandler;
        private readonly InactivateRoutineHandler _inactivateRoutineHandler;

        public RoutinesController(CreateRoutineHandler createRoutineHandler, 
            GetAllRoutinesHandler getAllRoutinesHandler,
            GetRoutineByIdHandler getRoutineByIdHandler,
            InactivateRoutineHandler inactivateRoutineHandler)
        {
            _createRoutineHandler = createRoutineHandler;
            _getAllRoutinesHandler = getAllRoutinesHandler;
            _getRoutineByIdHandler = getRoutineByIdHandler;
            _inactivateRoutineHandler = inactivateRoutineHandler;
        }

        //TODO
        //Verificar se existe uma rotina ativa nesse perído e a finalizar, caso exista
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

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] RoutineFilters routineFilters)
        {
            var result = await _getAllRoutinesHandler.Handle(routineFilters);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var result = await _getRoutineByIdHandler.Handle(id);

            if (result.IsSuccess)
            {
                return Ok(result.Success);
            }
            else
            {
                return StatusCode(result.Failure!.Code, result.Failure.Message);
            }
        }

        //TODO
        // UPDATE
        // Atualiza Name, Description, Items/Grupos e tasks, Data de Início
        //  * Se a data de início for para o futuro e houver um perído ativo, finaliza o período ativo e cria um novo.
        //  * Não permite atualizar a data de início para uma data abaixo do dia atual
        //  * Se a data de início for para o passado, mas ainda for igual ou maior que a data do dia atual, atualia o Active Period existente

        //TODO
        // ENCERRAR
        // Encerra uma rotina pelo ID, setando a data de término no Active Period da rotina em questão

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _inactivateRoutineHandler.Handle(id);
            return Ok();
        }
    }
}
