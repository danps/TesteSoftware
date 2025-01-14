using DPS.Features.Domain.Models;
using MediatR;
using Moq;
using Moq.AutoMock;

namespace DPS.Features.Domain.Tests
{
    [Collection(nameof(UserBogusCollection))]
    public class UserServiceAutoMockerTests
    {
        readonly UserTestsBogusFixture _userTestsBogus;

        public UserServiceAutoMockerTests(UserTestsBogusFixture userTestsFixture)
        {
            _userTestsBogus = userTestsFixture;
        }

        [Fact(DisplayName = "Add User Successfully")]
        [Trait("Category", "User Service AutoMock Tests")]
        public void UserService_Add_ShouldExecuteSuccessfully()
        {
            // Arrange
            var user = _userTestsBogus.GenerateValidUser();
            var mocker = new AutoMocker();
            var userService = mocker.CreateInstance<UserService>();

            // Act
            userService.Add(user);

            // Assert
            Assert.True(user.IsValid());
            mocker.GetMock<IUserRepository>().Verify(r => r.Add(user), Times.Once);
            mocker.GetMock<IMediator>().Verify(m => m.Publish(It.IsAny<INotification>(), CancellationToken.None), Times.Once);
        }

        [Fact(DisplayName = "Add User Failure")]
        [Trait("Category", "User Service AutoMock Tests")]
        public void UserService_Add_ShouldFailDueToInvalidUser()
        {
            // Arrange
            var user = _userTestsBogus.GenerateInvalidUser();
            var mocker = new AutoMocker();
            var userService = mocker.CreateInstance<UserService>();

            // Act
            userService.Add(user);

            // Assert
            Assert.False(user.IsValid());
            mocker.GetMock<IUserRepository>().Verify(r => r.Add(user), Times.Never);
            mocker.GetMock<IMediator>().Verify(m => m.Publish(It.IsAny<INotification>(), CancellationToken.None), Times.Never);
        }

        [Fact(DisplayName = "Get Active Users")]
        [Trait("Category", "User Service AutoMock Tests")]
        public void UserService_GetAllActive_ShouldReturnOnlyActiveUsers()
        {
            // Arrange
            var mocker = new AutoMocker();
            var userService = mocker.CreateInstance<UserService>();

            mocker.GetMock<IUserRepository>().Setup(c => c.GetAll())
                .Returns(_userTestsBogus.GetVariousUsers());

            // Act
            var users = userService.GetAllActive();

            // Assert 
            mocker.GetMock<IUserRepository>().Verify(r => r.GetAll(), Times.Once);
            Assert.True(users.Any());
            Assert.False(users.Count(u => !u.IsActive) > 0);
        }
    }
}