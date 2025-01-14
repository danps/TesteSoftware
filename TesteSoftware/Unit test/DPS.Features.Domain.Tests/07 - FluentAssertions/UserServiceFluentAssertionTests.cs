using DPS.Features.Domain.Models;
using FluentAssertions;
using FluentAssertions.Extensions;
using MediatR;
using Moq;

namespace DPS.Features.Domain.Tests
{
    [Collection(nameof(UserAutoMockerCollection))]
    public class UserServiceFluentAssertionTests
    {
        private readonly UserTestsAutoMockerFixture _userTestsAutoMockerFixture;

        private readonly UserService _userService;

        public UserServiceFluentAssertionTests(UserTestsAutoMockerFixture userTestsFixture)
        {
            _userTestsAutoMockerFixture = userTestsFixture;
            _userService = _userTestsAutoMockerFixture.GetUserService();
        }

        [Fact(DisplayName = "Add User Successfully")]
        [Trait("Category", "User Service Fluent Assertion Tests")]
        public void UserService_Add_ShouldExecuteSuccessfully()
        {
            // Arrange
            var user = _userTestsAutoMockerFixture.GenerateValidUser();

            // Act
            _userService.Add(user);

            // Assert
            //Assert.True(user.IsValid());

            // Assert
            user.IsValid().Should().BeTrue();

            _userTestsAutoMockerFixture.Mocker.GetMock<IUserRepository>().Verify(r => r.Add(user), Times.Once);
            _userTestsAutoMockerFixture.Mocker.GetMock<IMediator>().Verify(m => m.Publish(It.IsAny<INotification>(), CancellationToken.None), Times.Once);
        }

        [Fact(DisplayName = "Add User Failure")]
        [Trait("Category", "User Service Fluent Assertion Tests")]
        public void UserService_Add_ShouldFailDueToInvalidUser()
        {
            // Arrange
            var user = _userTestsAutoMockerFixture.GenerateInvalidUser();

            // Act
            _userService.Add(user);

            // Assert
            Assert.False(user.IsValid());

            // Assert
            user.IsValid().Should().BeFalse("Has inconsistencies");
            user.ValidationResult.Errors.Should().HaveCountGreaterThan(1);

            _userTestsAutoMockerFixture.Mocker.GetMock<IUserRepository>().Verify(r => r.Add(user), Times.Never);
            _userTestsAutoMockerFixture.Mocker.GetMock<IMediator>().Verify(m => m.Publish(It.IsAny<INotification>(), CancellationToken.None), Times.Never);
        }

        [Fact(DisplayName = "Get Active Users")]
        [Trait("Category", "User Service Fluent Assertion Tests")]
        public void UserService_GetAllActive_ShouldReturnOnlyActiveUsers()
        {
            // Arrange
            _userTestsAutoMockerFixture.Mocker.GetMock<IUserRepository>().Setup(c => c.GetAll())
                .Returns(_userTestsAutoMockerFixture.GetVariousUsers());

            // Act
            var users = _userService.GetAllActive();

            // Assert
            //Assert.True(users.Any());
            //Assert.False(users.Count(u => !u.IsActive) > 0);

            // Assert
            users.Should().HaveCountGreaterThanOrEqualTo(1).And.OnlyHaveUniqueItems();
            users.Should().NotContain(u => !u.IsActive);

            _userTestsAutoMockerFixture.Mocker.GetMock<IUserRepository>().Verify(r => r.GetAll(), Times.Once);

            _userService.ExecutionTimeOf(c => c.GetAllActive())
                .Should()
                .BeLessThanOrEqualTo(50.Milliseconds(), "it is executed thousands of times per second");
        }
    }
}