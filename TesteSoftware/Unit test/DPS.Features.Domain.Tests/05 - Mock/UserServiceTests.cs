using DPS.Features.Domain.Models;
using MediatR;
using Moq;

namespace DPS.Features.Domain.Tests
{
    [Collection(nameof(UserBogusCollection))]
    public class UserServiceTests
    {
        readonly UserTestsBogusFixture _userTestsBogus;

        public UserServiceTests(UserTestsBogusFixture userTestsFixture)
        {
            _userTestsBogus = userTestsFixture;
        }

        [Fact(DisplayName = "Add User Successfully")]
        [Trait("Category", "User Service Mock Tests")]
        public void UserService_Add_ShouldExecuteSuccessfully()
        {
            // Arrange
            var user = _userTestsBogus.GenerateValidUser();
            var userRepo = new Mock<IUserRepository>();
            var mediator = new Mock<IMediator>();

            var userService = new UserService(userRepo.Object, mediator.Object);

            // Act
            userService.Add(user);

            // Assert
            Assert.True(user.IsValid());
            userRepo.Verify(r => r.Add(user), Times.Once);
            mediator.Verify(m => m.Publish(It.IsAny<INotification>(), CancellationToken.None), Times.Once);
        }

        [Fact(DisplayName = "Add User Failure")]
        [Trait("Category", "User Service Mock Tests")]
        public void UserService_Add_ShouldFailDueToInvalidUser()
        {
            // Arrange
            var user = _userTestsBogus.GenerateInvalidUser();
            var userRepo = new Mock<IUserRepository>();
            var mediator = new Mock<IMediator>();

            var userService = new UserService(userRepo.Object, mediator.Object);

            // Act
            userService.Add(user);

            // Assert
            Assert.False(user.IsValid());
            userRepo.Verify(r => r.Add(user), Times.Never);
            mediator.Verify(m => m.Publish(It.IsAny<INotification>(), CancellationToken.None), Times.Never);
        }

        [Fact(DisplayName = "Get Active Users")]
        [Trait("Category", "User Service Mock Tests")]
        public void UserService_GetAllActive_ShouldReturnOnlyActiveUsers()
        {
            // Arrange
            var userRepo = new Mock<IUserRepository>();
            var mediator = new Mock<IMediator>();

            userRepo.Setup(c => c.GetAll())
                .Returns(_userTestsBogus.GetVariousUsers());

            var userService = new UserService(userRepo.Object, mediator.Object);

            // Act
            var users = userService.GetAllActive();

            // Assert 
            userRepo.Verify(r => r.GetAll(), Times.Once);
            Assert.True(users.Any());
            Assert.False(users.Count(u => !u.IsActive) > 0);
        }
    }
}