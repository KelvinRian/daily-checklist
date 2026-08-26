using FluentValidation;

namespace DailyChecklist.Application.Routine.Create
{
    public class CreateRoutineCommandValidator : AbstractValidator<CreateRoutineCommand>
    {
        public CreateRoutineCommandValidator()
        {
            AddRulesForName();
            AddRulesForDescription();
            //TODO
            //Rules for Items
        }

        private void AddRulesForName()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("'Name' must not be empty.");
            RuleFor(x => x.Name).MaximumLength(200).WithMessage("'Name' must not be greater than 200 characters.");
        }

        private void AddRulesForDescription()
        {
            RuleFor(x => x.Description).MaximumLength(500).WithMessage("'Description' must not be greater than 500 characters.");
        }
    }
}
