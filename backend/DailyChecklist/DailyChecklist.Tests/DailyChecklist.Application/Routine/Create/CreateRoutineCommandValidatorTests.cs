using DailyChecklist.Application.Routine.Create;

namespace DailyChecklist.Tests.DailyChecklist.Application.Routine.Create
{
    public class CreateRoutineCommandValidatorTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Should_Not_Validate_NullOrEmpty_Name(string name)
        {
            // Arrange
            var command = new CreateRoutineCommand
            {
                Name = name,
                Description = "description",
            };
            var validator = new CreateRoutineCommandValidator();

            // Act
            var result = validator.Validate(command);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e =>
                e.PropertyName == "Name" &&
                e.ErrorMessage == "'Name' must not be empty.");
        }

        [Fact]
        public void Should_Not_Validate_Name_GreaterThan200Characters()
        {
            // Arrange
            var command = new CreateRoutineCommand
            {
                Name = new string('a', 201),
                Description = "description",
            };
            var validator = new CreateRoutineCommandValidator();

            // Act
            var result = validator.Validate(command);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e =>
                e.PropertyName == "Name" &&
                e.ErrorMessage == "'Name' must not be greater than 200 characters.");
        }

        [Fact]
        public void Should_Validate_200Characters_Name()
        {
            // Arrange
            var command = new CreateRoutineCommand
            {
                Name = new string('a', 200),
                Description = "description",
            };
            var validator = new CreateRoutineCommandValidator();

            // Act
            var result = validator.Validate(command);

            // Assert
            Assert.True(result.IsValid);
        }

        [Fact]
        public void Should_Not_Valdiate_Description_GreaterThan500Characters()
        {
            // Arrange
            var command = new CreateRoutineCommand
            {
                Name = "Valid Name",
                Description = new string('a', 501),
            };
            var validator = new CreateRoutineCommandValidator();

            // Act
            var result = validator.Validate(command);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e =>
                e.PropertyName == "Description" &&
                e.ErrorMessage == "'Description' must not be greater than 500 characters.");
        }

        [Fact]
        public void Should_Valdiate_500Characters_Description()
        {
            // Arrange
            var command = new CreateRoutineCommand
            {
                Name = "Valid Name",
                Description = new string('a', 500),
            };
            var validator = new CreateRoutineCommandValidator();

            // Act
            var result = validator.Validate(command);

            // Assert
            Assert.True(result.IsValid);
        }

        [Fact]
        public void should_Validate_Unique_Order_Values_For_Items()
        {
            // Arrange
            var command = new CreateRoutineCommand
            {
                Name = "Valid Name",
                Description = "Valid Description",
                Items = new List<CreateRoutineItemDto>
                {
                    new CreateRoutineItemDto { Order = 1, Type = RoutineItemType.Task, Name = "Task 1" },
                    new CreateRoutineItemDto { Order = 2, Type = RoutineItemType.Task, Name = "Task 2" },
                    new CreateRoutineItemDto { Order = 2, Type = RoutineItemType.Task, Name = "Task 3" }
                }
            };
            var validator = new CreateRoutineCommandValidator();

            // Act
            var result = validator.Validate(command);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e =>
                e.PropertyName == "Items" &&
                e.ErrorMessage == "'Order' values must be unique.");
        }

        [Fact]
        public void Should_Validate_Valid_Command()
        {
            // Arrange
            var command = new CreateRoutineCommand
            {
                Name = "Valid Name",
                Description = "Valid Description",
                Items = new List<CreateRoutineItemDto>
                {
                    new CreateRoutineItemDto { Order = 1, Type = RoutineItemType.Task, Name = "Task 1" },
                    new CreateRoutineItemDto { Order = 2, Type = RoutineItemType.Task, Name = "Task 2" }
                }
            };

            var validator = new CreateRoutineCommandValidator();

            // Act
            var result = validator.Validate(command);

            // Assert
            Assert.True(result.IsValid);
        }
    }
}
