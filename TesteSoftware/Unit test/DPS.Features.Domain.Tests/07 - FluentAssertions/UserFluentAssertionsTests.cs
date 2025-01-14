using FluentAssertions;
using Xunit.Abstractions;

namespace DPS.Features.Domain.Tests
{
    [Collection(nameof(UserAutoMockerCollection))]
    public class UserFluentAssertionsTests
    {
        private readonly UserTestsAutoMockerFixture _userTestsFixture;
        private readonly ITestOutputHelper _outputHelper;

        public UserFluentAssertionsTests(UserTestsAutoMockerFixture userTestsFixture,
                                            ITestOutputHelper outputHelper)
        {
            _userTestsFixture = userTestsFixture;
            _outputHelper = outputHelper;
        }

        [Fact(DisplayName = "New Valid User")]
        [Trait("Category", "User Fluent Assertion Tests")]
        public void User_NewUser_ShouldBeValid()
        {
            // Arrange
            var user = _userTestsFixture.GenerateValidUser();

            // Act
            var result = user.IsValid();

            // Assert
            //Assert.True(result);
            //Assert.Equal(0, user.ValidationResult.Errors.Count);

            // Assert
            result.Should().BeTrue();
            user.ValidationResult.Errors.Should().HaveCount(0);
        }

        [Fact(DisplayName = "New Invalid User")]
        [Trait("Category", "User Fluent Assertion Tests")]
        public void User_NewUser_ShouldBeInvalid()
        {
            // Arrange
            var user = _userTestsFixture.GenerateInvalidUser();

            // Act
            var result = user.IsValid();

            // Assert
            //Assert.False(result);
            //Assert.NotEqual(0, user.ValidationResult.Errors.Count);

            // Assert
            result.Should().BeFalse();
            user.ValidationResult.Errors.Should().HaveCountGreaterThanOrEqualTo(1, "should have validation errors");

            _outputHelper.WriteLine($"Found {user.ValidationResult.Errors.Count} errors in this validation");
        }
    }
}