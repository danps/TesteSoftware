namespace DPS.Features.Domain.Models
{
    public interface IUserService : IDisposable
    {
        IEnumerable<User> GetAllActive();
        void Add(User client);
        void Update(User client);
        void Remove(User client);
        void Deactivate(User client);
    }
}