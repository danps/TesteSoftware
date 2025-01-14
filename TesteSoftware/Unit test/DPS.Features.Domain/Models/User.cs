using DPS.Features.Domain.Core;
using FluentValidation;

namespace DPS.Features.Domain.Models
{
    public class User : Entity
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime BirthDate { get; private set; }
        public DateTime RegistrationDate { get; private set; }
        public string Email { get; private set; }
        public bool IsActive { get; private set; }

        protected User()
        {
        }

        public User(Guid id, string firstName, string lastName, DateTime birthDate, string email, bool isActive,
            DateTime registrationDate)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            Email = email;
            IsActive = isActive;
            RegistrationDate = registrationDate;
        }

        public string FullName()
        {
            return $"{FirstName} {LastName}";
        }

        public bool IsSpecial()
        {
            return RegistrationDate < DateTime.Now.AddYears(-3) && IsActive;
        }

        public void Deactivate()
        {
            IsActive = false;
        }

        public override bool IsValid()
        {
            ValidationResult = new UserValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class UserValidation : AbstractValidator<User>
    {
        public UserValidation()
        {
            RuleFor(c => c.FirstName)
                .NotEmpty().WithMessage("Please make sure you have entered the first name")
                .Length(2, 150).WithMessage("The first name must be between 2 and 150 characters");

            RuleFor(c => c.LastName)
                .NotEmpty().WithMessage("Please make sure you have entered the last name")
                .Length(2, 150).WithMessage("The last name must be between 2 and 150 characters");

            RuleFor(c => c.BirthDate)
                .NotEmpty()
                .Must(HaveMinimumAge)
                .WithMessage("The user must be 18 years old or older");

            RuleFor(c => c.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        public static bool HaveMinimumAge(DateTime birthDate)
        {
            return birthDate <= DateTime.Now.AddYears(-18);
        }
    }
}