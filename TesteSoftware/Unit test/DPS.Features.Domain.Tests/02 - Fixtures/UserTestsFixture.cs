using DPS.Features.Domain.Models;

namespace DPS.Features.Domain.Tests
{
    [CollectionDefinition(nameof(UserCollection))]
    public class UserCollection : ICollectionFixture<UserTestsFixture>
    { }

    public class UserTestsFixture : IDisposable
    {
        public User GenerateValidUser()
        {
            var client = new User(
                Guid.NewGuid(),
                "Foo",
                "Bar",
                DateTime.Now.AddYears(-30),
                "test@test.com",
                true,
                DateTime.Now);

            return client;
        }

        public User GenerateInvalidUser()
        {
            var client = new User(
                Guid.NewGuid(),
                "",
                "",
                DateTime.Now,
                "test2@test.com",
                true,
                DateTime.Now);

            return client;
        }

        public void Dispose()
        {
        }
    }
}