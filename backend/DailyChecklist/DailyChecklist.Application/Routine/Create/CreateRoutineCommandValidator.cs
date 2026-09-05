using FluentValidation;

namespace DailyChecklist.Application.Routine.Create
{
    public class CreateRoutineCommandValidator : AbstractValidator<CreateRoutineCommand>
    {
        public CreateRoutineCommandValidator()
        {
            AddRulesForName();
            AddRulesForDescription();
            AddRulesForItems();
        }

        private void AddRulesForName()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("'Name' must not be empty.");
            
            RuleFor(x => x.Name)
                .MaximumLength(200)
                .WithMessage("'Name' must not be greater than 200 characters.");
        }

        private void AddRulesForDescription()
        {
            RuleFor(x => x.Description)
                .MaximumLength(500)
                .WithMessage("'Description' must not be greater than 500 characters.");
        }

        private void AddRulesForItems()
        {
            RuleForEach(x => x.Items)
                .SetValidator(new CreateRoutineItemDtoValidator());

            RuleFor(x => x.Items)
                .Must(OrderValuesMustBeUnique())
                .WithMessage("'Order' values must be unique.");
        }

        private static Func<ICollection<CreateRoutineItemDto>, bool> OrderValuesMustBeUnique()
        {
            return items => items
                .Select(item => item.Order)
                .Distinct()
                .Count() == items.Count;
        }
    }
}
