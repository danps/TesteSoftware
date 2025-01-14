namespace DPS.Features.Domain.Tests
{
    [Collection(nameof(UserCollection))]
    public class ValidUserTest
    {
        private readonly UserTestsFixture _clientTestsFixture;

        public ValidUserTest(UserTestsFixture clientTestsFixture)
        {
            _clientTestsFixture = clientTestsFixture;
        }

        [Fact(DisplayName = "New Valid User")]
        [Trait("Category", "User Fixture Tests")]
        public void User_NewUser_ShouldBeValid()
        {
            // Arrange
            var client = _clientTestsFixture.GenerateValidUser();

            // Act
            var result = client.IsValid();

            // Assert
            Assert.True(result);
            Assert.Equal(0, client.ValidationResult.Errors.Count);
        }
    }
}