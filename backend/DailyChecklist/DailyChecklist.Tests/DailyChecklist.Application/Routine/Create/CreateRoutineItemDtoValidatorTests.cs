using DailyChecklist.Application.Routine.Create;

namespace DailyChecklist.Tests.DailyChecklist.Application.Routine.Create
{
    public class CreateRoutineItemDtoValidatorTests
    {
        [Fact]
        public void Should_Not_Validate_Invalid_Type()
        {
            // Arrange
            var dto = new CreateRoutineItemDto
            {
                Type = (RoutineItemType)999,
                Name = "Valid Name",
                Tasks = new List<GroupTaskDto>()
            };
            var validator = new CreateRoutineItemDtoValidator();

            // Act
            var result = validator.Validate(dto);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e =>
                e.PropertyName == "Type" &&
                e.ErrorMessage == "'Type' must be a valid enum value.");

        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Should_Not_Validate_NullOrEmpty_Name(string name)
        {
            // Arrange
            var dto = new CreateRoutineItemDto
            {
                Type = RoutineItemType.Task,
                Name = name,
                Tasks = new List<GroupTaskDto>()
            };
            var validator = new CreateRoutineItemDtoValidator();

            // Act
            var result = validator.Validate(dto);

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
            var dto = new CreateRoutineItemDto
            {
                Type = RoutineItemType.Task,
                Name = new string('a', 201),
                Tasks = new List<GroupTaskDto>()
            };
            var validator = new CreateRoutineItemDtoValidator();

            // Act
            var result = validator.Validate(dto);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e =>
                e.PropertyName == "Name" &&
                e.ErrorMessage == "'Name' must not be greater than 200 characters.");
        }

        [Fact]
        public void Should_Not_Validate_Tasks_With_Duplicated_Order_Values()
        {
            // Arrange
            var dto = new CreateRoutineItemDto
            {
                Type = RoutineItemType.Group,
                Name = "Valid Name",
                Tasks = new List<GroupTaskDto>
                {
                    new GroupTaskDto { Order = 1, Name = "Task 1" },
                    new GroupTaskDto { Order = 1, Name = "Task 2" }
                }
            };
            var validator = new CreateRoutineItemDtoValidator();

            // Act
            var result = validator.Validate(dto);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e =>
                e.PropertyName == "Tasks" &&
                e.ErrorMessage == "'Order' values must be unique.");
        }

        [Fact]
        public void Should_Validate_Valid_Dto()
        {
            // Arrange
            var dto = new CreateRoutineItemDto
            {
                Type = RoutineItemType.Task,
                Name = "Valid Name",
                Tasks = new List<GroupTaskDto>()
            };
            var validator = new CreateRoutineItemDtoValidator();

            // Act

            var result = validator.Validate(dto);
            // Assert
            Assert.True(result.IsValid);
        }
    }
}
