namespace DPS.Features.Domain.Tests
{
    [Collection(nameof(UserCollection))]
    public class InvalidUserTest
    {
        private readonly UserTestsFixture _clientTestsFixture;

        public InvalidUserTest(UserTestsFixture clientTestsFixture)
        {
            _clientTestsFixture = clientTestsFixture;
        }

        [Fact(DisplayName = "New Invalid User")]
        [Trait("Category", "User Fixture Tests")]
        public void User_NewUser_ShouldBeInvalid()
        {
            // Arrange
            var client = _clientTestsFixture.GenerateInvalidUser();

            // Act
            var result = client.IsValid();

            // Assert
            Assert.False(result);
            Assert.NotEqual(0, client.ValidationResult.Errors.Count);
        }
    }
}