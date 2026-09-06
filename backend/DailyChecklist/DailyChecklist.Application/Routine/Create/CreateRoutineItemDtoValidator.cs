using FluentValidation;

namespace DailyChecklist.Application.Routine.Create
{
    public class CreateRoutineItemDtoValidator : AbstractValidator<CreateRoutineItemDto>
    {
        public CreateRoutineItemDtoValidator()
        {
            AddRulesForType();
            AddRulesForName();

            When(x => x.Type == RoutineItemType.Group, () =>
            {
                AddRulesForTasks();
            });
        }
        
        private void AddRulesForType()
        {
            RuleFor(x => x.Type)
                .IsInEnum()
                .WithMessage("'Type' must be a valid enum value.");
        }
        
        private void AddRulesForName()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("'Name' must not be empty.")
                .MaximumLength(200)
                .WithMessage("'Name' must not be greater than 200 characters.");
        }

        private void AddRulesForTasks()
        {
            RuleForEach(x => x.Tasks)
                .SetValidator(new GroupTaskDtoValidator());

            RuleFor(x => x.Tasks)
                .Must(OrderValuesMustBeUnique())
                .WithMessage("'Order' values must be unique.");
        }

        private static Func<ICollection<GroupTaskDto>, bool> OrderValuesMustBeUnique()
        {
            return tasks => tasks is null ||
                tasks.Select(task => task.Order)
                .Distinct()
                .Count() == tasks.Count;
        }
    }
}
