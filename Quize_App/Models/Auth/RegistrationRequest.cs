using System;
using FluentValidation;
using Shared;

namespace Quize_App.Models
{
    public class RegistrationRequest
    {
        public string Username { get; init; } = null!;
        public string Password { get; init; } = null!;
    }

    #region Validation

    public class RegistrationRequestValidator : AbstractValidator<RegistrationRequest>
    {
        public RegistrationRequestValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty()
                .WithMessage(ErrMessages.UsernameEmpty);

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage(ErrMessages.PasswordEmpty)
                .MinimumLength(6)
                .WithMessage(ErrMessages.PasswordMinChar);
        }
    }

    #endregion

}

