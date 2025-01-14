using MediatR;

namespace DPS.Features.Domain.Models
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMediator _mediator;

        public UserService(IUserRepository userRepository,
                              IMediator mediator)
        {
            _userRepository = userRepository;
            _mediator = mediator;
        }

        public IEnumerable<User> GetAllActive()
        {
            return _userRepository.GetAll().Where(u => u.IsActive);
        }

        public void Add(User user)
        {
            if (!user.IsValid())
                return;

            _userRepository.Add(user);
            _mediator.Publish(new UserEmailNotification("admin@test.com", user.Email, "Hello", "Welcome!"));
        }

        public void Update(User user)
        {
            if (!user.IsValid())
                return;

            _userRepository.Update(user);
            _mediator.Publish(new UserEmailNotification("admin@test.com", user.Email, "Changes", "Take a look!"));
        }

        public void Deactivate(User user)
        {
            if (!user.IsValid())
                return;

            user.Deactivate();
            _userRepository.Update(user);
            _mediator.Publish(new UserEmailNotification("admin@test.com", user.Email, "See you soon", "See you later!"));
        }

        public void Remove(User user)
        {
            _userRepository.Remove(user.Id);
            _mediator.Publish(new UserEmailNotification("admin@test.com", user.Email, "Goodbye", "Have a good journey!"));
        }

        public void Dispose()
        {
            _userRepository.Dispose();
        }
    }
}