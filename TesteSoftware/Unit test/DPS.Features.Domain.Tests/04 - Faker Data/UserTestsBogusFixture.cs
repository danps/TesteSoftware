﻿using Bogus;
using Bogus.DataSets;
using DPS.Features.Domain.Models;

namespace DPS.Features.Domain.Tests
{
    [CollectionDefinition(nameof(UserBogusCollection))]
    public class UserBogusCollection : ICollectionFixture<UserTestsBogusFixture>
    { }

    public class UserTestsBogusFixture : IDisposable
    {
        public User GenerateValidUser()
        {
            return GenerateUsers(1, true).FirstOrDefault();
        }

        public IEnumerable<User> GetVariousUsers()
        {
            var users = new List<User>();

            users.AddRange(GenerateUsers(50, true).ToList());
            users.AddRange(GenerateUsers(50, false).ToList());

            return users;
        }

        public IEnumerable<User> GenerateUsers(int quantity, bool isActive)
        {
            var gender = new Faker().PickRandom<Name.Gender>();

            var users = new Faker<User>("en")
                .CustomInstantiator(f => new User(
                    Guid.NewGuid(),
                    f.Name.FirstName(gender),
                    f.Name.LastName(gender),
                    f.Date.Past(80, DateTime.Now.AddYears(-18)),
                    "",
                    isActive,
                    DateTime.Now))
                .RuleFor(u => u.Email, (f, u) =>
                    f.Internet.Email(u.FirstName.ToLower(), u.LastName.ToLower()));

            return users.Generate(quantity);
        }

        public User GenerateInvalidUser()
        {
            var gender = new Faker().PickRandom<Name.Gender>();

            var user = new Faker<User>("en")
                .CustomInstantiator(f => new User(
                    Guid.NewGuid(),
                    f.Name.FirstName(gender),
                    f.Name.LastName(gender),
                    f.Date.Past(1, DateTime.Now.AddYears(1)),
                    "",
                    false,
                    DateTime.Now));

            return user;
        }

        public void Dispose()
        {
        }
    }
}