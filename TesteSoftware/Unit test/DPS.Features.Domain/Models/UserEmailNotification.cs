using MediatR;

namespace DPS.Features.Domain.Models
{
    public class UserEmailNotification : INotification
    {
        public string From { get; private set; }
        public string To { get; private set; }
        public string Subject { get; private set; }
        public string Message { get; private set; }

        public UserEmailNotification(string from, string to, string subject, string message)
        {
            From = from;
            To = to;
            Subject = subject;
            Message = message;
        }
    }
}