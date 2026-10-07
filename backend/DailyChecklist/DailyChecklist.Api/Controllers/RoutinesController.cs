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

        //TODO
        //Verifica se existe uma rotina ativa nesse perído e a finaliza, caso exista
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

        //TODO
        // GET ALL
        // Retorno: List de Rotina com Id e Name
        // Ordenação: Data de criação. Do mais recente para o mais antigo
        // Filtros customizáveis: Name, Paginação
        // Filtros fixos: Apenas registros não excluídos

        //TODO
        // GET BY ID
        // Retorno:
        // { Id, Name, Description, GroutItems (+ GroupTasks), TaskItems, StartDate }
        // Filtro: Id e apenas registros não excluídos

        //TODO
        // UPDATE
        // Atualiza Name, Description, Items/Grupos e tasks, Data de Início
        //  * Se a data de início for para o futuro e houver um perído ativo, finaliza o período ativo e cria um novo.
        //  * Não permite atualizar a data de início para uma data abaixo do dia atual
        //  * Se a data de início for para o passado, mas ainda for igual ou maior que a data do dia atual, atualia o Active Period existente

        //TODO
        // ENCERRAR
        // Encerra uma rotina pelo ID, setando a data de término no Active Period da rotina em questão

        //TODO
        // DELETE
        // Exlui uma rotina pelo ID
        // Não permite excluir uma rotinha que tem ou já teve um período tivo

    }
}
