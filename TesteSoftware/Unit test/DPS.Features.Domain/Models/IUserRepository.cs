using DPS.Features.Domain.Core;

namespace DPS.Features.Domain.Models
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByEmail(string email);
    }
}