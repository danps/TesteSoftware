namespace DPS.Features.Domain.Tests
{
    [Collection(nameof(UserBogusCollection))]
    public class UserBogusTests
    {
        private readonly UserTestsBogusFixture _userTestsFixture;

        public UserBogusTests(UserTestsBogusFixture userTestsFixture)
        {
            _userTestsFixture = userTestsFixture;
        }

        [Fact(DisplayName = "New Valid User")]
        [Trait("Category", "User Bogus Tests")]
        public void User_NewUser_ShouldBeValid()
        {
            // Arrange
            var user = _userTestsFixture.GenerateValidUser();

            // Act
            var result = user.IsValid();

            // Assert 
            Assert.True(result);
            Assert.Equal(0, user.ValidationResult.Errors.Count);
        }

        [Fact(DisplayName = "New Invalid User")]
        [Trait("Category", "User Bogus Tests")]
        public void User_NewUser_ShouldBeInvalid()
        {
            // Arrange
            var user = _userTestsFixture.GenerateInvalidUser();

            // Act
            var result = user.IsValid();

            // Assert 
            Assert.False(result);
            Assert.NotEqual(0, user.ValidationResult.Errors.Count);
        }
    }
}