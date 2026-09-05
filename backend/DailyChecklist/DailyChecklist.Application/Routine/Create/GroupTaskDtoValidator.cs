using FluentValidation;

namespace DailyChecklist.Application.Routine.Create
{
    public class GroupTaskDtoValidator : AbstractValidator<GroupTaskDto>
    {
        public GroupTaskDtoValidator()
        {
            AddRulesForName();
        }

        private void AddRulesForName()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("'Name' must not be empty.")
                .MaximumLength(200)
                .WithMessage("'Name' must not be greater than 200 characters.");
        }
    }
}
