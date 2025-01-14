using DPS.Features.Domain.Models;

namespace DPS.Features.Domain.Tests
{
    public class UserTests
    {
        [Fact(DisplayName = "New Valid User")]
        [Trait("Category", "User Trait Tests")]
        public void User_NewUser_ShouldBeValid()
        {
            // Arrange
            var client = new User(
                Guid.NewGuid(),
                "Foo",
                "Bar",
                DateTime.Now.AddYears(-30),
                "test@test.com",
                true,
                DateTime.Now);

            // Act
            var result = client.IsValid();

            // Assert
            Assert.True(result);
            Assert.Equal(0, client.ValidationResult.Errors.Count);
        }

        [Fact(DisplayName = "New Invalid User")]
        [Trait("Category", "User Trait Tests")]
        public void User_NewUser_ShouldBeInvalid()
        {
            // Arrange
            var client = new User(
                Guid.NewGuid(),
                "",
                "",
                DateTime.Now,
                "test2@test.com",
                true,
                DateTime.Now);

            // Act
            var result = client.IsValid();

            // Assert
            Assert.False(result);
            Assert.NotEqual(0, client.ValidationResult.Errors.Count);
        }
    }
}