using System;
using FluentValidation;
using Shared;

namespace Quize_App.Models
{
    public class AuthRequest
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
    }

    #region Validator
    public class AuthRequestValidator : AbstractValidator<AuthRequest>
    {
        public AuthRequestValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage(ErrMessages.UsernameEmpty);

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage(ErrMessages.PasswordEmpty)
                .MinimumLength(6)
                .WithMessage(ErrMessages.PasswordMinChar);

        }
    }
    #endregion

}

