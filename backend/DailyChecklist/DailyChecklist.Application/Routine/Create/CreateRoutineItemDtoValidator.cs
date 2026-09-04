using FluentValidation;

namespace DailyChecklist.Application.Routine.Create
{
    public class CreateRoutineItemDtoValidator : AbstractValidator<CreateRoutineItemDto>
    {
        public CreateRoutineItemDtoValidator()
        {
            //type
            //name Required 200 caracteres
            //Order Required
            //Tasks
            //Name Required 200 caracteres
            //Order Required

            //Utilizar when por type, exemplo:
            // When(x => x.Type == RoutineItemType.Task, () =>
            // {
            //     RuleFor(x => x.Tasks)
            //         .Empty();
            // });
        }
    }
}
