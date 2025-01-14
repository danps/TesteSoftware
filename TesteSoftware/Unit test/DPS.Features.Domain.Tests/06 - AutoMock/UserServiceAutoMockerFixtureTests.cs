using DPS.Features.Domain.Models;
using MediatR;
using Moq;

namespace DPS.Features.Domain.Tests
{
    [Collection(nameof(UserAutoMockerCollection))]
    public class UserServiceAutoMockerFixtureTests
    {
        readonly UserTestsAutoMockerFixture _userTestsAutoMockerFixture;

        private readonly UserService _userService;

        public UserServiceAutoMockerFixtureTests(UserTestsAutoMockerFixture userTestsFixture)
        {
            _userTestsAutoMockerFixture = userTestsFixture;
            _userService = _userTestsAutoMockerFixture.GetUserService();
        }

        [Fact(DisplayName = "Add User Successfully")]
        [Trait("Category", "User Service AutoMockFixture Tests")]
        public void UserService_Add_ShouldExecuteSuccessfully()
        {
            // Arrange
            var user = _userTestsAutoMockerFixture.GenerateValidUser();

            // Act
            _userService.Add(user);

            // Assert
            Assert.True(user.IsValid());
            _userTestsAutoMockerFixture.Mocker.GetMock<IUserRepository>().Verify(r => r.Add(user), Times.Once);
            _userTestsAutoMockerFixture.Mocker.GetMock<IMediator>().Verify(m => m.Publish(It.IsAny<INotification>(), CancellationToken.None), Times.Once);
        }

        [Fact(DisplayName = "Add User Failure")]
        [Trait("Category", "User Service AutoMockFixture Tests")]
        public void UserService_Add_ShouldFailDueToInvalidUser()
        {
            // Arrange
            var user = _userTestsAutoMockerFixture.GenerateInvalidUser();

            // Act
            _userService.Add(user);

            // Assert
            Assert.False(user.IsValid());
            _userTestsAutoMockerFixture.Mocker.GetMock<IUserRepository>().Verify(r => r.Add(user), Times.Never);
            _userTestsAutoMockerFixture.Mocker.GetMock<IMediator>().Verify(m => m.Publish(It.IsAny<INotification>(), CancellationToken.None), Times.Never);
        }

        [Fact(DisplayName = "Get Active Users")]
        [Trait("Category", "User Service AutoMockFixture Tests")]
        public void UserService_GetAllActive_ShouldReturnOnlyActiveUsers()
        {
            // Arrange
            _userTestsAutoMockerFixture.Mocker.GetMock<IUserRepository>().Setup(c => c.GetAll())
                .Returns(_userTestsAutoMockerFixture.GetVariousUsers());

            // Act
            var users = _userService.GetAllActive();

            // Assert 
            _userTestsAutoMockerFixture.Mocker.GetMock<IUserRepository>().Verify(r => r.GetAll(), Times.Once);
            Assert.True(users.Any());
            Assert.False(users.Count(u => !u.IsActive) > 0);
        }
    }
}