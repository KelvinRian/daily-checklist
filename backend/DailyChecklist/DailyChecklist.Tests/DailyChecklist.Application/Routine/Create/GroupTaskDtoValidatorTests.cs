using DailyChecklist.Application.Routine.Create;

namespace DailyChecklist.Tests.DailyChecklist.Application.Routine.Create
{
    public class GroupTaskDtoValidatorTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Should_Not_Validate_NullOrEmpty_Name(string name)
        {
            // Arrange
            var dto = new GroupTaskDto
            {
                Name = name,
                Order = 1
            };
            var validator = new GroupTaskDtoValidator();

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
            var dto = new GroupTaskDto
            {
                Name = new string('a', 201),
                Order = 1
            };
            var validator = new GroupTaskDtoValidator();

            // Act
            var result = validator.Validate(dto);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e =>
                e.PropertyName == "Name" &&
                e.ErrorMessage == "'Name' must not be greater than 200 characters.");
        }

        [Fact]
        public void Should_Validate_Valid_Dto()
        {
            // Arrange
            var dto = new GroupTaskDto
            {
                Name = "Valid Name",
                Order = 1
            };
            var validator = new GroupTaskDtoValidator();

            // Act

            var result = validator.Validate(dto);
            // Assert
            Assert.True(result.IsValid);
        }
    }
}
